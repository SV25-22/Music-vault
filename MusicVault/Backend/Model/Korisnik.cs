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
    public DateOnly GodRodjenja { get; set; }
    public Pol Pol { get; set; }
    private string _lozinka;
    public string Lozinka { get { return _lozinka; } set { _lozinka = value; } }
    public bool Javni { get; set; }

    // todo iskoristiti ovo
    public static string SifrujLozinku(string lozinka) {
        return lozinka + "123"; // Primitivni algoritam sifrovanja
    }

    public bool ProveriLozinku(string lozinka) {
        return SifrujLozinku(lozinka) == Lozinka;
    }

    public Korisnik() {
        Ime = "";
        Prezime = "";
        Tip = TipKorisnika.Neregistrovani;
        Mejl = "";
        Telefon = "";
        GodRodjenja = new DateOnly();
        Pol = Pol.Musko;
        _lozinka = "";
        Javni = false;
    }

    public Korisnik(string ime, string prezime, TipKorisnika tip, string mejl, string telefon, DateOnly godRodjenja, Pol pol, string lozinka, bool javni) {
        Ime = ime;
        Prezime = prezime;
        Tip = tip;
        Mejl = mejl;
        Telefon = telefon;
        GodRodjenja = godRodjenja;
        Pol = pol;
        _lozinka = lozinka;
        Javni = javni;
    }
}