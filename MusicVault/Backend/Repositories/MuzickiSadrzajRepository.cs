using Microsoft.EntityFrameworkCore;
using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model.MuzickiSadrzaj;

namespace MusicVault.Backend.Repositories;

public class MuzickiSadrzajRepository : SQLGenericRepository<MuzickiSadrzaj> {
    public MuzickiSadrzajRepository(DbContext dbContext) : base(dbContext) { }
}