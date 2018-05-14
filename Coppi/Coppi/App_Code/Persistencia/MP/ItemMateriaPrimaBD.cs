using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC;
using GrupoCoppi.Classes.MP;
using System.Data;

namespace GrupoCoppi.Persistencia.MP
{
    /// <summary>
    /// Descrição resumida de ItemMateriaPrimaBD
    /// </summary>
    public class ItemMateriaPrimaBD
    {
        //insert
        public int Insert(ItemMateriaPrima itemMateriaPrima)
        {
            int retorno = 0;
            try
            {

                System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO imp_itemmateriaprima (imp_quantidadeItem, imp_dataFabricacao, imp_dataValidade, imp_lote) VALUES (?quantidadeItem, ?dataFabricacao, ?dataValidade, ?lote)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?quantidadeItem", itemMateriaPrima.QuantidadeItem));
            objCommand.Parameters.Add(Mapped.Parameter("?dataFabricacao", itemMateriaPrima.DataFabricacao));
            objCommand.Parameters.Add(Mapped.Parameter("?dataValidade", itemMateriaPrima.DataValidade));
            objCommand.Parameters.Add(Mapped.Parameter("?lote", itemMateriaPrima.Lote));



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
            objCommand = Mapped.Command("SELECT * FROM imp_itemmateriaprima", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }
        //select

        public ItemMateriaPrima Select(int id)
        {
            ItemMateriaPrima obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM imp_itemmateriaprima WHERE imp_id = ?codigo", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new ItemMateriaPrima();

                obj.Id = Convert.ToInt32(objDataReader["imp_id"]);
                obj.QuantidadeItem = Convert.ToDouble(objDataReader["imp_quantidadeItem"]);
                obj.DataFabricacao = Convert.ToDateTime(objDataReader["imp_dataFabricacao"]);
                obj.DataValidade = Convert.ToDateTime(objDataReader["imp_dataValidade"]);
                obj.Lote = Convert.ToString(objDataReader["imp_lote"]);

            }

            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }
        //update
        public bool Update(ItemMateriaPrima itemMateriaPrima)
        {
            bool retorno = true;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "UPDATE imp_itemmateriaprima SET imp_quantidadeItem=?quantidadeItem, imp_dataFabricacao=?dataFabricacao, imp_dataValidade=?dataValidade, imp_lote=?lote WHERE imp_id =?codigo";


                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?quantidadeItem", itemMateriaPrima.QuantidadeItem));
                objCommand.Parameters.Add(Mapped.Parameter("?dataFabricacao", itemMateriaPrima.DataFabricacao));
                objCommand.Parameters.Add(Mapped.Parameter("?dataValidade", itemMateriaPrima.DataValidade));
                objCommand.Parameters.Add(Mapped.Parameter("?lote", itemMateriaPrima.Lote));

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



        public ItemMateriaPrimaBD()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}