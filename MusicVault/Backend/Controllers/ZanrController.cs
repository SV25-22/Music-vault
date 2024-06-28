using MusicVault.Backend.BuildingBlocks.Controller;
using MusicVault.Backend.Model;
using MusicVault.Backend.Repositories;

namespace MusicVault.Backend.Controllers;
public class ZanrController : GenericController<Zanr, ZanrRepository> {
    public ZanrController() { }
}