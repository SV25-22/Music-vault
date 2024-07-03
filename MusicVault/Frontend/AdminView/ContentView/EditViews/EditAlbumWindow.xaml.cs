using MusicVault.Backend.Model.MuzickiSadrzaj;
using MusicVault.Frontend.CommonControls;
using MusicVault.Backend.Controllers;
using MusicVault.Backend.Model.Enums;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using MusicVault.Backend.Model;
using System.Windows;
using System.Linq;
using System;

namespace MusicVault.Frontend.AdminView.ContentView;

public partial class EditAlbumWindow : Window {
    public static IEnumerable<NacinCuvanja> NaciniCuvanja => Enum.GetValues(typeof(NacinCuvanja)).Cast<NacinCuvanja>();
    public ObservableCollection<MultiSelectItem> Izvodjaci { get; set; } = new();
    public ObservableCollection<MultiSelectItem> Zanrovi { get; set; } = new();

    private readonly MuzickiSadrzajController muzickiSadrzajController;
    private readonly IzvodiController izvodiController;
    private readonly Album album;

    public EditAlbumWindow(Album album, ZanrController zanrController, IzvodjacController izvodjacController, IzvodiController izvodiController, MuzickiSadrzajController muzickiSadrzajController) {
        zanrController.GetAll().ForEach(zanr => Zanrovi.Add(new() { Key = zanr.Naziv, Value = zanr, IsSelected = album.Zanrevi?.Any(z => z.Id == zanr.Id) ?? false }));
        izvodjacController.GetAll().ForEach(izvodjac => Izvodjaci.Add(new() {
            Key = izvodjac.Opis,
            Value = izvodjac,
            IsSelected = izvodiController.GetAll().Any(i => i.Izvodjac.Id == izvodjac.Id && i.MuzickiSadrzaj.Id == album.Id)
        }));
        this.muzickiSadrzajController = muzickiSadrzajController;
        this.izvodiController = izvodiController;
        this.album = album;
        DataContext = this;

        InitializeComponent();
        OpisTxtBox.Text = album.Opis;
        NacinComboBox.SelectedValue = album.Tip;
    }

    private void Add_Click(object sender, RoutedEventArgs e) {
        string opis = OpisTxtBox.Text.Trim();
        List<Izvodjac?> izvodjaci = Izvodjaci.Where(izvodjac => izvodjac.IsSelected).Select(izvodjac => (Izvodjac?)izvodjac.Value).ToList();
        List<Zanr?> zanrovi = Zanrovi.Where(zanr => zanr.IsSelected).Select(zanr => (Zanr?)zanr.Value).ToList();

        if (string.IsNullOrEmpty(opis)) {
            MessageBox.Show("Opis ne može biti prazan!", "Greška dodavanja", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        album.Opis = opis;
        album.Zanrevi.Clear();
        album.Tip = (NacinCuvanja)NacinComboBox.SelectedValue;
        zanrovi.ForEach(zanr => { if (zanr != null) album.DodajZanr(zanr); });
        // todo moguć problem ako dodaje duplikate, problem za rešiti kasnije kad se bude testiralo
        izvodjaci.ForEach(izvodjac => { if (izvodjac != null) izvodiController.Add(new Izvodi("izvođač", izvodjac, album)); });

        // todo fiksan id, add problem
        muzickiSadrzajController.Update(album);
        MessageBox.Show("Album uspešno izmenjen.", "Izmena uspešna", MessageBoxButton.OK, MessageBoxImage.Information);
        Close();
    }
}
