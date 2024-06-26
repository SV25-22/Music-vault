using MusicVault.Backend.Controllers;
using MusicVault.Backend.Model;
using System;
using System.Collections.Generic;

namespace MusicVault.Backend.Common;

public class Sistem {
    public void ZavrsiSveGlasove(GlasanjeController glasanjeController) {
        List<Glasanje> svaGlasanja = glasanjeController.GetAll();

        foreach (Glasanje gl in svaGlasanja) {
            if (DateOnly.FromDateTime(DateTime.Now) > gl.KrajGlasanja) {
                glasanjeController.ZavrsiGlasanje(gl);
            }
        }
    }
}