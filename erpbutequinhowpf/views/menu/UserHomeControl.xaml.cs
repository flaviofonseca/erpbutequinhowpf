using System.Windows;
using System.Windows.Controls;


namespace erpbutequinhowpf.views.menu
{
    public partial class UserHomeControl : UserControl
    {
        public UserHomeControl()
        {
            InitializeComponent();
        }

        private void btnOpenCadastroCliente(object sender, RoutedEventArgs e)
        {
            new CadastroCliente().Show();
        }

        private void btnOpenCadastroFuncionario(object sender, RoutedEventArgs e)
        {
            new CadastroFuncionario().Show();
        }
    }
}
