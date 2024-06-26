using Microsoft.EntityFrameworkCore;
using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model;

namespace MusicVault.Backend.Repositories;

public class ReklamaRepository : SQLGenericRepository<Reklama> {
    public ReklamaRepository(SqlDbContext dbContext) : base(dbContext) { }
}