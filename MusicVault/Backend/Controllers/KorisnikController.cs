using MusicVault.Backend.BuildingBlocks.Controller;
using MusicVault.Backend.Model;
using MusicVault.Backend.Repositories;

namespace MusicVault.Backend.Controllers;
public class KorisnikController : GenericController<Korisnik, KorisnikRepository> {
    public KorisnikController(KorisnikRepository repository) : base(repository) { }
}