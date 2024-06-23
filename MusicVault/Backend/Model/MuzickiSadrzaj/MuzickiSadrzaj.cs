using MusicVault.Backend.BuildingBlocks.Storage;
using System.Collections.Generic;

namespace MusicVault.Backend.Model.MuzickiSadrzaj;

public abstract class MuzickiSadrzaj : IDAble {
    public string Opis { get; set; }
    public List<MultimedijalniSadrzaj.MultimedijalniSadrzaj> MultimedijalniSadrzaji { get; }
    public List<MuzickiSadrzaj> MuzickiSadrzaji { get; }
    public List<Zanr> Zanrevi { get; }

    public MuzickiSadrzaj() { }

    public MuzickiSadrzaj(string opis) {
        Opis = opis;
        MultimedijalniSadrzaji = new();
        MuzickiSadrzaji = new();
        Zanrevi = new();
    }
}