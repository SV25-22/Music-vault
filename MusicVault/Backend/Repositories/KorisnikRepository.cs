using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model.Enums;
using System.Collections.Generic;
using MusicVault.Backend.Model;
using System.Linq;
using System;

namespace MusicVault.Backend.Repositories;

public class KorisnikRepository : SQLGenericRepository<Korisnik> {
    public static Korisnik? KorisnikNaOsnovuKredencijala(string mejl, string lozinka) {
        try {
            using var context = new SqlDbContext();
            return context.Korisnik.Where(k => k.Mejl == mejl && Korisnik.SifrujLozinku(lozinka) == k.Lozinka && !k.Banovan).Single();
        } catch (InvalidOperationException) {
            return null;
        }
    }

    public static bool MailPostoji(string mejl, Korisnik? ignoreUser = null) {
        using var context = new SqlDbContext();
        return context.Korisnik.Any(k => k.Mejl == mejl && (ignoreUser == null || ignoreUser.Id != k.Id));
    }

    public static List<Korisnik> GetUrednici() {
        using var context = new SqlDbContext();
        return context.Korisnik.Where(k => k.Tip == TipKorisnika.Urednik).ToList();
    }
}
