using MusicVault.Backend.BuildingBlocks.Controller;
using MusicVault.Backend.Model;
using MusicVault.Backend.Repositories;

namespace MusicVault.Backend.Controllers;
public class IzvodiController : GenericController<Izvodi, IzvodiRepository> {
    public IzvodiController(IzvodiRepository repository) : base(repository) { }
}