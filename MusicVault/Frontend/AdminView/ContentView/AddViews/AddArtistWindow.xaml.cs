using MusicVault.Backend.Controllers;
using MusicVault.Backend.Model;
using MusicVault.Frontend.CommonControls;
using MusicVault.Frontend.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicVault.Frontend.AdminView.ContentView.AddViews;

public partial class AddArtistWindow : Window {
    public ObservableCollection<MultiSelectItem> Zanrovi { get; set; } = new();
    public ObservableCollection<KorisnikDTO> Urednici { get; set; } = new();

    private readonly KorisnikController korisnikController;
    private readonly IzvodjacController izvodjacController;
    private readonly ZanrController zanrController;

    public AddArtistWindow(KorisnikController korisnikController, ZanrController zanrController, IzvodjacController izvodjacController) {
        this.izvodjacController = izvodjacController;
        this.korisnikController = korisnikController;
        this.zanrController = zanrController;

        zanrController.GetAll().ForEach(zanr => Zanrovi.Add(new() { Key = zanr.Naziv, Value = zanr, IsSelected = false }));
        korisnikController.GetUrednici().ForEach(urednik => Urednici.Add(new KorisnikDTO(urednik)));
        DataContext = this;

        InitializeComponent();
    }

    private void Add_Click(object sender, RoutedEventArgs e) {
        //string opis = OpisTxtBox.Text.Trim();
        //List<

        //Zanr? nadzanr = (Zanr?)NadzanrComboBox.SelectedValue;
        //nadzanr = string.IsNullOrEmpty(nadzanr?.Naziv) ? null : nadzanr;

        //if (string.IsNullOrEmpty(naziv)) {
        //    MessageBox.Show("Naziv ne može biti prazan!", "Greška dodavanja", MessageBoxButton.OK, MessageBoxImage.Error);
        //    return;
        //}

        //// todo fiksan id, add problem
        //zanrController.Add(new Zanr(nadzanr, naziv));
        //MessageBox.Show("Žanr uspešno dodat.", "Dodavanje uspešno", MessageBoxButton.OK, MessageBoxImage.Information);
        //Close();
    }
}
