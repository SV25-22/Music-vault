using Microsoft.EntityFrameworkCore;
using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model.MultimedijalniSadrzaj;

namespace MusicVault.Backend.Repositories;

public class MultimedijalniSadrzajRepository : SQLGenericRepository<MultimedijalniSadrzaj> {
    public MultimedijalniSadrzajRepository(SqlDbContext dbContext) : base(dbContext) { }
}