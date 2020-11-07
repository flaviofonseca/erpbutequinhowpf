using erpbutequinhowpf.Model;
using System;
using System.Collections;

namespace erpbutequinhowpf.ViewModel
{
    class FuncionarioViewModel
    {
        private FuncionarioModel funcionarioModel;

        public FuncionarioViewModel()
        {
            this.funcionarioModel = new FuncionarioModel();
        }

        internal void SalvarFuncionario(Funcionario funcionario)
        {
            this.funcionarioModel.Inserir(funcionario);
        }

        internal ArrayList FindAll()
        {
           return funcionarioModel.FindAll();
        }

        internal void RemoverFuncionario(Funcionario funcionario)
        {
            this.funcionarioModel.Delete(funcionario.Id);
        }

        internal Funcionario ConsultarPorId(int codigo)
        {
            return this.funcionarioModel.FindByID(codigo);
        }
    }

}
