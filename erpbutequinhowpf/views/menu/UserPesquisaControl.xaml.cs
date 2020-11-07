using System.Windows;
using System.Windows.Controls;

namespace erpbutequinhowpf.views.menu
{

    public partial class UserPesquisaControl : UserControl
    {
        public UserPesquisaControl()
        {
            InitializeComponent();
        }

        private void btnOpenPesquisaCliente(object sender, RoutedEventArgs e)
        {
            new PesquisaCliente().Show();
        }

        private void btnOpenPesquisaFuncionario(object sender, RoutedEventArgs e)
        {
             new PesquisaFuncionario().Show();
        }

    }
}
