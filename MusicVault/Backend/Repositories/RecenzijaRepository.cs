using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model.Recenzija;
using System.ComponentModel.DataAnnotations;

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
}