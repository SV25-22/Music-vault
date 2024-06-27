using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model;
using System;
using System.Linq;

namespace MusicVault.Backend.Repositories;

public class KorisnikRepository : SQLGenericRepository<Korisnik> {
    public KorisnikRepository(SqlDbContext dbContext) : base(dbContext) { }

    public Korisnik? KorisnikNaOsnovuKredencijala(string mejl, string lozinka) {
        try {
            return context.Korisnik
                .Where(k => k.Mejl == mejl && Korisnik.SifrujLozinku(lozinka) == k.Lozinka)
                .Single();
        } catch (InvalidOperationException) {
            return null;
        }
    }

    public bool MailPostoji(string mejl) {
        return context.Korisnik
            .Any(k => k.Mejl == mejl);
    }
}
