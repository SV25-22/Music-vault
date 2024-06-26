using Microsoft.EntityFrameworkCore;
using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model;

namespace MusicVault.Backend.Repositories;

public class IzvodjacRepository : SQLGenericRepository<Izvodjac> {
    public IzvodjacRepository(SqlDbContext dbContext) : base(dbContext) { }
}