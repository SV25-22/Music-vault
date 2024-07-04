using MusicVault.Backend.BuildingBlocks.Controller;
using MusicVault.Backend.Model.MuzickiSadrzaj;
using MusicVault.Backend.Model.Recenzija;
using MusicVault.Backend.Repositories;

namespace MusicVault.Backend.Controllers;
public class RecenzijaController : GenericController<Recenzija, RecenzijaRepository> {
    public RecenzijaController() { }

    public void DodajRecenziju(Recenzija entity) {
        repository.DodajRecenziju(entity);
        Subject.NotifyObservers();
    }

    public Recenzija GetEager(int id) {
        return repository.GetEager(id);
    }
}