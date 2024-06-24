﻿using MusicVault.Backend.BuildingBlocks.Controller;
using MusicVault.Backend.Model;
using MusicVault.Backend.Repositories;

namespace MusicVault.Backend.Controllers;
public class GlasController : GenericController<Glas, GlasRepository> {
    public GlasController(GlasRepository repository) : base(repository) { }
}
