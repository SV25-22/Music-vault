using MusicVault.Backend.BuildingBlocks.Observer;
using MusicVault.Backend.Controllers;
using MusicVault.Frontend.AdminView;
using System.Collections.ObjectModel;
using MusicVault.Frontend.DTO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace MusicVault.Frontend.MainView.ContentView;

public partial class SearchControl : UserControl, IObserver {
    public static string[] TipoviSadrzaja { get; set; } = new string[] { "dela", "albumi", "nastupi", "izvođači" };
    public ObservableCollection<SadrzajDTO> Sadrzaj { get; set; } = new();

    private MuzickiSadrzajController muzickiSadrzajController;
    private IzvodjacController izvodjacController;

    public SearchControl() {
        DataContext = this;
        InitializeComponent();
    }

    private void OnControlLoaded(object sender, RoutedEventArgs e) {
        AdminWindow? mainWindow = Window.GetWindow(this) as AdminWindow;
        muzickiSadrzajController = mainWindow?.muzickiSadrzajController ?? new();
        izvodjacController = mainWindow?.izvodjacController ?? new();
        muzickiSadrzajController.Subscribe(this);
        izvodjacController.Subscribe(this);
        RefreshDataGrid();
    }

    private void SadrzajDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
        if (TypeComboBox.SelectedValue.ToString() == "dela")
            new TrackWindow().Show();
        else if (TypeComboBox.SelectedValue.ToString() == "albumi")
            new AlbumWindow().Show();
        else if (TypeComboBox.SelectedValue.ToString() == "nastupi")
            new NastupWindow().Show();
        else if (TypeComboBox.SelectedValue.ToString() == "izvođači")
            new ArtistWindow().Show();
    }

    private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => RefreshDataGrid();

    private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e) => RefreshDataGrid();

    public void Update() => RefreshDataGrid();

    public void RefreshDataGrid() {
        Sadrzaj.Clear();
        string search = SearchTxtBox.Text;

        if (TypeComboBox.SelectedValue.ToString() == "dela")
            muzickiSadrzajController?.GetDela(search).ForEach(delo => Sadrzaj.Add(new SadrzajDTO(delo)));
        else if (TypeComboBox.SelectedValue.ToString() == "albumi")
            muzickiSadrzajController?.GetAlbumi(search).ForEach(album => Sadrzaj.Add(new SadrzajDTO(album)));
        else if (TypeComboBox.SelectedValue.ToString() == "nastupi")
            muzickiSadrzajController?.GetNastupi(search).ForEach(nastup => Sadrzaj.Add(new SadrzajDTO(nastup)));
        else if (TypeComboBox.SelectedValue.ToString() == "izvođači")
            izvodjacController?.Search(search).ForEach(izvodjac => Sadrzaj.Add(new SadrzajDTO(izvodjac)));
    }
}
