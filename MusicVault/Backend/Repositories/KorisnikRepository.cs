using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model;
using System.Linq;

namespace MusicVault.Backend.Repositories;

public class KorisnikRepository : SQLGenericRepository<Korisnik> {
    public KorisnikRepository(SqlDbContext dbContext) : base(dbContext) { }

    public Korisnik? KorisnikNaOsnovuKredencijala(string mejl, string lozinka) {
        return context.Korisnik
            .Where(k => k.Mejl == mejl && Korisnik.SifrujLozinku(lozinka) == k.Lozinka)
            .Single();
    }
}
