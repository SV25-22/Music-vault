using MusicVault.Backend.Controllers;
using System.Windows.Controls;
using System.Windows;

namespace MusicVault.Frontend.MainView.RegistrovaniView.UrednikView;

public partial class CreateContentControl : UserControl {
    private MuzickiSadrzajController muzickiSadrzajController;
    private RecenzijaController recenzijaController;
    private KorisnikController korisnikController;
    private IzvodjacController izvodjacController;
    private ZanrController zanrController;

    public CreateContentControl() {
        DataContext = this;
        InitializeComponent();
    }

    private void OnControlLoaded(object sender, RoutedEventArgs e) {
        MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
        muzickiSadrzajController = mainWindow?.muzickiSadrzajController ?? new();
        recenzijaController = mainWindow?.recenzijaController ?? new();
        korisnikController = mainWindow?.korisnikController ?? new();
        izvodjacController = mainWindow?.izvodjacController ?? new();
        zanrController = mainWindow?.zanrController ?? new();
    }

    private void AddAlbumBtn_Click(object sender, RoutedEventArgs e) {
        new AddAlbumWindow(korisnikController, zanrController, izvodjacController, muzickiSadrzajController, recenzijaController).Show();
    }

    private void AddDeloBtn_Click(object sender, RoutedEventArgs e) {
        new AddTrackWindow(korisnikController, zanrController, izvodjacController, muzickiSadrzajController, recenzijaController).Show();
    }

    private void AddNastupBtn_Click(object sender, RoutedEventArgs e) {
        new AddNastupWindow(korisnikController, zanrController, izvodjacController, muzickiSadrzajController, recenzijaController).Show();
    }

    private void AddIzvodjacBtn_Click(object sender, RoutedEventArgs e) {
        new AddArtistWindow(zanrController, izvodjacController).Show();
    }

    private void AddRecenzijaBtn_Click(object sender, RoutedEventArgs e) {

    }
}
