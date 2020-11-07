using erpbutequinhowpf.ViewModel;
using System.Windows;

namespace erpbutequinhowpf.views
{

    public partial class CadastroFuncionario : Window
    {
        private FuncionarioViewModel funcionarioViewModel;
        private Funcionario funcionario;

        internal Funcionario Funcionario { get => funcionario; set => funcionario = value; }

        public CadastroFuncionario()
        {
            InitializeComponent();
            funcionarioViewModel = new FuncionarioViewModel();
            Funcionario = new Funcionario();
            DataContext = Funcionario;
        }

        public void EditarFuncionario()
        {
            DataContext = Funcionario;
        }

        private void SalvarCliente(object sender, RoutedEventArgs e)
        {
            funcionarioViewModel.SalvarFuncionario(Funcionario);
            _ = MessageBox.Show("Salvo com sucesso!!!");
        }

        private void RemoverCliente(object sender, RoutedEventArgs e)
        {
            funcionarioViewModel.RemoverFuncionario(Funcionario);
        }
    }
}
