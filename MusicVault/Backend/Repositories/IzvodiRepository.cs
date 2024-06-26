using Microsoft.EntityFrameworkCore;
using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model;

namespace MusicVault.Backend.Repositories;

public class IzvodiRepository : SQLGenericRepository<Izvodi> {
    public IzvodiRepository(SqlDbContext dbContext) : base(dbContext) { }
}