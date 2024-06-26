using Microsoft.EntityFrameworkCore;
using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model;

namespace MusicVault.Backend.Repositories;

public class RecenzijaRepository : SQLGenericRepository<Recenzija> {
    public RecenzijaRepository(SqlDbContext dbContext) : base(dbContext) { }
}