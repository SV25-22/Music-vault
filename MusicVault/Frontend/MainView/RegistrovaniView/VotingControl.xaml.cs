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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicVault.Frontend.MainView.RegistrovaniView;

public partial class VotingControl : UserControl {
    public VotingControl() {
        DataContext = this;
        InitializeComponent();
    }

    private void OdgovorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

    }

    private void GlasanjeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

    }

    private void odgBtn_Click(object sender, RoutedEventArgs e) {

    }
}
