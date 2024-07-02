using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model;
using System;
using System.Linq;

namespace MusicVault.Backend.Repositories;

public class KorisnikRepository : SQLGenericRepository<Korisnik> {
    public Korisnik? KorisnikNaOsnovuKredencijala(string mejl, string lozinka) {
        try {
            using (var context = new SqlDbContext()) {
                return context.Korisnik
                .Where(k => k.Mejl == mejl && lozinka == k.Lozinka)
                .Single();
            }
        } catch (InvalidOperationException) {
            return null;
        }
    }

    public bool MailPostoji(string mejl) {
        using (var context = new SqlDbContext()) {
            return context.Korisnik
            .Any(k => k.Mejl == mejl);
        }
    }
}
