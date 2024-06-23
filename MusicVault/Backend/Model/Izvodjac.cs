using MusicVault.Backend.BuildingBlocks.Storage;
using System.Collections.Generic;

namespace MusicVault.Backend.Model;

public class Izvodjac : IDAble {
    public string Opis { get; set; }

    public List<Zanr> Zanrevi { get; }

    public List<MultimedijalniSadrzaj.MultimedijalniSadrzaj> MultimedijalniSadrzaji { get; }

    public Izvodjac() { }

    public Izvodjac(string opis) {
        Opis = opis;
        Zanrevi = new();
        MultimedijalniSadrzaji = new();
    }

    public void DodajZanr(Zanr zanr) {
        Zanrevi.Add(zanr);
    }

    public void DodajMultimedijalniSadrzaj(MultimedijalniSadrzaj.MultimedijalniSadrzaj multimedijalniSadrzaj) {
        MultimedijalniSadrzaji.Add(multimedijalniSadrzaj);
    }
}