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
            var funcionarios = funcionarioViewModel.FindAll();

            dataGridFuncionario.ItemsSource = funcionarios;
        }

        private void EditarFuncionarioClick(object sender, RoutedEventArgs e)
        {
            if(dataGridFuncionario.SelectedValue != null)
            {
                Funcionario funcionarioSelecionado;
                try
                {
                    funcionarioSelecionado = (Funcionario)dataGridFuncionario.SelectedValue;
                    Close();
                    var funcionario = funcionarioViewModel.ConsultarPorId(funcionarioSelecionado.Id);
                    var cadastroFuncionario = new CadastroFuncionario();
                    cadastroFuncionario.Funcionario = funcionario;
                    cadastroFuncionario.EditarFuncionario();
                    cadastroFuncionario.Show();
                }
                catch (InvalidCastException ex)
                {
                    MessageBox.Show("Selecione um registro válido");
                }
                               
            }            

        }

    }
      
}
