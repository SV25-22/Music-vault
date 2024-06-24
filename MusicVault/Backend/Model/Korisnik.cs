using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model.Enums;
using System;

namespace MusicVault.Backend.Model;

public class Korisnik : IDAble {
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public TipKorisnika Tip { get; set; }
    public string Mejl { get; set; }
    public string Telefon { get; set; }
    public DateTime GodRodjenja { get; set; }
    public Pol Pol { get; set; }
    private string _lozinka;
    public string Lozinka { get { return _lozinka; } set { _lozinka = SifrujLozinku(value); } }
    public bool Javni { get; set; }

    private string SifrujLozinku(string lozinka) {
        return lozinka + "123"; // Primitivni algoritam sifrovanja
    }

    public bool ProveriLozinku(string lozinka) {
        return lozinka + "123" == Lozinka;
    }
}