using erpbutequinhowpf.Model;
using System;
using System.Collections;

namespace erpbutequinhowpf.ViewModel
{
    
    class ClienteViewModel
    {
        private ClienteModel clienteModel;

        public ClienteViewModel()
        {
            this.clienteModel = new ClienteModel();
        }

        internal void SalvarCliente(Cliente cliente)
        {
            this.clienteModel.Inserir(cliente);
        }

        internal ArrayList FindAll()
        {
            return clienteModel.FindAll();
        }

        internal void RemoverCliente(Cliente cliente)
        {
            this.clienteModel.Delete(cliente.Id);
        }

        internal Cliente ConsultarPorId(int codigo)
        {
            return this.clienteModel.FindByID(codigo);
        }
    }
}

