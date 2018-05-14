using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC; //para acesso a classe Mapped
using GrupoCoppi.Classes.PJ; //para acesso a classe de modelagem
using GrupoCoppi.Classes;
using System.Data; // para acesso ao DataSet
using GrupoCoppi.Util; //para acesso ao enum

namespace GrupoCoppi.Persistencia.PJ
{

    /// <summary>
    /// Summary description for ClienteBD
    /// </summary>
    public class ClienteBD
    {
        //métodos

        //insert

        public int Insert(Cliente cliente)
        {
            int retorno = 0;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "INSERT INTO pes_pessoas(pes_telefone, pes_celular, pes_email, pes_cep, pes_logradouro, pes_numero, pes_bairro, pes_cidade, pes_estado, pes_nomeFantasia, pes_cnpj, pes_razaoSocial, pes_inscricaoEstadual, pes_tipo, pes_dataCadastro) VALUES (?telefone, ?celular, ?email, ?cep, ?logradouro, ?numero, ?bairro, ?cidade, ?estado, ?nomeFantasia, ?cnpj, ?razaoSocial, ?inscricaoEstadual, ?tipo, now())";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?telefone", cliente.Telefone));
                objCommand.Parameters.Add(Mapped.Parameter("?celular", cliente.Celular));
                objCommand.Parameters.Add(Mapped.Parameter("?email", cliente.Email));
                objCommand.Parameters.Add(Mapped.Parameter("?cep", cliente.Cep));
                objCommand.Parameters.Add(Mapped.Parameter("?logradouro", cliente.Logradouro));
                objCommand.Parameters.Add(Mapped.Parameter("?numero", cliente.Numero));
                objCommand.Parameters.Add(Mapped.Parameter("?bairro", cliente.Bairro));
                objCommand.Parameters.Add(Mapped.Parameter("?cidade", cliente.Cidade));
                objCommand.Parameters.Add(Mapped.Parameter("?estado", cliente.Estado));
                objCommand.Parameters.Add(Mapped.Parameter("?nomeFantasia", cliente.NomeFantasia));
                objCommand.Parameters.Add(Mapped.Parameter("?cnpj", cliente.Cnpj));
                objCommand.Parameters.Add(Mapped.Parameter("?razaoSocial", cliente.RazaoSocial));
                objCommand.Parameters.Add(Mapped.Parameter("?inscricaoEstadual", cliente.InscricaoEstadual));
                objCommand.Parameters.Add(Mapped.Parameter("?tipo", PESSOA.CLIENTE));
                objCommand.Parameters.Add(Mapped.Parameter("?dataCadastro", DateTime.Now));

                objCommand.ExecuteNonQuery();
                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                retorno = -1;
            }
            catch (Exception)
            {
                retorno = -2;
            }

            return retorno;
        }

        //selectall
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM pes_pessoas WHERE pes_tipo = ?tipo", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tipo", PESSOA.CLIENTE));
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;


        }

        //select
        public Cliente Select(int id)
        {
            Cliente obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM pes_pessoas WHERE pes_id = ?codigo", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Cliente();
                obj.Id = Convert.ToInt32(objDataReader["pes_id"]);
                obj.NomeFantasia = Convert.ToString(objDataReader["pes_nomeFantasia"]);
                obj.Cnpj = Convert.ToString(objDataReader["pes_cnpj"]);
                obj.RazaoSocial = Convert.ToString(objDataReader["pes_razaoSocial"]);
                obj.InscricaoEstadual = Convert.ToString(objDataReader["pes_inscricaoEstadual"]);
                obj.Telefone = Convert.ToString(objDataReader["pes_telefone"]);
                obj.Celular = Convert.ToString(objDataReader["pes_celular"]);
                obj.Email = Convert.ToString(objDataReader["pes_email"]);
                obj.Cep = Convert.ToString(objDataReader["pes_cep"]);
                obj.Logradouro = Convert.ToString(objDataReader["pes_logradouro"]);
                obj.Numero = Convert.ToString(objDataReader["pes_numero"]);
                obj.Bairro = Convert.ToString(objDataReader["pes_bairro"]);
                obj.Cidade = Convert.ToString(objDataReader["pes_cidade"]);
                obj.Estado = Convert.ToString(objDataReader["pes_estado"]);
                obj.DataCadastro = Convert.ToDateTime(objDataReader["pes_dataCadastro"]);
            }

            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }
        //update
        public bool Update(Cliente cliente)
        {
            bool retorno = true;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "UPDATE pes_pessoas SET pes_telefone=?telefone, pes_celular=?celular, pes_email=?email, pes_cep=?cep, pes_logradouro=?logradouro, pes_numero=?numero, pes_bairro=?bairro, pes_cidade=?cidade, pes_estado=?estado, pes_nomeFantasia=?nomeFantasia, pes_cnpj=?cnpj, pes_razaoSocial=?razaoSocial, pes_inscricaoEstadual=?inscricaoEstadual, pes_dataCadastro=?dataCadastro WHERE pes_id =?codigo";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?telefone", cliente.Telefone));
                objCommand.Parameters.Add(Mapped.Parameter("?celular", cliente.Celular));
                objCommand.Parameters.Add(Mapped.Parameter("?email", cliente.Email));
                objCommand.Parameters.Add(Mapped.Parameter("?cep", cliente.Cep));
                objCommand.Parameters.Add(Mapped.Parameter("?logradouro", cliente.Logradouro));
                objCommand.Parameters.Add(Mapped.Parameter("?numero", cliente.Numero));
                objCommand.Parameters.Add(Mapped.Parameter("?bairro", cliente.Bairro));
                objCommand.Parameters.Add(Mapped.Parameter("?cidade", cliente.Cidade));
                objCommand.Parameters.Add(Mapped.Parameter("?estado", cliente.Estado));
                objCommand.Parameters.Add(Mapped.Parameter("?nomeFantasia", cliente.NomeFantasia));
                objCommand.Parameters.Add(Mapped.Parameter("?cnpj", cliente.Cnpj));
                objCommand.Parameters.Add(Mapped.Parameter("?razaoSocial", cliente.RazaoSocial));
                objCommand.Parameters.Add(Mapped.Parameter("?inscricaoEstadual", cliente.InscricaoEstadual));
                objCommand.Parameters.Add(Mapped.Parameter("?tipo", PESSOA.CLIENTE));
                objCommand.Parameters.Add(Mapped.Parameter("?dataCadastro", cliente.DataCadastro));
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", cliente.Id));

                objCommand.ExecuteNonQuery();
                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            }
            catch (Exception ex)
            {
                retorno = false;
            }
            return retorno;

        }

        public Cliente VerificaDupicidadeEmail(string email)
        {
            Cliente obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM pes_pessoas WHERE pes_email =?email", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?email", email));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Cliente();
                obj.Email = Convert.ToString(objDataReader["pes_email"]);

            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }

        public Cliente VerificaDupicidadeCnpj(string cnpj)
        {
            Cliente obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM pes_pessoas WHERE pes_cnpj =?cnpj", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cnpj", cnpj));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Cliente();
                obj.Cnpj = Convert.ToString(objDataReader["pes_cnpj"]);

            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }

        public Cliente VerificaDupicidadeRazaoSocial(string razaoSocial)
        {
            Cliente obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM pes_pessoas WHERE pes_razaoSocial =?razaoSocial", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?razaoSocial", razaoSocial));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Cliente();
                obj.RazaoSocial = Convert.ToString(objDataReader["pes_razaoSocial"]);

            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }





        //delete
        //construtor

        public ClienteBD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}