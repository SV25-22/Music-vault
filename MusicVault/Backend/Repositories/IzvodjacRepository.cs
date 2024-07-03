using MusicVault.Backend.BuildingBlocks.Storage;
using System.Collections.Generic;
using MusicVault.Backend.Model;
using System.Linq;

namespace MusicVault.Backend.Repositories;

public class IzvodjacRepository : SQLGenericRepository<Izvodjac> {
    public static List<Izvodjac> Search(string search = "") {
        using var context = new SqlDbContext();
        return context.Izvodjac.Where(i => string.IsNullOrEmpty(search) || i.Opis.ToLower().Contains(search.ToLower())).ToList();
    }

    public Izvodjac DodajIzvodjaca(Izvodjac entity) {
        using (var context = new SqlDbContext()) {
            context.Set<Izvodjac>();
            foreach (var zanr in entity.Zanrevi) {
                context.Attach(zanr);
            }
            foreach (var multimedijalniSadrzaj in entity.MultimedijalniSadrzaji) {
                context.Attach(multimedijalniSadrzaj);
            }
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }
    }
}