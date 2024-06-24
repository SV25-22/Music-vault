using MusicVault.Backend.BuildingBlocks.Controller;
using MusicVault.Backend.Model;
using MusicVault.Backend.Repositories;

namespace MusicVault.Backend.Controllers;
public class RecenzijaController : GenericController<Recenzija, RecenzijaRepository> {
    public RecenzijaController(RecenzijaRepository repository) : base(repository) { }
}