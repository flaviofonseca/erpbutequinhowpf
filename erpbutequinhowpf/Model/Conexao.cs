using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace erpbutequinhowpf.Model
{
    class Conexao
    {

        public int idcliente { get; set; }
        public string nome { get; set; }
        public string  cpf{ get; set; }
        public string cnpj { get; set; }
        public string telefone { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

        public MySqlConnection connection { get; set; }
        public MySqlCommand comando { get; set; }
        public MySqlDataAdapter da { get; set; }
        public MySqlDataReader  dr { get; set; }

        public Conexao()
        {
        }

        public Conexao(string nome, string cpf, string cnpj, string telefone, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.cnpj = cnpj;
            this.telefone = telefone;
            this.logradouro = logradouro;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.cep = cep;
            this.cidade = cidade;
            this.estado = estado;
        }


        protected MySqlConnection Conexao_Banco()
        {
            connection = new MySqlConnection("Server=localhost;Database=cadastro_cliente;Uid=root;Pwd=kekinho13;");
            return connection;
        }
    }
}
