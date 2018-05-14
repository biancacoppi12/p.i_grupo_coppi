using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC; //para acesso a classe Mapped
using GrupoCoppi.Classes.MP; //para acesso a classe de modelagem
using GrupoCoppi.Classes;
using System.Data; // para acesso ao DataSet
using GrupoCoppi.Util.MP; //para acesso ao enum

namespace GrupoCoppi.Persistencia.MP
{
    /// <summary>
    /// Summary description for MateriaPrimaBD
    /// </summary>
    public class MateriaPrimaBD
    {

        //métodos

        //insert
        public int Insert(MateriaPrima materiaprima)
        {
            int retorno = 0;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "INSERT INTO map_materiaprima(map_nome) VALUES (?nome)";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?nome", materiaprima.Nome));



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
            objCommand = Mapped.Command("SELECT * FROM map_materiaprima", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }

        //selectNN - para a relação NN com Fornecedor
        public DataSet SelectAllNn()
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM map_materiaprima ORDER BY map_nome", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }
        //select

        public MateriaPrima Select(int id)
        {
            MateriaPrima obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM map_materiaprima WHERE map_id = ?codigo", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new MateriaPrima();

                obj.Id = Convert.ToInt32(objDataReader["map_id"]);
                obj.Nome = Convert.ToString(objDataReader["map_nome"]);
                obj.Quantidade = Convert.ToDouble(objDataReader["map_quantidadeTotal"]);

            }

            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }
        //update
        public bool Update(MateriaPrima materiaprima)
        {
            bool retorno = true;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "UPDATE map_materiaprima SET map_nome=?nome, map_quantidadeTotal=?quantidade WHERE map_id =?codigo";

                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?nome", materiaprima.Nome));
                objCommand.Parameters.Add(Mapped.Parameter("?quantidade", materiaprima.Quantidade));
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", materiaprima.Id));


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


        //cadastrar tabela intermediaria n:n

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

        public DataSet GetFornecedores(int materiaprima)
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT map_nome, pes_nomeFantasia, pes_razaoSocial, pes_email FROM fmp_fornecedormateriaprima INNER JOIN map_materiaprima ON map_materiaprima.map_id=fmp_fornecedormateriaprima.map_id INNER JOIN pes_pessoas ON pes_pessoas.pes_id=fmp_fornecedormateriaprima.pes_id WHERE map_materiaprima.map_id=?materiaprima ORDER BY pes_nomeFantasia;", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?materiaprima", materiaprima));
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return ds;
        }

        public MateriaPrima VerificaDupicidadeNome(string nome)
        {
            MateriaPrima obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM map_materiaprima WHERE map_nome =?nome", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?nome", nome));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new MateriaPrima();
                obj.Nome = Convert.ToString(objDataReader["map_nome"]);

            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }
        //construtor

        public MateriaPrimaBD()
            {
                //
                // TODO: Add constructor logic here
                //
            }
        }
    }
