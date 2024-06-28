using MusicVault.Backend.BuildingBlocks.Controller;
using MusicVault.Backend.Model;
using MusicVault.Backend.Model.Enums;
using MusicVault.Backend.Repositories;
using System;

namespace MusicVault.Backend.Controllers;
public class KorisnikController : GenericController<Korisnik, KorisnikRepository> {
    public KorisnikController() { }

    // GUI Poziva ovu metodu samo sa validnim podacima
    public Korisnik? RegistrujKorisnika(string ime, string prezime, string mejl, 
                                       string telefon, DateOnly godinaRodjenja,
                                       Pol pol, string lozinka) {
        if (repository.MailPostoji(mejl)) {
            return null;
        }

        Korisnik novKorisnik = new Korisnik(ime, prezime, TipKorisnika.Registrovani, 
                                            mejl, telefon, godinaRodjenja,
                                            pol, lozinka, true);

        repository.Add(novKorisnik);

        return novKorisnik;
    }

    // GUI Poziva ovu metodu samo sa validnim podacima
    public Korisnik? RegistrujUrednika(string ime, string prezime, string mejl,
                                       string telefon, DateOnly godinaRodjenja,
                                       Pol pol, string lozinka) {
        if (repository.MailPostoji(mejl)) {
            return null;
        }

        Korisnik novUrednik = new Korisnik(ime, prezime, TipKorisnika.Urednik,
                                            mejl, telefon, godinaRodjenja,
                                            pol, lozinka, true);

        repository.Add(novUrednik);

        return novUrednik;
    }

    // todo dodati proveru ako je tacan samo mail
    public Korisnik? UlogujSe(string mejl, string lozinka) {
        return repository.KorisnikNaOsnovuKredencijala(mejl, lozinka);
    }
}