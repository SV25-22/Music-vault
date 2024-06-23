using MusicVault.Backend.BuildingBlocks.Storage;
using System.Collections.Generic;

namespace MusicVault.Backend.Model;

public class Reklama: IDAble {
    public List<Izvodjac> Izvodjaci { get; }
    public MultimedijalniSadrzaj.MultimedijalniSadrzaj MultimedijalniSadrzaj { get; }
    public double Cena { get; }
    public Reklama() { }

    public Reklama(MultimedijalniSadrzaj.MultimedijalniSadrzaj multimedijalniSadrzaj, double cena) {
        Izvodjaci = new();
        MultimedijalniSadrzaj = multimedijalniSadrzaj;
        Cena = cena;
    }

    public void DodajIzvodjaca(Izvodjac izvodjac) {
        Izvodjaci.Add(izvodjac);
    } 
}