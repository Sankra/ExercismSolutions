using System;
using System.Linq;

public static class RnaTranscription {
    public static string ToRna(string nucleotide)
        => new string(nucleotide.Select(Translate).ToArray());

    static char Translate(char dnaNucleotide) {
        switch (dnaNucleotide) {
            case 'G':
                return 'C';
            case 'C':
                return 'G';
            case 'T':
                return 'A';
            case 'A':
                return 'U';
            default:
                throw new Exception("Unexpected input: " + dnaNucleotide);
        }
    }
}