using Microsoft.EntityFrameworkCore;
using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model;

namespace MusicVault.Backend.Repositories;

public class PlejlistaRepository : SQLGenericRepository<Plejlista> {
    public PlejlistaRepository(DbContext dbContext) : base(dbContext) { }
}