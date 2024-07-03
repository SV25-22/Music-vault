using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model.Recenzija;

namespace MusicVault.Backend.Repositories;

public class RecenzijaRepository : SQLGenericRepository<Recenzija> {
    public RecenzijaRepository() { }

    public Recenzija DodajRecenziju(Recenzija entity) {
        using (var context = new SqlDbContext()) {
            context.Set<Recenzija>();
            context.Add(entity);
            context.Attach(entity.Urednik);
            context.Attach(entity.MuzickiSadrzaj);
            context.SaveChanges();
            return entity;
        }
    }
}