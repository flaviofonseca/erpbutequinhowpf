using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace erpbutequinhowpf.Model
{
    class Cliente_Model:Conexao
    {
        // Propriedades que receberão as informações inseridas pelo usuario e serão passada para dentro do banco

        public int idcliente { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string cnpj { get; set; }
        public string telefone { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

        // Propriedades que irão conter comandos a serem executados dentro do banco 

        public string sql_insert { get; set; }
        public string sql_update { get; set; }
        public string sql_delete { get; set; }
        public string sql_select { get; set; }
        public string sql_mostrar { get; set; }

        public Cliente_Model()
        {

        }

        public Cliente_Model(int idcliente, string nome, string cpf, string cnpj, string telefone, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            this.idcliente = idcliente;
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

        // Metodo Inserte ira realizar a inserção ods valores recebido pelo o usuario 

        protected void Inserir()
        {
            try
            {
                string bloqueio = "SELECT cpf FROM cliente WHERE cpf = @cpf";

                

                if (cpf != bloqueio) // Verificar se não existe um cpf igual 
                {

                    sql_insert = "insert into cliente (idcliente, nome, cpf, cnpj, telefone, logradouro, numero, cidade, estado, bairro, cep, complemento) values (@idcliente, @nome, @cpf, @cnpj, @telefone, @logradouro, @numero, @cidade, @estado, @bairro, @cep, @complemento)";

                    comando = new MySqlCommand(sql_insert, Conexao_Banco());

                    comando.Parameters.AddWithValue("@idcliente", null);

                    comando.Parameters.AddWithValue("@nome", nome);

                    if (cpf.Length == 11)
                    { //definindo a quantidade minima de caracteres 
                        comando.Parameters.AddWithValue("@cpf", cpf);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do CPF invalido");
                    }

                    if (cnpj.Length == 14)
                    {
                        comando.Parameters.AddWithValue("@cnpj", cnpj);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do CNPJ invalido");
                    }

                    if (telefone.Length == 11)
                    {
                        comando.Parameters.AddWithValue("@telefone", telefone);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do Telefone invalido");
                    }

                    comando.Parameters.AddWithValue("@logradouro", logradouro);

                    if (numero.Length >= 1)
                    {
                        comando.Parameters.AddWithValue("@numero", numero);
                    }
                    else
                    {
                        MessageBox.Show("Numero da residencia abaixo do permitido");
                    }

                    comando.Parameters.AddWithValue("@cidade", cidade);

                    if (estado.Length == 2)
                    {
                        comando.Parameters.AddWithValue("@estado", estado);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do Estado (UF) invalido");
                    }
                    comando.Parameters.AddWithValue("@bairro", bairro);

                    if (cep.Length == 8)
                    {
                        comando.Parameters.AddWithValue("@cep", cep);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do CEP invalido");
                    }

                    comando.Parameters.AddWithValue("@complemento", complemento);

                    connection.Open();
                    comando.ExecuteNonQuery();
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

        // Metodo Update e Delete fazem parte da funcionalidade da opção editar 

        protected void Update()
        {
            try
            {

                sql_update = "UPDATE cliente SET nome = @nome, cpf = @cpf, cnpj = @cnpj, telefone = @telefone, logradouro = @logradouro, numero = @numero, cidade = @cidade, estado = @estado, bairro = @bairro, cep = @cep, complemento = @complemento WHERE idcliente = @idcliente ";

                comando = new MySqlCommand(sql_update, Conexao_Banco());

                comando.Parameters.AddWithValue("@idcliente",idcliente);
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@cpf", cpf);
                comando.Parameters.AddWithValue("@cnpj", cnpj);
                comando.Parameters.AddWithValue("@telefone", telefone);
                comando.Parameters.AddWithValue("@logradouro", logradouro);
                comando.Parameters.AddWithValue("@numero", numero);
                comando.Parameters.AddWithValue("@cidade", cidade);
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@bairro", bairro);
                comando.Parameters.AddWithValue("@cep", cep);
                comando.Parameters.AddWithValue("@complemento", complemento);

                connection.Open();
                comando.ExecuteNonQuery();
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

        protected void Delete()
        {
            try
            {
                Conexao cn = new Conexao();


                sql_delete = "DELETE FROM cliente WHERE idcliente = @idcliente ";

                cn.comando = new MySqlCommand(sql_delete, Conexao_Banco());

                cn.comando.Parameters.AddWithValue("@idcliente", idcliente);

                connection.Open();
                cn.comando.ExecuteNonQuery();
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

        protected void Localizar()
        {
            try
            {
                Conexao cn = new Conexao();


                sql_select = "SELECT * FROM cliente WHERE nome = @nome ";

                cn.comando = new MySqlCommand(sql_select, Conexao_Banco());

                cn.comando.Parameters.AddWithValue("@nome", nome);

                connection.Open();
                dr = comando.ExecuteReader();
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

        protected void Mostrar_Tabela()
        {
            try
            {
                Conexao cn = new Conexao();


                sql_mostrar = "SELECT * FROM cliente ";

                da = new MySqlDataAdapter(sql_mostrar, Conexao_Banco());

                DataTable dt = new DataTable();

                da.Fill(dt);


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
