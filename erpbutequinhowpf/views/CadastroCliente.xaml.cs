using erpbutequinhowpf.ViewModel;
using System;
using System.Windows;

namespace erpbutequinhowpf.views
{
    /// <summary>
    /// Lógica interna para CadastroCliente.xaml
    /// </summary>
    public partial class CadastroCliente : Window
    {
        private ClienteViewModel clienteViewModel;
        private Cliente cliente;
        internal Cliente Cliente { get => cliente; set => cliente = value; }

        public CadastroCliente()
        {
            InitializeComponent();
            clienteViewModel = new ClienteViewModel();
            cliente = new Cliente();
            DataContext = cliente;
        }

        private void SalvarCliente(object sender, RoutedEventArgs e)
        {
            clienteViewModel.SalvarCliente(cliente);
        }

        internal void EditarCliente()
        {
            DataContext = cliente;
        }

        private void RemoverCliente(object sender, RoutedEventArgs e)
        {
            clienteViewModel.RemoverCliente(cliente);
        }
    }
}
