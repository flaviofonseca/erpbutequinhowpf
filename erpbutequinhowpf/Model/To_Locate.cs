using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Data;

namespace erpbutequinhowpf.Model
{
    class To_Locate:Conexao
    {
        public string sql_select { get; set; }
        public string sql_mostrar { get; set; }

        protected void Localizar()
        {
            try
            {
                Conexao cn = new Conexao();

                
                sql_select = "SELECT * FROM cliente WHERE nome = @nome ";

                cn.comando = new MySqlCommand(sql_select, Conexao_Banco());

                cn.comando.Parameters.AddWithValue("@nome", cn.nome);

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

                da = new MySqlDataAdapter (sql_mostrar, Conexao_Banco());

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
