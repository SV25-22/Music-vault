using MusicVault.Backend.BuildingBlocks.Controller;
using MusicVault.Backend.Model.MuzickiSadrzaj;
using MusicVault.Backend.Repositories;
using System.Collections.Generic;

namespace MusicVault.Backend.Controllers;
public class MuzickiSadrzajController : GenericController<MuzickiSadrzaj, MuzickiSadrzajRepository> {
    public MuzickiSadrzajController() { }
    
    public List<Delo> GetDela(string search = "") => MuzickiSadrzajRepository.GetDela(search);

    public List<Album> GetAlbumi(string search = "") => MuzickiSadrzajRepository.GetAlbumi(search);

    public List<Nastup> GetNastupi(string search = "") => MuzickiSadrzajRepository.GetNastupi(search);

    public void DodajMuzickiSadrzaj(MuzickiSadrzaj entity) {
        repository.Add(entity);
        Subject.NotifyObservers();
    }
}