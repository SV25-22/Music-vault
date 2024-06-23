using MusicVault.Backend.BuildingBlocks.Storage;
using System;

namespace MusicVault.Backend.Model;

public class Pregled : IDAble {
    public Korisnik Korisnik { get; }
    public MuzickiSadrzaj.MuzickiSadrzaj MuzickiSadrzaj { get; }
    public DateOnly Datum { get; }

    public Pregled() { }

    public Pregled(Korisnik korisnik, MuzickiSadrzaj.MuzickiSadrzaj muzickiSadrzaj, DateOnly datum) {
        Korisnik = korisnik;
        MuzickiSadrzaj = muzickiSadrzaj;
        Datum = datum;
    }
}