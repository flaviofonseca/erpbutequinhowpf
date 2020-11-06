﻿namespace erpbutequinhowpf.ViewModel
{
    class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfOuCnpj { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public override string ToString() => "Nome " + Nome + " CPF " + CpfOuCnpj;
    }
}
