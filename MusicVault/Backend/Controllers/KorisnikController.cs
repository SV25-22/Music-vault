using MusicVault.Backend.BuildingBlocks.Controller;
using MusicVault.Backend.Model;
using MusicVault.Backend.Model.Enums;
using MusicVault.Backend.Repositories;
using System;

namespace MusicVault.Backend.Controllers;
public class KorisnikController : GenericController<Korisnik, KorisnikRepository> {
    public KorisnikController() { }

    // GUI Poziva ovu metodu samo sa validnim podacima
    public Korisnik? RegistrujKorisnika(Korisnik korisnik) {
        if (repository.MailPostoji(korisnik.Mejl)) {
            return null;
        }

        korisnik.Tip = TipKorisnika.Registrovani;

        repository.Add(korisnik);

        return korisnik;
    }

    // GUI Poziva ovu metodu samo sa validnim podacima
    public Korisnik? RegistrujUrednika(Korisnik korisnik) {
        if (repository.MailPostoji(korisnik.Mejl)) {
            return null;
        }

        korisnik.Tip = TipKorisnika.Urednik;

        repository.Add(korisnik);

        return korisnik;
    }

    // todo dodati proveru ako je tacan samo mail
    public Korisnik? UlogujSe(string mejl, string lozinka) {
        return repository.KorisnikNaOsnovuKredencijala(mejl, lozinka);
    }
}