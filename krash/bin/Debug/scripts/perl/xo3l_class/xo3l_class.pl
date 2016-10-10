use strict;
use warnings;

#Version reflected in Krash tool
my $version="1.0.0";

if (!@ARGV) {
    print "\nUsage:\n\n    tpdcnt.pl <filename>\n\n";
    exit;
}

my @functionals;
my @state;
my $g_testheader = "";
my $g_wafer = 99;
my %vcc_hash;

open(LOOKUP_IN, '<',   "_funlist")  or die "Error: Cannot open lookup table!\n";
while (<LOOKUP_IN>) {
    /(\w+)( \w+)?/;
    my $s = $2?$2:1;
    push @functionals, $1;
    push @state, $s;
}

my %hash_func;
$| = 1;
print "\n";
for my $file (@ARGV) {
    #reset variables
    $g_testheader = "";
    %vcc_hash  = ();

    print "Processing: $file... ";
    #Open input file for READ
    open(FILE_IN, '<',   $file)  or die "Error: Cannot open $file!\n";
    $file=~s/\.(\w+)$/"_mod\.".$1/e;
    open(FILE_OUT, '>', "$file") or die "Error: Cannot open $file!\n";

    #Read the file
    while (<FILE_IN>) {
        if (/^#START_DEVICE/) {
            #reset variables
            %hash_func = ();
            print FILE_OUT "$_";
        } elsif (/^#TEMP +(.+)/) {
            my $temp = $1;
            $temp=~s/[a-zA-Z]+//g;
            $temp = int("0$temp");
            print FILE_OUT "#TEMP $temp\n";
        } elsif (/^#FUNCS/) {
            #add functional list in header
            my $s = "@functionals \n";
            $s =~ s/ /,/g;
            print FILE_OUT "#FUNCS $s";
        } elsif (/^#MON_CHARS/) {
            print FILE_OUT "#MON_CHARS func_pass=1,func_fail=0,ignore_pass=p,ignore_fail=.,cfg_pass=1,cfg_fail=0\n";
        } elsif (/^#OPER_LOT_ID/) {
            print FILE_OUT "$_";
            print FILE_OUT "#WAFER 99\n";
        } elsif (/^TNAME/) {
            chomp;
            $g_testheader = $_;
            $_= <FILE_IN>;
            chomp;
            if (/^vtemax_incoming/) {
                $g_testheader=~s/TEXT/STATE/g;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
                $_= <FILE_IN>;
                chomp;
                print FILE_OUT "$_\n";

                $_= <FILE_IN>;
                chomp;
                s/TEXT/STATE/g;
                print FILE_OUT "$_\n";
            } elsif (/^leakage_pulldown_12/) {
                if ($g_testheader=~/TEXT/ && $g_testheader=~/STATE/) {
                    $g_testheader=~s/STATE/COND1/g;
                    $g_testheader=~s/TEXT/STATE/g;
                }
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
            } elsif (/^pump_check/) {
                $g_testheader=~s/TEXT/STATE/g;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
            } elsif (/^dtr_check/) {
                $g_testheader=~s/TEXT/STATE/g;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
            } elsif (/^outgoing_vte_max/ || /^outgoing_vte_min/) {
                $g_testheader=~s/TEXT/STATE/g;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
            } elsif (/^outgoing_HES/) {
                $g_testheader=~s/TEXT/STATE/g;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
            } elsif (/^pes_verify/) {
                if (/(\S+) (\S+) (\S+) (\S+) (\S+) (\S+) mes_wafernum/) {
                    $g_wafer = $4;
                }
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
            #Changes for 484cabga
            } elsif (/^flash_chk/) {
                $g_testheader=~s/TEXT/STATE/g;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
            } else {  
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
            }
        
        } elsif (/^$functionals[0]/) {
            #merge functionals
            my $s = " @functionals ";
            while (1) {
                /(\w+) (\w+) (\S+)/;
                
                my $match = $1;
                my $result = $2;
                my $vcc = $3;
                
                
                if ($s=~m/ $match /) {
                    $vcc_hash{$vcc} = 1;
                    $hash_func{"$vcc::$match"} .= ($result eq "PASS")?"1":"0";
                } else {
                    
                    my $funstring;
                    foreach my $m_vcc (keys %vcc_hash) {
                        $funstring .=  "TNAME RESULTS TEXT VCC \n";
                        my $tempstring;
                        my $index = 0;
                        for my $fun (@functionals) {
                            if (exists($hash_func{"$m_vcc::$fun"})) {
                                $tempstring .= ($hash_func{"$m_vcc::$fun"}=~y/0//)? ($state[$index])?"0":'.':($state[$index])?"1":"p";
                            } else {
                                $tempstring .= "p";
                            }
                            $index++;
                        }

                        my $fun_result;
                        $fun_result = $tempstring=~y/0//?"FAIL":"PASS";

                        $funstring .= "functionals $fun_result $tempstring $m_vcc\n";
                        
                    }
                    print FILE_OUT "$funstring";
                    print FILE_OUT "TNAME RESULTS VCC SUPPLIES\n$_";
                    last;
                }
                $_ = <FILE_IN>;
            }
        } elsif (!/^#/) {
            #check for current units
            my @split_header = split " ", $g_testheader;
            my $index = -1;
            for my $i (0..@split_header-1) {
                if ($split_header[$i]=~/VALUE/i) {
                    $index = $i;
                    last;
                }
            }
            my $tempstring = "";
            my @tempsplit = split " ", $_;
            if (/^.+_mA ?$/i) {
                $tempsplit[$index]=~/e([+-]\d{2})/;
                #-3 for milli (mA)
                my $exp = sprintf "%+03d", $1-3;
                $tempsplit[$index]=~s/e[+-]\d{2}/"e$exp"/e;
                $tempstring = "@tempsplit";
                $tempstring =~s/_mA$//i;
                print FILE_OUT "$tempstring\n";
            } elsif (/^.+_uA ?$/i) {
                $tempsplit[$index]=~/e([+-]\d{2})/;
                #-6 for micro (uA)
                my $exp = sprintf "%+03d", $1-6;
                $tempsplit[$index]=~s/e[+-]\d{2}/"e$exp"/e;
                $tempstring = "@tempsplit";
                $tempstring =~s/_uA$//i;
                print FILE_OUT "$tempstring\n";
            } elsif (/^.+_nA ?$/i) {
                $tempsplit[$index]=~/e([+-]\d{2})/;
                #-9 for nano (nA)
                my $exp = sprintf "%+03d", $1-9;
                $tempsplit[$index]=~s/e[+-]\d{2}/"e$exp"/e;
                $tempstring = "@tempsplit";
                $tempstring =~s/_nA$//i;
                print FILE_OUT "$tempstring\n";
            } elsif (/^.+_pA ?$/i) {
                $tempsplit[$index]=~/e([+-]\d{2})/;
                #-12 for pico (pA)
                my $exp = sprintf "%+03d", $1-12;
                $tempsplit[$index]=~s/e[+-]\d{2}/"e$exp"/e;
                $tempstring = "@tempsplit";
                $tempstring =~s/_pA$//i;
                print FILE_OUT "$tempstring\n";
            } else {
                print FILE_OUT "$_";
            }
        } else {
            print FILE_OUT "$_" ;
        }
    }
    #CLose file
    close(FILE_IN);
    close(FILE_OUT);

    #Print back correct wafer #
    {
        local ($^I, @ARGV) = ('.bak', ($file)); 
        while (<>) {
            s/#WAFER.*/#WAFER $g_wafer/;  
            print;  
        }
    }
    unlink "$file\.bak";
    print "DONE\n";
}