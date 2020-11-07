using erpbutequinhowpf.ViewModel;
using System;
using System.Windows;

namespace erpbutequinhowpf.views
{

    public partial class PesquisaCliente : Window
    {

        private ClienteViewModel clienteViewModel;

        public PesquisaCliente()
        {
            InitializeComponent();

            clienteViewModel = new ClienteViewModel();
            var clientes = clienteViewModel.FindAll();

            dataGridCliente.ItemsSource = clientes;
        }

        private void EditarClienteClick(object sender, RoutedEventArgs e)
        {
            if (dataGridCliente.SelectedValue != null)
            {
                try
                {
                    Cliente clienteSelecionado = (Cliente)dataGridCliente.SelectedValue;
                    Close();
                    var cliente = clienteViewModel.ConsultarPorId(clienteSelecionado.Id);
                    var cadastroCliente = new CadastroCliente();
                    cadastroCliente.Cliente = cliente;
                    cadastroCliente.EditarCliente();
                    cadastroCliente.Show();
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("Selecione um registro válido");
                }
            }
        }
    }  
}
