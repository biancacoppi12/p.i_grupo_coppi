using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC;
using GrupoCoppi.Classes.NF;
using GrupoCoppi.Classes.MP;
using System.Data;


namespace GrupoCoppi.Persistencia.NF
{
    /// <summary>
    /// Descrição resumida de ItemNotaFiscalBD
    /// </summary>
    public class ItemNotaFiscalBD
    {

        //insert
        public int Insert(ItemNotaFiscal itemNotaFiscal)
        {
            int retorno = 0;
            try
            {

                System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO inf_itemnotafiscal (inf_quantidade, inf_valorUnitario, inf_valorTotalUnitario, nfi_id, map_id, inf_quantidadeItem, inf_dataFabricacao, inf_dataValidade, inf_lote) VALUES (?quantidade, ?valorUnitario, ?valorTUnitario, ?nfi, ?map, ?quantidadeItem, ?fabricacao, ?validade, ?lote);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

           
            objCommand.Parameters.Add(Mapped.Parameter("?quantidade", itemNotaFiscal.Quantidade));
            objCommand.Parameters.Add(Mapped.Parameter("?valorUnitario", itemNotaFiscal.ValorUnitario));
            objCommand.Parameters.Add(Mapped.Parameter("?valorTUnitario", itemNotaFiscal.ValorTUnitario));
            objCommand.Parameters.Add(Mapped.Parameter("?nfi", itemNotaFiscal.NotaFiscal.Id));
            objCommand.Parameters.Add(Mapped.Parameter("?map", itemNotaFiscal.ItemMateriaPrima.Id));
                objCommand.Parameters.Add(Mapped.Parameter("?quantidadeItem", itemNotaFiscal.QuantidadeItem));
                objCommand.Parameters.Add(Mapped.Parameter("?fabricacao", itemNotaFiscal.DataFabricacao));
                objCommand.Parameters.Add(Mapped.Parameter("?validade", itemNotaFiscal.DataValidade));
                objCommand.Parameters.Add(Mapped.Parameter("?lote", itemNotaFiscal.Lote));


                objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                retorno = -1;
            }
            catch (Exception ex)
            {
                retorno = -2;
            }

            return retorno;
        }


        public int InsertRetornaId(ItemNotaFiscal itemNotaFiscal)
        {
            int retorno = 0;
            try
            {

                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
       string sql = "INSERT INTO inf_itemnotafiscal (inf_quantidade, inf_valorUnitario, inf_valorTotalUnitario, nfi_id, map_id, inf_quantidadeItem, inf_dataFabricacao, inf_dataValidade, inf_lote) VALUES (?quantidade, ?valorUnitario, ?valorTUnitario, ?nfi, ?map, ?quantidadeItem, ?fabricacao, ?validade, ?lote); select last_insert_id();";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);


                objCommand.Parameters.Add(Mapped.Parameter("?quantidade", itemNotaFiscal.Quantidade));
                objCommand.Parameters.Add(Mapped.Parameter("?valorUnitario", itemNotaFiscal.ValorUnitario));
                objCommand.Parameters.Add(Mapped.Parameter("?valorTUnitario", itemNotaFiscal.ValorTUnitario));
                objCommand.Parameters.Add(Mapped.Parameter("?nfi", itemNotaFiscal.NotaFiscal.Id));
                objCommand.Parameters.Add(Mapped.Parameter("?map", itemNotaFiscal.MateriPrima.Id));
                objCommand.Parameters.Add(Mapped.Parameter("?quantidadeItem", itemNotaFiscal.QuantidadeItem));
                objCommand.Parameters.Add(Mapped.Parameter("?fabricacao", itemNotaFiscal.DataFabricacao));
                objCommand.Parameters.Add(Mapped.Parameter("?validade", itemNotaFiscal.DataValidade));
                objCommand.Parameters.Add(Mapped.Parameter("?lote", itemNotaFiscal.Lote));


                retorno = Convert.ToInt32(objCommand.ExecuteScalar());
                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
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
            objCommand = Mapped.Command("SELECT * FROM inf_itemnotafiscal", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }

       
        //select

        public ItemNotaFiscal Select(ItemNotaFiscal itemnotafiscal)
        {
            ItemNotaFiscal obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM inf_itemnotafiscal WHERE inf_id = ?codigo", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", itemnotafiscal.Id));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new ItemNotaFiscal();

                obj.Id = Convert.ToInt32(objDataReader["inf_id"]);
                obj.Quantidade = Convert.ToInt32(objDataReader["inf_quantidade"]);
                obj.ValorUnitario = Convert.ToDouble(objDataReader["inf_valorUnitario"]);
                obj.ValorTUnitario = Convert.ToDouble(objDataReader["inf_valorTotalUnitario"]);
                
            }

            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }
        //update
        public bool Update(ItemNotaFiscal itemNotaFiscal)
        {
            bool retorno = true;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "UPDATE inf_itemnotafiscal SET  inf_quantidade=?quantidade, inf_valorUnitario=?valorUnitario, inf_valorTotalUnitario=?valorTUnitario  WHERE inf_id =?codigo";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?quantidade", itemNotaFiscal.Quantidade));
                objCommand.Parameters.Add(Mapped.Parameter("?valorUnitario", itemNotaFiscal.ValorUnitario));
                objCommand.Parameters.Add(Mapped.Parameter("?valorTUnitario", itemNotaFiscal.ValorTUnitario));

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

        public bool Delete(int id)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "DELETE FROM inf_itemnotafiscal WHERE inf_id=?codigo";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;

        }
        public ItemNotaFiscalBD()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}