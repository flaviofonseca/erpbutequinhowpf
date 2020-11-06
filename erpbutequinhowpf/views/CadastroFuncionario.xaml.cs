using erpbutequinhowpf.ViewModel;
using System.Windows;

namespace erpbutequinhowpf.views
{

    public partial class CadastroFuncionario : Window
    {
        private FuncionarioViewModel funcionarioViewModel;
        private Funcionario funcionario;

        public CadastroFuncionario()
        {
            InitializeComponent();
            funcionarioViewModel = new FuncionarioViewModel();
            funcionario = new Funcionario();
            DataContext = funcionario;
        }

        private void SalvarCliente(object sender, RoutedEventArgs e)
        {
            funcionarioViewModel.SalvarFuncionario(funcionario);
        }

        private void RemoverCliente(object sender, RoutedEventArgs e)
        {
            funcionarioViewModel.RemoverFuncionario(funcionario);
        }
    }
}
