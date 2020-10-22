using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace erpbutequinhowpf.Model
{
    class To_Edit:Conexao
    {
        public string sql_update { get; set; }
        public string sql_delete { get; set; }

        protected void Update()
        {
            try
            {
                Conexao cn = new Conexao();


                sql_update = "UPDATE cliente SET nome = @nome, cpf = @cpf, cnpj = @cnpj, telefone = @telefone, logradouro = @logradouro, numero = @numero, cidade = @cidade, estado = @estado, bairro = @bairro, cep = @cep, complemento = @complemento WHERE idcliente = @idcliente ";

                cn.comando = new MySqlCommand(sql_update, Conexao_Banco());

                cn.comando.Parameters.AddWithValue("@idcliente", cn.idcliente);
                cn.comando.Parameters.AddWithValue("@nome", cn.nome);
                cn.comando.Parameters.AddWithValue("@cpf", cn.cpf);
                cn.comando.Parameters.AddWithValue("@cnpj", cn.cnpj);
                cn.comando.Parameters.AddWithValue("@telefone", cn.telefone);
                cn.comando.Parameters.AddWithValue("@logradouro", cn.logradouro);
                cn.comando.Parameters.AddWithValue("@numero", cn.numero);
                cn.comando.Parameters.AddWithValue("@cidade", cn.cidade);
                cn.comando.Parameters.AddWithValue("@estado", cn.estado);
                cn.comando.Parameters.AddWithValue("@bairro", cn.bairro);
                cn.comando.Parameters.AddWithValue("@cep", cn.cep);
                cn.comando.Parameters.AddWithValue("@complemento", cn.complemento);

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

        protected void Delete()
        {
            try
            {
                Conexao cn = new Conexao();


                sql_delete = "DELETE FROM cliente WHERE idcliente = @idcliente ";

                cn.comando = new MySqlCommand(sql_delete, Conexao_Banco());

                cn.comando.Parameters.AddWithValue("@idcliente", cn.idcliente);
                
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
    }
}
