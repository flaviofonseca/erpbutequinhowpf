using MySql.Data.MySqlClient;

namespace erpbutequinhowpf.Model
{
    class Conexao
    {

        public MySqlConnection connection { get; set; }
        public MySqlCommand comando { get; set; }
        public MySqlDataAdapter da { get; set; }
        public MySqlDataReader  dr { get; set; }

        protected MySqlConnection Conexao_Banco()
        {
            connection = new MySqlConnection("Server=localhost;Database=butequinho;Uid=root;Pwd=flavio;");
            return connection;
        }
    }
}
