using Microsoft.EntityFrameworkCore;
using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model;

namespace MusicVault.Backend.Repositories;

public class KorisnikRepository : SQLGenericRepository<Korisnik> {
    public KorisnikRepository(DbContext dbContext) : base(dbContext) { }
}
