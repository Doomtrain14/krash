use strict;
use warnings;

if (!@ARGV) {
    print "\nUsage:\n\n    tpdcnt.pl <filename>\n\n";
    exit;
}

for my $file (@ARGV) {
    #Open input file for READ
    open(FILE_IN, '<',   $file)  or die "Error: Cannot open $file!\n";
    $file=~s/\.(.+)/"_mod\.".$1/e;
    open(FILE_OUT, '>', "$file") or die "Error: Cannot open $file!\n";

    #Read the file
    /tpdcnt (\S+)/ && ($1 ne "PASS") && ($1 ne "FAIL")?
        print FILE_OUT "$1 $1$'"
    :
        print FILE_OUT "$_" while <FILE_IN>;

    #CLose file
    close(FILE_IN);
    close(FILE_OUT);
}