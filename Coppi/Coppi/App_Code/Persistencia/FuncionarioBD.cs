using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrupoCoppi.Classes;
using FATEC;

namespace GrupoCoppi.Persistencia
{
    /// <summary>
    /// Summary description for FuncionarioBD
    /// </summary>
    public class FuncionarioBD
    {
        public Funcionario Autentica(string login, string senha)
        {
            Funcionario obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM pes_pessoas WHERE pes_login = ?login and pes_senha = ?senha", objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?login", login));
            objCommand.Parameters.Add(Mapped.Parameter("?senha", senha));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Funcionario();
                obj.Id = Convert.ToInt32(objDataReader["pes_id"]);
                obj.Nome = Convert.ToString(objDataReader["pes_nome"]);
                obj.Cpf = Convert.ToString(objDataReader["pes_cpf"]);
                obj.Tipo = Convert.ToInt32(objDataReader["pes_tipo"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }
        public Funcionario Select(int id)
        {
            Funcionario obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM pes_pessoas WHERE pes_id = ?codigo",
            objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Funcionario();
                obj.Id = Convert.ToInt32(objDataReader["pes_id"]);
                obj.Nome = Convert.ToString(objDataReader["pes_nome"]);
                obj.Cpf = Convert.ToString(objDataReader["pes_cpf"]);
                obj.Tipo = Convert.ToInt32(objDataReader["pes_tipo"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }


        public FuncionarioBD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}