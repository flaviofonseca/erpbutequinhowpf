using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace erpbutequinhowpf.Model
{
    class Insert:Conexao
    {
        
        public string sql_insert { get; set; }

        protected void Inserir()
        {
            try
            {
                string bloqueio = "SELECT cpf FROM cliente WHERE cpf = @cpf";

                Conexao cn = new Conexao();

                if (cn.cpf != bloqueio) // Verificar se não existe um cpf igual 
                {

                    sql_insert = "insert into cliente (idcliente, nome, cpf, cnpj, telefone, logradouro, numero, cidade, estado, bairro, cep, complemento) values (@idcliente, @nome, @cpf, @cnpj, @telefone, @logradouro, @numero, @cidade, @estado, @bairro, @cep, @complemento)";

                    cn.comando = new MySqlCommand(sql_insert, Conexao_Banco());

                    cn.comando.Parameters.AddWithValue("@idcliente", null);

                    cn.comando.Parameters.AddWithValue("@nome", cn.nome);

                    if(cn.cpf.Length == 11) { //definindo a quantidade minima de caracteres 
                        cn.comando.Parameters.AddWithValue("@cpf", cn.cpf);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do CPf invalido");
                    }

                    if(cn.cnpj.Length == 14) { 
                        cn.comando.Parameters.AddWithValue("@cnpj", cn.cnpj);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do CNPJ invalido");
                    }

                    if(cn.telefone.Length == 11) { 
                        cn.comando.Parameters.AddWithValue("@telefone", cn.telefone);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do Telefone invalido");
                    }

                    cn.comando.Parameters.AddWithValue("@logradouro", cn.logradouro);

                    if(cn.numero.Length >= 1)
                    {
                        cn.comando.Parameters.AddWithValue("@numero", cn.numero);
                    }
                    else
                    {
                        MessageBox.Show("Numero da residencia abaixo do permitido");
                    }

                    cn.comando.Parameters.AddWithValue("@cidade", cn.cidade);

                    if (cn.estado.Length == 2) { 
                        cn.comando.Parameters.AddWithValue("@estado", cn.estado);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do Estado (UF) invalido");
                    }
                    cn.comando.Parameters.AddWithValue("@bairro", cn.bairro);

                    if(cn.cep.Length == 8) { 
                        cn.comando.Parameters.AddWithValue("@cep", cn.cep);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do CEP invalido");
                    }

                    cn.comando.Parameters.AddWithValue("@complemento", cn.complemento);

                    connection.Open();
                    cn.comando.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Esse CPF ja foi cadastrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                connection = null;
                comando = null;
            }
        }
    }
}
