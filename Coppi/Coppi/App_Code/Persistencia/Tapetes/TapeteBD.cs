using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrupoCoppi.Classes;
using FATEC;
using System.Data;
using GrupoCoppi.Classes.Tapetes;
/// <summary>
/// Summary description for TapeteBD
/// </summary>
/// 
namespace GrupoCoppi.Persistencia.Tapetes
{
    public class TapeteBD
    {
        //métodos 
        //insert
        public int Insert(Tapete tapete)
        {
            int retorno = 0;
            try
            {

                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "INSERT INTO tap_tapete(tap_largura, tap_comprimento, tap_tipoArte, tap_valorVenda, ord_id) VALUES (?largura, ?comprimento, ?tipoArte, ?valorVenda, ?ord_id)";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?largura", tapete.Largura));
                objCommand.Parameters.Add(Mapped.Parameter("?comprimento", tapete.Comprimento));
                objCommand.Parameters.Add(Mapped.Parameter("?tipoArte", tapete.TipoArte));
                objCommand.Parameters.Add(Mapped.Parameter("?valorVenda", tapete.ValorVenda));
                // FK
                objCommand.Parameters.Add(Mapped.Parameter("?ord_id", tapete.OrdemProducao.Id));


                objCommand.ExecuteNonQuery();
                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            }
            catch (MySql.Data.MySqlClient.MySqlException eex)
            {
                retorno = -1;
            }
            catch (Exception ex)
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
            objCommand = Mapped.Command("SELECT * FROM tap_tapete", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }

        //select

        public static Tapete Select(int id)
        {
            Tapete obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM tap_tapete WHERE tap_id = ?codigo", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Tapete();

                obj.Id = Convert.ToInt32(objDataReader["tap_id"]);
                obj.Largura = Convert.ToDouble(objDataReader["tap_largura"]);
                obj.Comprimento = Convert.ToDouble(objDataReader["tap_comprimento"]);
                obj.TipoArte = Convert.ToString(objDataReader["tap_tipoArte"]);
                obj.ValorVenda = Convert.ToDouble(objDataReader["tap_valorVenda"]);
                obj.OrdemProducao.Id = Convert.ToInt32(objDataReader["ord_id"]);
            }
            // tem q colocar as chaves estrangeiras tbem nesse select?
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }

        public Tapete SelectAlterar(Tapete tapete)
        {
            Tapete obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM tap_tapete WHERE tap_largura = ?largura and tap_comprimento = ?comprimento and tap_tipoArte = ?arte and tap_valorVenda = ?venda", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?largura", tapete.Largura));
            objCommand.Parameters.Add(Mapped.Parameter("?comprimento", tapete.Comprimento));
            objCommand.Parameters.Add(Mapped.Parameter("?arte", tapete.TipoArte));
            objCommand.Parameters.Add(Mapped.Parameter("?venda", tapete.ValorVenda));



            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Tapete();

                obj.Id = Convert.ToInt32(objDataReader["tap_id"]);


            }

            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }

        //update
        public bool Update(Tapete tapete)
        {
            bool retorno = true;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "UPDATEtap_tapete SET  tap_largura=?largura, tap_comprimento=?comprimento, tap_tipoArte=?tipoArte, tap_valorVenda=?valorVenda WHERE tap_id =?codigo";
               
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?largura", tapete.Largura));
                objCommand.Parameters.Add(Mapped.Parameter("?comprimento", tapete.Comprimento));
                objCommand.Parameters.Add(Mapped.Parameter("?tipoArte", tapete.TipoArte));
                objCommand.Parameters.Add(Mapped.Parameter("?valorVenda", tapete.ValorVenda));

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




        public TapeteBD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}