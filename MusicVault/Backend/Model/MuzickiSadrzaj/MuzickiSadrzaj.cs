using MusicVault.Backend.BuildingBlocks.Storage;
using System.Collections.Generic;

namespace MusicVault.Backend.Model.MuzickiSadrzaj;

public abstract class MuzickiSadrzaj : IDAble {
    public string Opis { get; set; }
    public ICollection<MultimedijalniSadrzaj.MultimedijalniSadrzaj> MultimedijalniSadrzaji { get; set; }
    public ICollection<MuzickiSadrzaj> MuzickiSadrzaji { get; set; }
    public ICollection<Zanr> Zanrevi { get; set; }

    public MuzickiSadrzaj() { }

    public MuzickiSadrzaj(string opis) {
        Opis = opis;
        MultimedijalniSadrzaji = new List<MultimedijalniSadrzaj.MultimedijalniSadrzaj>();
        MuzickiSadrzaji = new List<MuzickiSadrzaj>();
        Zanrevi = new List<Zanr>();
    }

    public void DodajMultimedijalniSadrzaj(MultimedijalniSadrzaj.MultimedijalniSadrzaj multimedijalniSadrzaj) {
        MultimedijalniSadrzaji.Add(multimedijalniSadrzaj);
    }

    public void DodajMuzickiSadrzaj(MuzickiSadrzaj muzickiSadrzaj) {
        MuzickiSadrzaji.Add(muzickiSadrzaj);
    }

    public void DodajZanr(Zanr zanr) {
        Zanrevi.Add(zanr);
    }
}