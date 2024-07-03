using MusicVault.Backend.Model.MuzickiSadrzaj;
using System.Windows.Media.Imaging;
using MusicVault.Backend.Model;
using System.ComponentModel;
using System;

namespace MusicVault.Frontend.DTO;

public class SadrzajDTO {
    public int Id { get; set; }
    public BitmapImage Slika { get; set; }
    private string opis = "";
    public string Opis { get { return opis; } set { opis = value; OnPropertyChanged($"{nameof(Opis)}"); } }

    public string Error => "";
    public event PropertyChangedEventHandler? PropertyChanged;

    public SadrzajDTO() { }

    public SadrzajDTO(MuzickiSadrzaj sadrzaj) {
        Id = sadrzaj.Id;
        Opis = sadrzaj.Opis;
        if (sadrzaj is Delo)
            Slika = new BitmapImage(new Uri("pack://application:,,,/Resources/track.png"));
        else if (sadrzaj is Album)
            Slika = new BitmapImage(new Uri("pack://application:,,,/Resources/album.png"));
        else if (sadrzaj is Nastup)
            Slika = new BitmapImage(new Uri("pack://application:,,,/Resources/concert.png"));
    }

    public SadrzajDTO(Izvodjac izvodjac) {
        Id = izvodjac.Id;
        Opis = izvodjac.Opis;
        Slika = new BitmapImage(new Uri("pack://application:,,,/Resources/artist.png"));
    }

    private readonly string[] _validatedProperties = {
        $"{nameof(Opis)}"
    };

    public string? ValidationProblem {
        get {
            foreach (var property in _validatedProperties)
                if (!string.IsNullOrEmpty(this[property]))
                    return this[property];

            return null;
        }
    }

    public string this[string columnName] {
        get {
            switch (columnName) {
                case $"{nameof(Opis)}": {
                    if (string.IsNullOrEmpty(Opis))
                        return "Opis je potreban.";
                    break;
                }
            }
            return "";
        }
    }

    protected virtual void OnPropertyChanged(string name) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
