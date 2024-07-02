using MusicVault.Backend.Controllers;
using MusicVault.Backend.Model.Enums;
using MusicVault.Frontend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MusicVault.Frontend;

public partial class RegistrationWindow : Window {
    private readonly KorisnikController korisnikController;
    public KorisnikDTO Korisnik { get; set; }
    public static IEnumerable<Pol> PolVrednosti => Enum.GetValues(typeof(Pol)).Cast<Pol>();

    public RegistrationWindow(KorisnikController korisnikController) {
        InitializeComponent();

        this.korisnikController = korisnikController;
        Korisnik = new();
        DataContext = this;

        GodRodjenjaPicker.DisplayDateEnd = DateTime.Now.AddYears(-10);
        GodRodjenjaPicker.DisplayDateStart = new DateTime(1950, 01, 01);
    }

    private void Register_Click(object sender, RoutedEventArgs e) {
        string? validationProblem = Korisnik.ValidationProblem;

        if (!string.IsNullOrEmpty(validationProblem)) {
            MessageBox.Show("Nije moguce registrovati se. " + validationProblem, "Greska registracije", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (korisnikController.RegistrujKorisnika(Korisnik.ToKorisnik()) != null) {
            MessageBox.Show("Korisnik uspesno registrovan.", "Registracija uspesna", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        } else {
            MessageBox.Show("Nije moguce registrovati se. Mail je vec u upotrebi", "Greska registracije", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BirthdayPicker_PreviewTextInput(object sender, TextCompositionEventArgs e) {
        if (!int.TryParse(e.Text, out _) && e.Text != ".")
            e.Handled = true;
    }

    private void LozinkaBox_LozinkaChanged(object sender, RoutedEventArgs e) {
        ((dynamic)DataContext).Korisnik.Lozinka = ((PasswordBox)sender).Password;
    }
}
