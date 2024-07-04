﻿using MusicVault.Backend.Model.Recenzija;

namespace MusicVault.Frontend.DTO;

public class RecenzijaDTO {
    public int Id { get; set; }
    public Recenzija Recenzija { get; set; }
    public string Opis { get { return Recenzija.MuzickiSadrzaj.GetType().Name + ": " + Recenzija.MuzickiSadrzaj.Opis; } }

    public RecenzijaDTO(Recenzija recenzija) {
        Id = recenzija.Id;
        Recenzija = recenzija;
    }
}
