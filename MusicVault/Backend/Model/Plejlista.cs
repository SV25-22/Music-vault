using MusicVault.Backend.BuildingBlocks.Storage;
using System.Collections.Generic;

namespace MusicVault.Backend.Model;

public class Plejlista : IDAble {
    public string Naziv { get; set; }
    public List<MuzickiSadrzaj.MuzickiSadrzaj> MuzickiSadrzaji { get; }
    public List<Zanr> Zanrovi { get; }

    public Plejlista() { }

    public Plejlista(string naziv) {
        Naziv = naziv;
        MuzickiSadrzaji = new();
        Zanrovi = new();
    }

    public void DodajZanr(Zanr zanr) {
        Zanrovi.Add(zanr);
    }

    public void DodajMuzickiSadrzaj(MuzickiSadrzaj.MuzickiSadrzaj muzickiSadrzaj) {
        MuzickiSadrzaji.Add(muzickiSadrzaj);
    }
}