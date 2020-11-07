using erpbutequinhowpf.ViewModel;
using System;
using System.Windows;

namespace erpbutequinhowpf.views
{

    public partial class PesquisaFuncionario : Window
    {

        private FuncionarioViewModel funcionarioViewModel;

        public PesquisaFuncionario()
        {
            InitializeComponent();

            funcionarioViewModel = new FuncionarioViewModel();

            dataGridFuncionario.ItemsSource = new[]
            {
                new FuncionarioGrid(1, "Flavio", "62 985410988", "003.419.211-57")
            };
        }

        private void EditarFuncionarioClick(object sender, RoutedEventArgs e)
        {
            FuncionarioGrid funcionarioSelecionado = (FuncionarioGrid)dataGridFuncionario.SelectedValue;
            Console.WriteLine(funcionarioSelecionado.Codigo);
            Close();
            var funcionario = funcionarioViewModel.ConsultarPorId(funcionarioSelecionado.Codigo);

        }

    }

    public class FuncionarioGrid
    {
        private int codigo;
        private string nome;
        private string telefone;
        private string cpf;

        public FuncionarioGrid(int codigo, string nome, string telefone, string cpf)
        {
            Codigo = codigo;
            Nome = nome;
            Telefone = telefone;
            Cpf = cpf;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Cpf { get => cpf; set => cpf = value; }
    }
}
