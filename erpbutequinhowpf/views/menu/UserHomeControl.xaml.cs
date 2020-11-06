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
            // TODO open cadastro de cliente
            new CadastroCliente().Show();
        }

        private void btnOpenCadastroFuncionario(object sender, RoutedEventArgs e)
        {
            // TODO open cadastro de funcionario
        }
    }
}
