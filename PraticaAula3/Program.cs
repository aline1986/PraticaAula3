using PraticaAula3.Entities;
using PraticaAula3.Repositories;
using System;

//define a localização da classe dentro doprojeto
namespace PraticaAula3
{
 //definição da classe
    class Program
    {
        //método (funções) para executar o projeto
        static void Main(string[] args)
        {
            //imprimi a informação na tela que está entre parenteses
            Console.WriteLine("\n***Produtos***\n");

            try //tentativa
            {
                Console.WriteLine("(1) CADASTRAR PRODUTO");
                Console.WriteLine("(2) ALTERAR DADOS DO PRODUTO");
                Console.WriteLine("(3) EXCLUIR PRODUTO");
                Console.WriteLine("(4) CONSULTAR PRODUTO");
                Console.Write("Informe a opção desejada...: ");

                //criando um objeto para a classe C
                var opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.WriteLine("\nCADASTRO DE PRODUTO:\n");

                    //criando um objeto para a classe Produto(variável de instância)
                    var produto = new Produto();

                    //Acessando as propriedades da classe Produto(variável de instância)
                    produto.IdProduto = Guid.NewGuid();

                    //Imprimir no pronpt de comando
                    Console.WriteLine("Informe o Nome do produto.....: ");
                    //Ler o que o usuário digitou, sempre recebe tipo string
                    produto.Nome = Console.ReadLine();

                    Console.WriteLine("Informe preço do produto......: ");
                    //Ler o que o usuário digitou, e está convertendo para aceitar tipo decimal
                    produto.Preco = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Informe a Quantidade..............: ");
                    //Ler o que o usuário digitou, e está convertendo para aceitar tipo  int
                    produto.Quantidade = int.Parse(Console.ReadLine());

                    Console.Write("Informe data da compra:");

                    //Ler o que o usuário digitou, e está convertendo para aceitar tipo  date
                    DateTime dateTime = DateTime.Parse(Console.ReadLine());
                    produto.DataCompra = dateTime;

                    //criando um objeto para classe ProdutoRepository
                    var produtoRepository = new ProdutoRepository();

                    //executar a gravação do arquivo
                    produtoRepository.Create(produto);

                    Console.WriteLine("\nPRODUTO CADASTRADO COM SUCESSO!");
                }
                else if (opcao == 2)
                {
                    Console.WriteLine("\nALTERAR DADOS DO PRODUTO:\n");

                    //Criar objeto para classe produto (variável de instancia)
                    var produto = new Produto();

                    //Escreveu na tela para o usuário ver
                    Console.Write("Informe Id do produto...:");
                    //Está lendo o que o usuário digitou, como o tipo de ReadLine é string então se converte par o tipo Guid
                    produto.IdProduto = Guid.Parse(Console.ReadLine());

                    Console.Write("Informe nome do produto.....:");
                    produto.Nome = Console.ReadLine();

                    //Ler o que o usuário digitou, e está convertendo para aceitar tipo decimal
                    Console.Write("Informe o Preco......: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());

                    //Ler o que o usuário digitou, e está convertendo para inteiro
                    Console.Write("Informe a quantidade......: ");
                    produto.Quantidade = int.Parse(Console.ReadLine());


                    //Ler o que o usuário digitou, e está convertendo para aceitar tipo  date
                    Console.Write("Informe a data da compra ......: ");
                    DateTime dateTime = DateTime.Parse(Console.ReadLine());
                    produto.DataCompra = dateTime;

                    var produtoRepository = new ProdutoRepository();
                    produtoRepository.Update(produto);

                    Console.WriteLine("\nDados atualizados com sucesso!\n");

                }
                else if (opcao == 3)
                {
                    Console.WriteLine("\nExcluir produto:\n");

                    //criando objeto da classe produto
                    var produto = new Produto();

                    Console.Write("Informe Id do produto...:");
                    produto.IdProduto = Guid.Parse(Console.ReadLine());

                    var produtoRepository = new ProdutoRepository();
                    produtoRepository.Delete(produto);

                    Console.WriteLine("\nproduto excluída com sucesso!\n");
                }
                else if (opcao == 4)
                {
                    Console.WriteLine("\nConsulta de produtos:\n");
                    var produtoRepository = new ProdutoRepository();
                    var produto = produtoRepository.GetAll();

                    // imprimindo os dados dos produtos
                    foreach (var item in produto)
                    {
                        Console.WriteLine($"IDPRODUTO...:{item.IdProduto }");
                        Console.WriteLine($"NOME...: {item.Nome}");
                        Console.WriteLine($"PRECO...: {item.Preco}");
                        Console.WriteLine($"QUANTIDADE...: {item.Quantidade}");
                        Console.WriteLine($"DATACOMPRA...: {item.DataCompra}");
                    }
                }
                Console.Write("\nDeseja continuar? (S,N): ");
                var confirmacao = Console.ReadLine();
                if (confirmacao.Equals("S"))
                {
                    Console.Clear(); //limpar o console
                    Main(args); //recursividade
                }
                Console.WriteLine("\nFIM!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nERRO: {e.Message}");
            }
            Console.ReadKey();
        }
    }
}