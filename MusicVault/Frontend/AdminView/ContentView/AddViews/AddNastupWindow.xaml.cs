﻿using MusicVault.Backend.Model.MuzickiSadrzaj;
using MusicVault.Backend.Model.Recenzija;
using MusicVault.Frontend.CommonControls;
using MusicVault.Backend.Controllers;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using MusicVault.Backend.Model;
using MusicVault.Frontend.DTO;
using System.Windows;
using System.Linq;

namespace MusicVault.Frontend.AdminView.ContentView.AddViews;

public partial class AddNastupWindow : Window {
    public ObservableCollection<MultiSelectItem> Izvodjaci { get; set; } = new();
    public ObservableCollection<MultiSelectItem> Zanrovi { get; set; } = new();
    public ObservableCollection<MultiSelectItem> Albumi { get; set; } = new();
    public ObservableCollection<MultiSelectItem> Dela { get; set; } = new();
    public ObservableCollection<KorisnikDTO> Urednici { get; set; } = new();

    private readonly MuzickiSadrzajController muzickiSadrzajController;
    private readonly RecenzijaController recenzijaController;
    private readonly IzvodiController izvodiController;

    public AddNastupWindow(KorisnikController korisnikController, ZanrController zanrController, IzvodjacController izvodjacController, IzvodiController izvodiController, MuzickiSadrzajController muzickiSadrzajController, RecenzijaController recenzijaController) {
        izvodjacController.GetAll().ForEach(izvodjac => Izvodjaci.Add(new() { Key = izvodjac.Opis, Value = izvodjac, IsSelected = false }));
        muzickiSadrzajController.GetAlbumi().ForEach(album => Albumi.Add(new() { Key = album.Opis, Value = album, IsSelected = false }));
        muzickiSadrzajController.GetDela().ForEach(delo => Dela.Add(new() { Key = delo.Opis, Value = delo, IsSelected = false }));
        zanrController.GetAll().ForEach(zanr => Zanrovi.Add(new() { Key = zanr.Naziv, Value = zanr, IsSelected = false }));
        korisnikController.GetUrednici().ForEach(urednik => Urednici.Add(new KorisnikDTO(urednik)));
        this.muzickiSadrzajController = muzickiSadrzajController;
        this.recenzijaController = recenzijaController;
        this.izvodiController = izvodiController;
        DataContext = this;

        InitializeComponent();
    }

    private void Add_Click(object sender, RoutedEventArgs e) {
        string opis = OpisTxtBox.Text.Trim();
        List<Izvodjac?> izvodjaci = Izvodjaci.Where(izvodjac => izvodjac.IsSelected).Select(izvodjac => (Izvodjac?)izvodjac.Value).ToList();
        List<Album?> albumi = Albumi.Where(album => album.IsSelected).Select(album => (Album?)album.Value).ToList();
        List<Zanr?> zanrovi = Zanrovi.Where(zanr => zanr.IsSelected).Select(zanr => (Zanr?)zanr.Value).ToList();
        List<Delo?> dela = Dela.Where(delo => delo.IsSelected).Select(delo => (Delo?)delo.Value).ToList();

        if (string.IsNullOrEmpty(opis)) {
            MessageBox.Show("Opis ne može biti prazan!", "Greška dodavanja", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        Nastup nastup = new() { Opis = opis };
        zanrovi.ForEach(zanr => { if (zanr != null) nastup.DodajZanr(zanr); });
        albumi.ForEach(album => { if (album != null) nastup.DodajMuzickiSadrzaj(album); });
        dela.ForEach(delo => { if (delo != null) nastup.DodajMuzickiSadrzaj(delo); });
        izvodjaci.ForEach(izvodjac => { if (izvodjac != null) izvodiController.Add(new Izvodi("izvođač", izvodjac, nastup)); });

        // dodavanje prazne recenzije
        recenzijaController.Add(new Recenzija(((KorisnikDTO)UrednikComboBox.SelectedValue).ToKorisnik(), nastup, -1, "", false));

        // todo fiksan id, add problem
        muzickiSadrzajController.Add(nastup);
        MessageBox.Show("Nastup uspešno dodat.", "Dodavanje uspešno", MessageBoxButton.OK, MessageBoxImage.Information);
        Close();
    }
}
