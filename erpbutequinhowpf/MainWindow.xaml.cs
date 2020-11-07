using System.Windows;
using System.Windows.Controls;
using erpbutequinhowpf.views.menu;

namespace erpbutequinhowpf
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                   // usc = new UserHomeControl();
                    //GridMain.Children.Add(usc);
                    break;
                case "ItemCreate":
                    usc = new UserHomeControl();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemPesquisa":
                   // usc = new UserPesquisaControl();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }
    }
}
