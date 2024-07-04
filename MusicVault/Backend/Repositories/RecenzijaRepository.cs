using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model.Recenzija;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MusicVault.Backend.Repositories;

public class RecenzijaRepository : SQLGenericRepository<Recenzija> {
    public RecenzijaRepository() { }

    public Recenzija DodajRecenziju(Recenzija entity) {
        using (var context = new SqlDbContext()) {
            context.Set<Recenzija>();
            context.Attach(entity.Urednik);
            context.Attach(entity.MuzickiSadrzaj);
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }
    }

    public Recenzija GetEager(int id) {
        using (var context = new SqlDbContext()) {
            return context.Recenzija
                .Include(r => r.MuzickiSadrzaj)
                .Include(r => r.Urednik)
                .Where(r => r.Id == id)
                .Single();
        }
    }
}