﻿using MusicVault.Backend.BuildingBlocks.Storage;
using System;

namespace MusicVault.Backend.Model;

public class Glas : IDAble {
    public Korisnik Korisnik { get; }
    public MuzickiSadrzaj.MuzickiSadrzaj MuzickiSadrzaj { get; }
    public DateOnly Datum { get; }
    public int Ocena { get; set; }

    public Glas() { }

    public Glas(Korisnik korisnik, MuzickiSadrzaj.MuzickiSadrzaj muzickiSadrzaj, DateOnly datum, int ocena) {
        Korisnik = korisnik;
        MuzickiSadrzaj = muzickiSadrzaj;
        Datum = datum;
        Ocena = ocena;
    }
}