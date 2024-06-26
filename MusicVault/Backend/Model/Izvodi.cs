using MusicVault.Backend.BuildingBlocks.Storage;

namespace MusicVault.Backend.Model;

public class Izvodi : IDAble {
    public string Uloga { get; }
    public virtual Izvodjac Izvodjac { get; }
    public virtual MuzickiSadrzaj.MuzickiSadrzaj MuzickiSadrzaj { get; }

    public Izvodi() { }

    public Izvodi(string uloga, Izvodjac izvodjac, MuzickiSadrzaj.MuzickiSadrzaj muzickiSadrzaj) {
        Uloga = uloga;
        Izvodjac = izvodjac;
        MuzickiSadrzaj = muzickiSadrzaj;
    }
}