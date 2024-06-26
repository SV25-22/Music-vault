using Microsoft.EntityFrameworkCore;
using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model;

namespace MusicVault.Backend.Repositories;

public class GlasanjeRepository : SQLGenericRepository<Glasanje> {
    public GlasanjeRepository(DbContext dbContext) : base(dbContext) { }
}