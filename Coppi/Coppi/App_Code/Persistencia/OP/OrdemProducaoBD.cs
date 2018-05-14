using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC;
using GrupoCoppi.Classes.OP;
using GrupoCoppi.Classes;
using GrupoCoppi.Classes.Tapetes;
using GrupoCoppi.Persistencia.Tapetes;
using System.Data;
/// <summary>
/// Summary description for OrdemProducaoBD
/// </summary>
/// 
namespace GrupoCoppi.Persistencia.OP
{


    public class OrdemProducaoBD
    {
        //métodos 
        //insert
        public int Insert(OrdemProducao ordemProducao)
        {
            int retorno = 0;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "INSERT INTO ord_ordemproducao(ord_dataEntrada, ord_previsaoEntrega, ord_controleInterno, pes_id, sta_id) VALUES (?dataEntrada, ?previsaoEntrega, now(), ?pes_id, ?sta_id)";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?dataEntrada", ordemProducao.DataEntrada));
                objCommand.Parameters.Add(Mapped.Parameter("?previsaoEntrega", ordemProducao.PrevisaoEntrega));
                objCommand.Parameters.Add(Mapped.Parameter("?controleInterno", DateTime.Now));

                // foreign key
                objCommand.Parameters.Add(Mapped.Parameter("?pes_id", ordemProducao.Pessoa.Id));
                objCommand.Parameters.Add(Mapped.Parameter("?sta_id", ordemProducao.StatusOrdemProducao.Id));

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
            objCommand = Mapped.Command("SELECT * FROM ord_ordemproducao", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }

        //selectallaguardando
        public DataSet SelectAllAguardando()
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT p.pes_nomeFantasia, o.ord_dataEntrada, o.ord_id, o.ord_previsaoEntrega, t.tap_largura, t.tap_comprimento, s.sta_descricao FROM pes_pessoas p INNER JOIN ord_ordemproducao o USING (pes_id) INNER JOIN tap_tapete t USING(ord_id) INNER JOIN sta_statusordemproducao s USING(sta_id) where sta_id=4 and pes_tipo=4;", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }

        // select all com inner join para listar op abertas

        public DataSet SelectAllInner()
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT p.pes_nomeFantasia, o.ord_dataEntrada, o.ord_id, o.ord_previsaoEntrega, t.tap_largura, t.tap_comprimento, t.tap_tipoArte, s.sta_descricao FROM pes_pessoas p INNER JOIN ord_ordemproducao o USING (pes_id) INNER JOIN tap_tapete t USING(ord_id) INNER JOIN sta_statusordemproducao s USING(sta_id);", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;

        }

        // select all com inner join para listar op fechadas

        public DataSet SelectAllInnerFechada()
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT p.pes_nomeFantasia, o.ord_dataEntrada, o.ord_id, o.ord_previsaoEntrega, t.tap_tipoArte, t.tap_valorVenda, s.sta_descricao FROM pes_pessoas p INNER JOIN ord_ordemproducao o USING (pes_id) Inner JOIN tap_tapete t USING(ord_id) INNER JOIN sta_statusordemproducao s USING(sta_id) WHERE sta_id=8;", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }

        // Select all inner fechada grafico
        public DataSet SelectAllInnerFechadaGrafico()
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("select distinct month(ord_previsaoEntrega) as mes,(select sum(tap_valorVenda) as soma from tap_tapete inner join ord_ordemproducao using(ord_id) where month(ord_previsaoEntrega)  =month(o.ord_previsaoEntrega)  and year(ord_previsaoEntrega)  = year(o.ord_previsaoEntrega)) as valortotal, if (month(ord_previsaoEntrega)=1,'Janeiro',if(month(ord_previsaoEntrega)=2,'Fevereiro',if(month(ord_previsaoEntrega)=3,'Março',if(month(ord_previsaoEntrega)=4,'Abril',if(month(ord_previsaoEntrega)=5,'Maio',if(month(ord_previsaoEntrega)=6,'Junho',if(month(ord_previsaoEntrega)=7,'Julho',if(month(ord_previsaoEntrega)=8,'Agosto',if(month(ord_previsaoEntrega)=9,'Setembro',if(month(ord_previsaoEntrega)=10,'Outubro',if(month(ord_previsaoEntrega)=11,'Novembro',if(month(ord_previsaoEntrega)=12,'Dezembro','')))))))))))) as NomeMes from ord_ordemproducao o where month(ord_previsaoEntrega)  =month(o.ord_previsaoEntrega)  and year(ord_previsaoEntrega)  = year(o.ord_previsaoEntrega) and (select sum(tap_valorVenda) as soma from tap_tapete inner join ord_ordemproducao using(ord_id) where month(ord_previsaoEntrega)  =month(o.ord_previsaoEntrega)  and year(ord_previsaoEntrega)  = year(o.ord_previsaoEntrega)) is not null order by mes asc;", objConexao);

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }


        //select

        public OrdemProducao Select(OrdemProducao ordemproducao)
        {
            OrdemProducao obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM ord_ordemproducao WHERE ord_dataEntrada = ?dataEntrada and ord_previsaoEntrega = ?previsaoEntrega", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?dataEntrada", ordemproducao.DataEntrada));
            objCommand.Parameters.Add(Mapped.Parameter("?previsaoEntrega", ordemproducao.PrevisaoEntrega));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new OrdemProducao();

                obj.Id = Convert.ToInt32(objDataReader["ord_id"]);
            }

            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }

        public OrdemProducao SelectAlterar(int id)
        {
            OrdemProducao obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM ord_ordemproducao WHERE ord_id = ?codigo", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new OrdemProducao();

                obj.Id = Convert.ToInt32(objDataReader["ord_id"]);
                obj.DataEntrada = Convert.ToDateTime(objDataReader["ord_dataEntrada"]);
                obj.PrevisaoEntrega = Convert.ToDateTime(objDataReader["ord_previsaoEntrega"]);
                //obj.Pessoa.Id = Convert.ToInt32(objDataReader["pes_id"]);
                //obj.StatusOrdemProducao.Descricao = Convert.ToString(objDataReader["sta_id"]);
            }

            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }

        //update
        public bool Update(OrdemProducao ordemProducao)
        {
            bool retorno = true;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;

                string sql = "UPDATE ord_ordemproducao INNER JOIN sta_statusordemproducao USING(sta_id) INNER JOIN tap_tapete USING(ord_id) SET ord_dataEntrada=?dataEntrada, ord_previsaoEntrega=?previsaoEntrega, tap_largura=?largura, tap_comprimento=?comprimento, tap_tipoArte=?tipoArte, tap_valorVenda=valorVenda, sta_descricao=?descricao  WHERE ord_id =?codigo";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?dataEntrada", ordemProducao.DataEntrada));
                objCommand.Parameters.Add(Mapped.Parameter("?previsaoEntrega", ordemProducao.PrevisaoEntrega));
                objCommand.Parameters.Add(Mapped.Parameter("?largura", ordemProducao.Tapetes));
                objCommand.Parameters.Add(Mapped.Parameter("?comprimento", ordemProducao.Tapetes));
                objCommand.Parameters.Add(Mapped.Parameter("?tipoArte", ordemProducao.Tapetes));
                objCommand.Parameters.Add(Mapped.Parameter("?valorVenda", ordemProducao.Tapetes));
                objCommand.Parameters.Add(Mapped.Parameter("?descricao", ordemProducao.StatusOrdemProducao));
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", ordemProducao.Id));
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


        public OrdemProducaoBD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}