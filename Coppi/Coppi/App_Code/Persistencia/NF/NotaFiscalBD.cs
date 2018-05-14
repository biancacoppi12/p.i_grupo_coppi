using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrupoCoppi.Classes;
using FATEC;
using GrupoCoppi.Classes.NF;
using System.Data;
using GrupoCoppi.Persistencia.PJ;
using GrupoCoppi.Classes.PJ;

namespace GrupoCoppi.Persistencia.NF
{
    /// <summary>
    /// Descrição resumida de NotaFiscalBD
    /// </summary>
    public class NotaFiscalBD
    {
        //métodos 
        //vincular
        public bool Vincular(int idmateria, int idfornecedor)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO fmp_fornecedormateriaprima(map_id, pes_id) VALUES(?materia, ?fornecedor)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?materia", idmateria));
            objCommand.Parameters.Add(Mapped.Parameter("?fornecedor", idfornecedor));
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }

        public int ExecutarSQL(string sql)
        {
            int retorno = 0;
            try
            {

                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);



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


        public int Insert(NotaFiscal notaFiscal)
        {
            int retorno = 0;
            try
            {

                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "INSERT INTO nfi_notafiscal(nfi_numeroNotaFiscal, nfi_dataEmissao, nfi_valorTotal) VALUES (?numero, ?dataEmissao, ?valorTotal)";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?numero", notaFiscal.Numero));
                objCommand.Parameters.Add(Mapped.Parameter("?dataEmissao", notaFiscal.DataEmissao));
                objCommand.Parameters.Add(Mapped.Parameter("?valorTotal", notaFiscal.ValorTotal));



                objCommand.ExecuteNonQuery();
                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                retorno = -1;
            }
            catch (Exception)
            {
                retorno = -2;
            }

            return retorno;
        }

        public int InsertRetornaId(NotaFiscal notaFiscal)
        {
            int retorno = 0;
            try
            {

                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "INSERT INTO nfi_notafiscal(nfi_numeroNotaFiscal, nfi_dataEmissao, nfi_valorTotal, pes_id) VALUES (?numero, ?dataEmissao, ?valorTotal, ?fornecedor); select last_insert_id();";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?numero", notaFiscal.Numero));
                objCommand.Parameters.Add(Mapped.Parameter("?dataEmissao", notaFiscal.DataEmissao));
                objCommand.Parameters.Add(Mapped.Parameter("?valorTotal", notaFiscal.ValorTotal));
                objCommand.Parameters.Add(Mapped.Parameter("?fornecedor", notaFiscal.Fornecedor.pes_id));



                retorno = Convert.ToInt32( objCommand.ExecuteScalar());
                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
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
            objCommand = Mapped.Command("SELECT * FROM nfi_notafiscal", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }


        public DataSet SelectAllInner()
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT p.pes_razaoSocial, n.nfi_numeroNotaFiscal, n.nfi_dataEmissao, n.nfi_valorTotal, n.nfi_id FROM pes_pessoas p INNER JOIN nfi_notafiscal n USING(pes_id) ;", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;

        }



        //select

        public static NotaFiscal Select(int id)
        {
            NotaFiscal obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM  nfi_notafiscal WHERE nfi_id = ?id ", objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?id", id));
        


            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new NotaFiscal();

                obj.Id = Convert.ToInt32(objDataReader["nfi_id"]);
                obj.Numero = Convert.ToString(objDataReader["nfi_numeroNotaFiscal"]);
                obj.DataEmissao = Convert.ToDateTime(objDataReader["nfi_dataEmissao"]);
                obj.ValorTotal = Convert.ToDouble(objDataReader["nfi_valorTotal"]);
                Fornecedor f = new Fornecedor();
                f.pes_id = Convert.ToInt32(objDataReader["pes_id"]);
                obj.Fornecedor = f;
            }

            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            if (obj.Fornecedor.pes_id != null)
                obj.Fornecedor = FornecedorBD.Select(obj.Fornecedor.pes_id);
            return obj;
        }
        //update
        public bool Update(NotaFiscal notafiscal)
        {
            bool retorno = true;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "UPDATE nfi_notafiscal SET  nfi_numeroNotaFiscal=?numero, nfi_dataEmissao=?dataEmissao, nfi_valorTotal=?valorTotal WHERE nfi_id =?codigo";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?numero", notafiscal.Numero));
                objCommand.Parameters.Add(Mapped.Parameter("?dataEmissao", notafiscal.DataEmissao));
                objCommand.Parameters.Add(Mapped.Parameter("?valorTotal", notafiscal.ValorTotal));

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

        public NotaFiscal VerificaDuplicidadeNF(string nf)
        {
            NotaFiscal obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM nfi_notafiscal WHERE nfi_numeroNotaFiscal =?numero", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?numero", nf));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new NotaFiscal();
                obj.Numero = Convert.ToString(objDataReader["nfi_numeroNotaFiscal"]);

            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }





        public NotaFiscalBD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}