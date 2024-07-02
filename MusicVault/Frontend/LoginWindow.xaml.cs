using MusicVault.Backend.Controllers;
using MusicVault.Backend.Model.Enums;
using System.Windows;

namespace MusicVault.Frontend;

public partial class LoginWindow : Window {
    private KorisnikController korisnikController = new();
    private IzvodjacController izvodjacController = new();
    private MuzickiSadrzajController muzickiSadrzajController = new();
    private RecenzijaController recenzijaController = new();
    private GlasanjeController glasanjeController = new();
    private GlasController glasController = new();
    private ZanrController zanrController = new();

    public LoginWindow() {
        InitializeComponent();
    }

    private void ShowMe(object? sender, System.EventArgs e) => Show();

    private void LoginButton_Click(object sender, RoutedEventArgs e) {
        if (emailBox.Text == "admin" && passwordBox.Password == "admin") {
            AdminWindow adminWindow = new();
            OpenUserWindow(adminWindow);
        } else if (korisnikController.UlogujSe(emailBox.Text, passwordBox.Password) is var korisnik && korisnik != null) {
            switch (korisnik.Tip) {
                case TipKorisnika.Registrovani: {
                    KorisnikWindow korisnikWindow = new();
                    OpenUserWindow(korisnikWindow);
                    break;
                }
                case TipKorisnika.Urednik: {
                    UrednikWindow urednikWindow = new();
                    OpenUserWindow(urednikWindow);
                    break;
                }
            }
        } else
            MessageBox.Show("Ne postoji korisnik sa tim kredencijalima!", "Greska logovanja", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    private void OpenUserWindow(Window window) {
        passwordBox.Password = string.Empty;
        emailBox.Text = string.Empty;
        window.Closed += ShowMe;
        window.Show();
        Hide();
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e) {
        RegistrationWindow rw = new(korisnikController);
        rw.Closed += ShowMe;
        rw.Show();
        Hide();
    }
}
