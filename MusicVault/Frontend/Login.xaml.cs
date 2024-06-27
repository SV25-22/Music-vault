﻿using MusicVault.Backend.Controllers;
using MusicVault.Backend.Repositories;
using System;
using System.Collections.Generic;
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

namespace MusicVault.Frontend {
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window {
        public Login() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            SqlDbContext sqlDbContext = new SqlDbContext();

            KorisnikRepository korisnikRepository = new KorisnikRepository(sqlDbContext);

            KorisnikController korisnikController = new KorisnikController(korisnikRepository);

            if (korisnikController.RegistrujKorisnika("a", "b", "mail", "123", DateOnly.MinValue, Backend.Model.Enums.Pol.Musko, "123") == null) {
                MessageBox.Show("Mail vec iskoristen");
            }

            Backend.Model.Korisnik? ulogovanKorisnik = korisnikController.UlogujSe(Username.Text, Password.Text);
            if (ulogovanKorisnik != null) {
                MessageBox.Show("Uspeh" + ulogovanKorisnik.Lozinka);
            }
        }
    }
}
