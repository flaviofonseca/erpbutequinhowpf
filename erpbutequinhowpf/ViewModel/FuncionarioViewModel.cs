using erpbutequinhowpf.Model;
using System;

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

        internal void RemoverFuncionario(Funcionario funcionario)
        {
            this.funcionarioModel.Delete(funcionario.Id);
        }

        internal void ConsultarPorId(int codigo)
        {
            throw new NotImplementedException();
        }
    }

}
