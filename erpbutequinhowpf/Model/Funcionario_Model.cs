using erpbutequinhowpf.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace erpbutequinhowpf.Model
{
    class FuncionarioModel:Conexao
    {
        // Propriedades que receberão as informações inseridas pelo usuario e serão passada para dentro do banco

        public string sql_insert { get; set; }
        public string sql_update { get; set; }
        public string sql_delete { get; set; }
        public string sql_select { get; set; }
        public string sql_mostrar { get; set; }

        public FuncionarioModel()
        {

        }

        // Metodo Inserte ira realizar a inserção ods valores recebido pelo o usuario 

        public void Inserir(Funcionario funcionario)
        {
            try
            {
                string bloqueio = "SELECT count(id) FROM funcionario WHERE cpf = @cpf";

                if (funcionario.CpfOuCnpj != bloqueio) // Verificar se não existe um cpf igual 
                {

                    sql_insert = "insert into funcionario (nome, cpf_cnpj, telefone, logradouro, numero, cidade, " +
                        "estado, bairro, cep, complemento) values (@nome, @cpf," +
                        "@telefone, @logradouro, @numero, @cidade, @estado, @bairro, @cep, @complemento)";

                    comando = new MySqlCommand(sql_insert, Conexao_Banco());

                    comando.Parameters.AddWithValue("@nome", funcionario.Nome);

                    if (funcionario?.CpfOuCnpj.Length == 11)
                    { //definindo a quantidade minima de caracteres 
                        comando.Parameters.AddWithValue("@cpf", funcionario.CpfOuCnpj);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do CPF invalido");
                    }

                   if (funcionario?.Telefone?.Length == 11)
                    {
                        comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do Telefone invalido");
                    }

                    comando.Parameters.AddWithValue("@logradouro", funcionario?.Logradouro);

                    if (funcionario?.Numero?.Length >= 1)
                    {
                        comando.Parameters.AddWithValue("@numero", funcionario?.Numero);
                    }
                    else
                    {
                        MessageBox.Show("Numero da residencia abaixo do permitido");
                    }

                    comando.Parameters.AddWithValue("@cidade", funcionario?.Cidade);

                    if (funcionario?.Estado?.Length == 2)
                    {
                        comando.Parameters.AddWithValue("@estado", funcionario.Estado);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do Estado (UF) invalido");
                    }
                    comando.Parameters.AddWithValue("@bairro", funcionario?.Bairro);

                    if (funcionario?.Cep?.Length == 8)
                    {
                        comando.Parameters.AddWithValue("@cep", funcionario?.Cep);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do CEP invalido");
                    }

                    comando.Parameters.AddWithValue("@complemento", funcionario?.Complemento);

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

        public void Update(Funcionario funcionario)
        {
            try
            {

                sql_update = "UPDATE funcionario SET nome = @nome, cpf_cnpj = @cpf, " +
                    "telefone = @telefone, logradouro = @logradouro, numero = @numero, " +
                    "cidade = @cidade, estado = @estado, bairro = @bairro, cep = @cep, " +
                    "complemento = @complemento WHERE id = @idfuncionario ";

                comando = new MySqlCommand(sql_update, Conexao_Banco());

                comando.Parameters.AddWithValue("@idfuncionario", funcionario.Id);
                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@cpf", funcionario.CpfOuCnpj);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@logradouro", funcionario.Logradouro);
                comando.Parameters.AddWithValue("@numero", funcionario.Numero);
                comando.Parameters.AddWithValue("@cidade", funcionario.Cidade);
                comando.Parameters.AddWithValue("@estado", funcionario.Estado);
                comando.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@cep", funcionario.Cep);
                comando.Parameters.AddWithValue("@complemento", funcionario.Complemento);

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

        public void Delete(int idfuncionario)
        {
            try
            {
                Conexao cn = new Conexao();


                sql_delete = "DELETE FROM funcionario WHERE id = @idfuncionario ";

                cn.comando = new MySqlCommand(sql_delete, Conexao_Banco());

                cn.comando.Parameters.AddWithValue("@idfuncionario", idfuncionario);

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

        public void FindByID(int id)
        {
            try
            {
                Conexao cn = new Conexao();


                sql_select = "SELECT * FROM funcionario WHERE id = @id ";

                cn.comando = new MySqlCommand(sql_select, Conexao_Banco());

                cn.comando.Parameters.AddWithValue("@id", id);

                connection.Open();
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(String.Format("{0}", dr[0]));
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

        protected void FindByNome(string nome)
        {
            try
            {
                Conexao cn = new Conexao();


                sql_select = "SELECT * FROM funcionario WHERE nome = @nome ";

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

        protected void FindAll()
        {
            try
            {
                Conexao cn = new Conexao();


                sql_mostrar = "SELECT * FROM funcionario ";

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
