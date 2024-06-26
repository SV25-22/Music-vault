using Microsoft.VisualBasic;
using MusicVault.Backend.BuildingBlocks.Storage;
using System;
using System.Collections.Generic;

namespace MusicVault.Backend.Model;

public class Glasanje : IDAble {
    public DateOnly PocetakGlasanja { get; set; }
    public DateOnly KrajGlasanja { get; set; }
    public bool Aktivno { get; set; }
    public string Naziv { get; set; }
    public ICollection<Glas> Glasovi { get; set; }
    public ICollection<MuzickiSadrzaj.MuzickiSadrzaj> OpcijeZaGlasanje { get; set; }

    public Glasanje() { }

    public Glasanje(DateOnly pocetakGlasanja, DateOnly krajGlasanja, bool aktivno, string naziv) {
        PocetakGlasanja = pocetakGlasanja;
        KrajGlasanja = krajGlasanja;
        Aktivno = aktivno;
        Naziv = naziv;
    }

    public void DodajGlas(Glas glas) {
        Glasovi.Add(glas);
    }

    public void DodajOpcijuZaGlasanje(MuzickiSadrzaj.MuzickiSadrzaj muzickiSadrzaj) {
        OpcijeZaGlasanje.Add(muzickiSadrzaj);
    }
}