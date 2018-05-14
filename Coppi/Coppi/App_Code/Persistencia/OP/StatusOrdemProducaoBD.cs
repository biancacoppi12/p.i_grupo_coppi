using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrupoCoppi.Classes;
using FATEC;
using GrupoCoppi.Classes.OP;
using System.Data;
using GrupoCoppi.Util;

/// <summary>
/// Summary description for StatusOrdemProducaoBD
/// </summary>
/// 
namespace GrupoCoppi.Persistencia.OP
{


    public class StatusOrdemProducaoBD
    {
        //métodos 
        //insert
        public int Insert(StatusOrdemProducao statusOrdemProducao)
        {
            int retorno = 0;
            try
            {

                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "INSERT INTO sta_statusordemproducao(sta_descricao) VALUES (?descricao)";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);


                // fazer enum 
                objCommand.Parameters.Add(Mapped.Parameter("?descricao", statusOrdemProducao.Descricao));
             

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
            objCommand = Mapped.Command("SELECT * FROM sta_statusordemproducao", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }


        //select

        public StatusOrdemProducao Select(int id)
        {
            StatusOrdemProducao obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM sta_statusordemproducao WHERE sta_id = ?codigo", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new StatusOrdemProducao();

                obj.Id = Convert.ToInt32(objDataReader["sta_id"]);
                obj.Descricao = Convert.ToString(objDataReader["sta_descricao"]);
                
            }

            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }
        //update
        public bool Update(StatusOrdemProducao statusOrdemProducao)
        {
            bool retorno = true;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "UPDATE sta_statusordemproducao SET sta_descricao=?descricao WHERE sta_id =?codigo";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?descricao", statusOrdemProducao.Descricao));
               

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


        public StatusOrdemProducaoBD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
