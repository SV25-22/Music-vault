using MusicVault.Backend.BuildingBlocks.Controller;
using MusicVault.Backend.Repositories;
using System.Collections.Generic;
using MusicVault.Backend.Model;

namespace MusicVault.Backend.Controllers;
public class IzvodjacController : GenericController<Izvodjac, IzvodjacRepository> {
    public IzvodjacController() { }

    public List<Izvodjac> Search(string search = "") => IzvodjacRepository.Search(search);
}