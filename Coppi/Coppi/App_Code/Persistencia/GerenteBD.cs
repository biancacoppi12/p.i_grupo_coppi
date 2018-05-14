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
/// Descrição resumida de GerenteBD
/// </summary>

namespace GrupoCoppi.Persistencia
{
    public class GerenteBD
    {  //insert
        public int Insert(Gerente gerente)
        {
            int retorno = 0;
            try
            {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "INSERT INTO pes_pessoas(pes_telefone, pes_celular, pes_email, pes_cep, pes_tipoLogradouro, pes_logradouro, pes_numero, pes_bairro, pes_cidade, pes_estado, pes_nome, pes_cpf, pes_login, pes_senha, pes_tipo) VALUES (?telefone, ?celular, ?email, ?cep, ?tipoLogradouro, ?logradouro, ?numero, ?bairro, ?cidade, ?estado, ?nome, ?cpf, ?login, ?senha, 0)";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);


                objCommand.Parameters.Add(Mapped.Parameter("?telefone", gerente.Telefone));
                objCommand.Parameters.Add(Mapped.Parameter("?celular", gerente.Celular));
                objCommand.Parameters.Add(Mapped.Parameter("?email", gerente.Email));
                objCommand.Parameters.Add(Mapped.Parameter("?cep", gerente.Cep));
                objCommand.Parameters.Add(Mapped.Parameter("?tipoLogradouro", gerente.TipoLogradouro));
                objCommand.Parameters.Add(Mapped.Parameter("?logradouro", gerente.Logradouro));
                objCommand.Parameters.Add(Mapped.Parameter("?numero", gerente.Numero));
                objCommand.Parameters.Add(Mapped.Parameter("?bairro", gerente.Bairro));
                objCommand.Parameters.Add(Mapped.Parameter("?cidade", gerente.Cidade));
                objCommand.Parameters.Add(Mapped.Parameter("?estado", gerente.Estado));
                objCommand.Parameters.Add(Mapped.Parameter("?nome", gerente.Nome));
                objCommand.Parameters.Add(Mapped.Parameter("?cpf", gerente.Cpf));
                objCommand.Parameters.Add(Mapped.Parameter("?login", gerente.Login));
                objCommand.Parameters.Add(Mapped.Parameter("?senha", gerente.Senha));
                objCommand.Parameters.Add(Mapped.Parameter("0", PESSOA.GERENTE));



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
        
        public GerenteBD()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}