﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using erpbutequinhowpf.ViewModel;
using MySql.Data.MySqlClient;

namespace erpbutequinhowpf.Model
{
    class ClienteModel:Conexao
    {
       // Propriedades que receberão as informações inseridas pelo usuario e serão passada para dentro do banco

        public string sql_insert { get; set; }
        public string sql_update { get; set; }
        public string sql_delete { get; set; }
        public string sql_select { get; set; }
        public string sql_mostrar { get; set; }

        public ClienteModel()
        {

        }

        // Metodo Inserte ira realizar a inserção ods valores recebido pelo o usuario 

        public void Inserir(Cliente cliente)
        {
            try
            {
                string bloqueio = "SELECT count(id) FROM cliente WHERE cpf_cnpj = @cpf";

                if (cliente.CpfOuCnpj != bloqueio) // Verificar se não existe um cpf igual 
                {

                    sql_insert = "insert into cliente (nome, cpf_cnpj, telefone, logradouro, numero, cidade, " +
                        "estado, bairro, cep, complemento) values (@nome, @cpf," +
                        "@telefone, @logradouro, @numero, @cidade, @estado, @bairro, @cep, @complemento)";

                    comando = new MySqlCommand(sql_insert, Conexao_Banco());

                    comando.Parameters.AddWithValue("@nome", cliente.Nome);

                    if (cliente?.CpfOuCnpj.Length == 11)
                    { //definindo a quantidade minima de caracteres 
                        comando.Parameters.AddWithValue("@cpf", cliente.CpfOuCnpj);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do CPF invalido");
                    }

                   if (cliente?.Telefone?.Length == 11)
                    {
                        comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do Telefone invalido");
                    }

                    comando.Parameters.AddWithValue("@logradouro", cliente?.Logradouro);

                    if (cliente?.Numero?.Length >= 1)
                    {
                        comando.Parameters.AddWithValue("@numero", cliente?.Numero);
                    }
                    else
                    {
                        MessageBox.Show("Numero da residencia abaixo do permitido");
                    }

                    comando.Parameters.AddWithValue("@cidade", cliente?.Cidade);

                    if (cliente?.Estado?.Length == 2)
                    {
                        comando.Parameters.AddWithValue("@estado", cliente.Estado);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do Estado (UF) invalido");
                    }
                    comando.Parameters.AddWithValue("@bairro", cliente?.Bairro);

                    if (cliente?.Cep?.Length == 8)
                    {
                        comando.Parameters.AddWithValue("@cep", cliente?.Cep);
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres do CEP invalido");
                    }

                    comando.Parameters.AddWithValue("@complemento", cliente?.Complemento);

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

        public void Update(Cliente cliente)
        {
            try
            {

                sql_update = "UPDATE cliente SET nome = @nome, cpf_cnpj = @cpf, " +
                    "telefone = @telefone, logradouro = @logradouro, numero = @numero, " +
                    "cidade = @cidade, estado = @estado, bairro = @bairro, cep = @cep, " +
                    "complemento = @complemento WHERE idcliente = @idcliente ";

                comando = new MySqlCommand(sql_update, Conexao_Banco());

                comando.Parameters.AddWithValue("@idcliente", cliente.Id);
                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@cpf", cliente.CpfOuCnpj);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@logradouro", cliente.Logradouro);
                comando.Parameters.AddWithValue("@numero", cliente.Numero);
                comando.Parameters.AddWithValue("@cidade", cliente.Cidade);
                comando.Parameters.AddWithValue("@estado", cliente.Estado);
                comando.Parameters.AddWithValue("@bairro", cliente.Bairro);
                comando.Parameters.AddWithValue("@cep", cliente.Cep);
                comando.Parameters.AddWithValue("@complemento", cliente.Complemento);

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

        public void Delete(int id)
        {
            try
            {
                Conexao cn = new Conexao();


                sql_delete = "DELETE FROM cliente WHERE idcliente = @id";

                cn.comando = new MySqlCommand(sql_delete, Conexao_Banco());

                cn.comando.Parameters.AddWithValue("@id", id);

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

        public Cliente FindByID(int id)
        {
            Cliente cliente = new Cliente();
            try
            {
                Conexao cn = new Conexao();


                sql_select = "SELECT * FROM cliente WHERE idcliente = @id ";

                cn.comando = new MySqlCommand(sql_select, Conexao_Banco());

                cn.comando.Parameters.AddWithValue("@id", id);

                connection.Open();
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    cliente.Id = dr.GetInt32("idcliente");
                    cliente.Nome = dr.GetString("nome");
                    cliente.CpfOuCnpj = dr.GetString("cpf_cnpj");
                    cliente.Telefone = dr.GetString("telefone");
                    cliente.Logradouro = dr.GetString("logradouro");
                    cliente.Numero = dr.GetString("numero");
                    cliente.Complemento = dr.GetString("complemento");
                    cliente.Bairro = dr.GetString("bairro");
                    cliente.Cep = dr.GetString("cep");
                    cliente.Cidade = dr.GetString("cidade");
                    cliente.Estado = dr.GetString("estado");
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

            return cliente;

        }

        protected void FindByNome(string nome)
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

        public ArrayList FindAll()
        {
            ArrayList clientes = new ArrayList();
            try
            {
                Conexao cn = new Conexao();


                sql_select = "SELECT * FROM cliente ";

                cn.comando = new MySqlCommand(sql_select, Conexao_Banco());

                connection.Open();
                dr = cn.comando.ExecuteReader();

                while (dr.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = dr.GetInt32("idcliente");
                    cliente.Nome = dr.GetString("nome");
                    cliente.CpfOuCnpj = dr.GetString("cpf_cnpj");
                    cliente.Telefone = dr.GetString("telefone");
                    cliente.Logradouro = dr.GetString("logradouro");
                    cliente.Numero = dr.GetString("numero");
                    cliente.Complemento = dr.GetString("complemento");
                    cliente.Bairro = dr.GetString("bairro");
                    cliente.Cep = dr.GetString("cep");
                    cliente.Cidade = dr.GetString("cidade");
                    cliente.Estado = dr.GetString("estado");

                    clientes.Add(cliente);
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

            return clientes;
        }
    }
}


