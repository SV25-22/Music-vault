using MusicVault.Frontend.CommonControls;
using System.Collections.ObjectModel;
using MusicVault.Backend.Controllers;
using System.Collections.Generic;
using MusicVault.Backend.Model;
using MusicVault.Frontend.DTO;
using System.Windows;
using System.Linq;

namespace MusicVault.Frontend.AdminView.ContentView.AddViews;

public partial class AddArtistWindow : Window {
    public ObservableCollection<MultiSelectItem> Zanrovi { get; set; } = new();
    public ObservableCollection<KorisnikDTO> Urednici { get; set; } = new();
    private readonly IzvodjacController izvodjacController;

    public AddArtistWindow(KorisnikController korisnikController, ZanrController zanrController, IzvodjacController izvodjacController) {
        zanrController.GetAll().ForEach(zanr => Zanrovi.Add(new() { Key = zanr.Naziv, Value = zanr, IsSelected = false }));
        korisnikController.GetUrednici().ForEach(urednik => Urednici.Add(new KorisnikDTO(urednik)));
        this.izvodjacController = izvodjacController;
        DataContext = this;

        InitializeComponent();
    }

    private void Add_Click(object sender, RoutedEventArgs e) {
        string opis = OpisTxtBox.Text.Trim();
        List<Zanr?> zanrovi = Zanrovi.Where(zanr => zanr.IsSelected).Select(zanr => (Zanr?)zanr.Value).ToList();

        if (string.IsNullOrEmpty(opis)) {
            MessageBox.Show("Opis ne može biti prazan!", "Greška dodavanja", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        Izvodjac izvodjac = new(opis);
        zanrovi.ForEach(zanr => { if (zanr != null) izvodjac.DodajZanr(zanr); });

        // dodavanje prazne recenzije

        // todo fiksan id, add problem
        izvodjacController.Add(izvodjac);
        MessageBox.Show("Izvođač uspešno dodat.", "Dodavanje uspešno", MessageBoxButton.OK, MessageBoxImage.Information);
        Close();
    }
}
