use strict;
use warnings;

#Version reflected in Krash tool
my $version="1.0.3";

if (!@ARGV) {
    print "\nUsage:\n\n    tpdcnt.pl <filename>\n\n";
    exit;
}

my @functionals;
my @state;
my $g_testheader = "";
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
            print FILE_OUT "#TEMP $temp\n";
        } elsif (/^#FUNCS/) {
            #add functional list in header
            my $s = "@functionals \n";
            $s =~ s/ /,/g;
            print FILE_OUT "#FUNCS $s";
        } elsif (/^#MON_CHARS/) {
            print FILE_OUT "#MON_CHARS func_pass=1,func_fail=0,ignore_pass=p,ignore_fail=.,cfg_pass=1,cfg_fail=0\n";
        } elsif (/^TNAME/) {
            chomp;
            $g_testheader = $_;
            $_= <FILE_IN>;
            chomp;
            if (/vcc_shorts/) {
                print FILE_OUT "$g_testheader"."STATE\n";
                print FILE_OUT "$_"."VCC\n";
                $_= <FILE_IN>;
                chomp;
                print FILE_OUT "$_"."VCCIO_P\n";
            } elsif (/pass_bin/) {
                $g_testheader=~s/TEXT/STATE/g;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
                $_= <FILE_IN>;
                chomp;
                print FILE_OUT "$_\n";
                $_= <FILE_IN>;
                chomp;
                /^pass_bin (\w+) (\S+)/;
                print FILE_OUT "TNAME RESULTS TEXT VALUE\n";
                print FILE_OUT "bin_result PASS $1 ".(int($2))."\n";
            } elsif (/^post_fail_bin/) {
                $g_testheader=~s/TEXT/STATE/g;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
                $_= <FILE_IN>;
                chomp;
                print FILE_OUT "$_\n";
                $_= <FILE_IN>;
                chomp;
                /^post_fail_bin (\w+) (\S+)/;
                print FILE_OUT "TNAME RESULTS TEXT VALUE\n";
                print FILE_OUT "bin_result FAIL $1 ".(int($2))."\n";
            } elsif (/^fail_bin/) {
                $g_testheader=~s/TEXT/STATE/g;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
    
                $_= <FILE_IN>;
                chomp;
                print FILE_OUT "$_\n";

                $_= <FILE_IN>;
                chomp;
                /^fail_bin (\w+) (\S+)/;

                print FILE_OUT "TNAME RESULTS TEXT VALUE\n";
                print FILE_OUT "bin_result FAIL $1 ".(int($2))."\n";
            } elsif (/^pre_os_fail_bin/) {
                $g_testheader=~s/TEXT/STATE/g;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";

                $_= <FILE_IN>;
                chomp;
                print FILE_OUT "$_\n";

                $_= <FILE_IN>;
                chomp;
                /^pre_os_fail_bin (\w+) (\S+)/;

                print FILE_OUT "TNAME RESULTS TEXT VALUE\n";
                print FILE_OUT "bin_result FAIL $1 ".(int($2))."\n";
            } elsif (/flash_chk/) {
                $g_testheader=~s/TEXT/STATE/g;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
                $_= <FILE_IN>;
                chomp;
                print FILE_OUT "$_\n";
            } elsif (/bp_outgoing/) {
                $g_testheader=~s/TEXT/STATE/g;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
                $_= <FILE_IN>;
                chomp;
                print FILE_OUT "$_\n";
                $_= <FILE_IN>;
                chomp;
                print FILE_OUT "$_\n"; 
            } elsif (/trim_dtr_sort2.+mfg_trim_dtr/) {
                $_=<FILE_IN>;
                chomp;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
                $_=<FILE_IN>;
                $_=<FILE_IN>;
                chomp;
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
            } elsif (/vfy_bandgap/) {
                

                if (s/atb_force leakage/atb_force_leakage/) {
                    print FILE_OUT "TNAME VALUE VCC SUPPLIES STATE\n";
                    chomp;
                    print FILE_OUT "$_\n";
                    $_=<FILE_IN>;
                    chomp;
                    print FILE_OUT "$_\n";
                    
                    $_=<FILE_IN>;
                    chomp;
                    print FILE_OUT "$_\n";
                    $_=<FILE_IN>;
                    chomp;
                    print FILE_OUT "$_\n";
                    $_=<FILE_IN>;
                    chomp;
                    print FILE_OUT "$_\n";
                } else {
                    print FILE_OUT "TNAME RESULTS VALUE VCC SUPPLIES STATE\n";
                    $_=<FILE_IN>;
                    chomp;
                    print FILE_OUT "$_\n";
                }
            } elsif (/vtp_shift_check/) {
                print FILE_OUT "TNAME RESULTS VCC SUPPLIES STATE\n";
                $_= <FILE_IN>;
                chomp;
                /vtp_shift_check (.+) (.+) (.+) (.+) (.+) (.+) (.+)/;
                print FILE_OUT "vtp_shift_check $1 $5 $6 $7\n";
            } elsif (/^tpdcnt (\S+)/ && ($1 ne "PASS") && ($1 ne "FAIL")) {
                #merge tpdcnt's
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$1 $1$'\n";
                $_= <FILE_IN>;
                chomp;
                /^tpdcnt (\S+)/;
                
                print FILE_OUT "$1 $1$'\n";
                $_= <FILE_IN>;
                chomp;
                /^tpdcnt (\S+)/;
                
                print FILE_OUT "$1 $1$'\n";
                $_= <FILE_IN>;
                chomp;
                /^tpdcnt (\S+)/;
                
                print FILE_OUT "$1 $1$'\n";
                $_= <FILE_IN>;
                chomp;
                /^tpdcnt (\S+)/;
                
                print FILE_OUT "$1 $1$'\n";   
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
    print "DONE\n";
}