using MusicVault.Backend.BuildingBlocks.Storage;

namespace MusicVault.Backend.Model;

public class Recenzija : IDAble {
    public virtual Korisnik? Korisnik { get; set; }
    public virtual MuzickiSadrzaj.MuzickiSadrzaj MuzickiSadrzaj { get; set; }
    public int Ocena { get; set; }
    public string Opis { get; set; }
    public bool Objavljena { get; set; }

    public Recenzija() { }

    public Recenzija(Korisnik? korisnik, MuzickiSadrzaj.MuzickiSadrzaj muzickiSadrzaj, int ocena, string opis, bool objavljena) {
        MuzickiSadrzaj = muzickiSadrzaj;
        Korisnik = korisnik;
        Ocena = ocena;
        Opis = opis;
        Objavljena = objavljena;
    }
}