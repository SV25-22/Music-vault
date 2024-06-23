using MusicVault.Backend.BuildingBlocks.Storage;

namespace MusicVault.Backend.Model;

public class Recenzija : IDAble {
    public Korisnik? Korisnik { get; }
    public MuzickiSadrzaj.MuzickiSadrzaj MuzickiSadrzaj { get; }
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