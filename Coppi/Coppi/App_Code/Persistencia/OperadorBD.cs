using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC; //para acesso a classe Mapped
using GrupoCoppi.Classes.Funcionarios; //para acesso a classe de modelagem
using GrupoCoppi.Classes;
using System.Data; // para acesso ao DataSet
using GrupoCoppi.Util; //para acesso ao enum

/// <summary>
/// Summary description for OperadorBD
/// </summary>
namespace GrupoCoppi.Persistencia
{
    public class OperadorBD
    {
        //insert
        public int Insert(Operador operador)
        {
            int retorno = 0;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "INSERT INTO pes_pessoas(pes_telefone, pes_celular, pes_email, pes_cep, pes_logradouro, pes_numero, pes_bairro, pes_cidade, pes_estado, pes_nome, pes_cpf, pes_login, pes_senha, pes_tipo) VALUES (?telefone, ?celular, ?email, ?cep, ?logradouro, ?numero, ?bairro, ?cidade, ?estado, ?nome, ?cpf, ?login, ?senha, 1)";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);


                objCommand.Parameters.Add(Mapped.Parameter("?telefone", operador.Telefone));
                objCommand.Parameters.Add(Mapped.Parameter("?celular", operador.Celular));
                objCommand.Parameters.Add(Mapped.Parameter("?email", operador.Email));
                objCommand.Parameters.Add(Mapped.Parameter("?cep", operador.Cep));
                objCommand.Parameters.Add(Mapped.Parameter("?logradouro", operador.Logradouro));
                objCommand.Parameters.Add(Mapped.Parameter("?numero", operador.Numero));
                objCommand.Parameters.Add(Mapped.Parameter("?bairro", operador.Bairro));
                objCommand.Parameters.Add(Mapped.Parameter("?cidade", operador.Cidade));
                objCommand.Parameters.Add(Mapped.Parameter("?estado", operador.Estado));
                objCommand.Parameters.Add(Mapped.Parameter("?nome", operador.Nome));
                objCommand.Parameters.Add(Mapped.Parameter("?cpf", operador.Cpf));
                objCommand.Parameters.Add(Mapped.Parameter("?login", operador.Login));
                objCommand.Parameters.Add(Mapped.Parameter("?senha", operador.Senha));
                objCommand.Parameters.Add(Mapped.Parameter("1", PESSOA.OPERADOR));



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
            objCommand = Mapped.Command("SELECT * FROM pes_pessoas WHERE pes_tipo BETWEEN 0 AND 1", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }

        public OperadorBD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}