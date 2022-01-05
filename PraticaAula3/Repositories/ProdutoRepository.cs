using Dapper;
using PraticaAula3.Entities;
using PraticaAula3.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticaAula3.Repositories
{
    public class ProdutoRepository : IBaseRepository<Produto>
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDPraticaAula3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void Create(Produto obj)
        {
            //escrevendo o comando SQL p/ inserir
            var sql = @"
                   INSERT INTO PRODUTO(IDPRODUTO,NOME,PRECO,QUANTIDADE,DATACOMPRA)
                   VALUES(@IdProduto, @Nome, @Preco, @Quantidade, @DataCompra)  
                ";
            //abrindo conexão com o sqlserver p/ inserir
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com o Dapper
                connection.Execute(sql, obj);
            }
        }
        public void Delete(Produto obj)
        {    //escrvendo o comando SQL p/ deletar
            var sql = @"
                    DELETE FROM PRODUTO
                    WHERE IDPRODUTO = @IdProduto
                ";
              //abrindo conexão com o sqlserver p/ deletar
            using (var connection = new SqlConnection(_connectionString))
            {
                //executendo comando com Dapper p/ deletar
                connection.Execute(sql, obj);
            }
        }

        public List<Produto> GetAll()
        {
            //escrevendo comando SQL p/ consultar 
            var sql = @"
                    SELECT * FROM PRODUTO
                    ORDER BY
                       NOME ASC
                 ";
            //abrindo conexão com sqlsever p/ consultar
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper e retornar o resultado da consulta
                return connection.Query<Produto>(sql).ToList();
            }
        }

        public void Update(Produto obj)
        {
            //escrever o comando SQL
            var sql = @"
                 UPDATE PRODUTO SET
                    NOME = @Nome,
                    PRECO = @Preco,
                    QUANTIDADE = @Quantidade,
                    DATACOMPRA =@DataCompra
                WHERE
                    IDPRODUTO = @IdProduto
              
                ";
            //abrindo conexão com o sqlserver 
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper
                connection.Execute(sql, obj);
            }
        }
    }
}
