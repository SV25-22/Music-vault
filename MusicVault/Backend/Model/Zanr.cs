using MusicVault.Backend.BuildingBlocks.Storage;

namespace MusicVault.Backend.Model;

public class Zanr : IDAble {
    public Zanr? NadZanr { get; }
    public string Naziv { get; set; }

    public Zanr() { }

    public Zanr(Zanr? nadZanr, string naziv) {
        NadZanr = nadZanr;
        Naziv = naziv;
    }
}