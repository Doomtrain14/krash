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
my @vcc_char = qw(1.080 1.110 1.140 1.200 1.260 1.290 1.320);
my $g_testheader = "";
my %fun_string;

open(LOOKUP_IN, '<',   "_funlist")  or die "Error: Cannot open lookup table!\n";
while (<LOOKUP_IN>) {
    /(\w+)( \w+)?/;
    my $s = $2?$2:1;
    push @functionals, $1;
    push @state, $s;
}
my $fun_count = 1+$#functionals;

$| = 1;
print "\n";

for my $file (@ARGV) {
    #reset variables
    $g_testheader = "";

    print "Processing: $file... ";
    #Open input file for READ
    open(FILE_IN, '<',   $file)  or die "Error: Cannot open $file!\n";
    $file=~s/\.(\w+)$/"_mod\.".$1/e;
    open(FILE_OUT, '>', "$file") or die "Error: Cannot open $file!\n";

    #Read the file
    while (<FILE_IN>) {
        /(\w+)/;
        my $firstword = $1;
        if (/^#START_DEVICE/) {
            #reset variables
            %fun_string = ();
            for my $temp (@vcc_char) {
                $fun_string{$temp} = 'p' x $fun_count;
            }
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
            if (/^pump_char/) {
                my $count = split " ",$_;
                if ($count==6) {
                    print FILE_OUT "TNAME RESULT VALUE VCC SUPPLIES STATE\n";
                }else {
                    print FILE_OUT "$g_testheader\n";
                }
                print FILE_OUT "$_\n";   
            } elsif (/vcc_shorts/) {
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
                $_= <FILE_IN>;
            } else {
                print FILE_OUT "$g_testheader\n";
                print FILE_OUT "$_\n";
            }
        
        } elsif (" @functionals "=~m/ $firstword / ) {
            m/(\S+)\s+(\S+)\s+(\S+)/;
            my $m_vcc = $3;
            my $m_test = $1;
            my $m_result = $2;
            my ($m_index) = grep { $functionals[$_] eq $m_test } (0 .. @functionals-1);

            substr($fun_string{$m_vcc},$m_index) = $m_result eq 'PASS'?1:0
        } elsif (/^funcbin/ ) {
            print FILE_OUT "TNAME RESULTS TEXT VCC\n";
            for my $temp (@vcc_char) {
                print FILE_OUT "functionals ".($fun_string{$temp}=~y/0//?"FAIL ":"PASS ").($fun_string{$temp})." $temp\n";
            }
            print FILE_OUT "$g_testheader\n";
            print FILE_OUT "$_" ;
        } else {
            print FILE_OUT "$_" ;
        }
    }
    #CLose file
    close(FILE_IN);
    close(FILE_OUT);
    print "DONE\n";
}