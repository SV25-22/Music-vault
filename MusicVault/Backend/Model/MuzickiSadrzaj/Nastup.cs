using MusicVault.Backend.Model.Enums;

namespace MusicVault.Backend.Model.MuzickiSadrzaj;

public class Nastup : MuzickiSadrzaj {
    public NacinCuvanja Tip;

    public Nastup() { }

    public Nastup(NacinCuvanja tip) {
        Tip = tip;
    }
}