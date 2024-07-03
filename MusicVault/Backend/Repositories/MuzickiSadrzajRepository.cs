using MusicVault.Backend.BuildingBlocks.Storage;
using MusicVault.Backend.Model.MuzickiSadrzaj;
using System.Collections.Generic;
using System.Linq;

namespace MusicVault.Backend.Repositories;

public class MuzickiSadrzajRepository : SQLGenericRepository<MuzickiSadrzaj> {
    public static List<Delo> GetDela(string search = "") {
        using var context = new SqlDbContext();
        return context.Delo.Where(d => string.IsNullOrEmpty(search) || d.Opis.ToLower().Contains(search.ToLower())).ToList();
    }

    public static List<Album> GetAlbumi(string search = "") {
        using var context = new SqlDbContext();
        return context.Album.Where(a => string.IsNullOrEmpty(search) || a.Opis.ToLower().Contains(search.ToLower())).ToList();
    }

    public static List<Nastup> GetNastupi(string search = "") {
        using var context = new SqlDbContext();
        return context.Nastup.Where(n => string.IsNullOrEmpty(search) || n.Opis.ToLower().Contains(search.ToLower())).ToList();
    }
}