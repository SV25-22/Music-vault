﻿using MusicVault.Backend.BuildingBlocks.Controller;
using MusicVault.Backend.Model;
using MusicVault.Backend.Repositories;

namespace MusicVault.Backend.Controllers;
public class GlasanjeController : GenericController<Glasanje, GlasanjeRepository> {
    public GlasanjeController(GlasanjeRepository repository) : base(repository) { }

    public void ZavrsiGlasanje(Glasanje glasanje) {
        glasanje.Aktivno = false;
        Update(glasanje);

        // glasanje.ObradaRezultata();
        // todo poslati obavestenje o rezultatu adminu
    }
}