using System;
using System.Collections.Generic;

namespace ConsoleMercado
{
    internal class Program
    {
        public static List<Produto> produtos = new List<Produto>();
        
        static void Main(string[] args)
        {
            int opcao = 0, cod_produto = 0;
            bool result;
            
            while (opcao != 3)
            {
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("INFORME A OPÇÃO: ");
                Console.WriteLine("0 - EFETUAR COMPRAS\n1 - EFETUAR CADASTRO DE NOVOS PRODUTOS\n2 - LISTAR PRODUTOS EM ESTOQUE\n3 - SAIR");
                Console.WriteLine("-------------------------------------------------------------------------");
                opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {
                    case 0:
                        Console.Write("Leia o código do produto: ");
                        cod_produto = Convert.ToInt32(Console.ReadLine());
                        result = EfetuarCompras(cod_produto);
                        if(result == true)
                            Console.WriteLine("Operação realizada com sucesso.");
                        break;
                    case 1:
                        EfetuarCadastro();
                        break;
                    case 2:
                        ListarProdutos();
                        break;
                    case 3:
                        return;
                   
                }
            }
        }


        public static void EfetuarCadastro()
        {
            Produto prod = new Produto();
            Console.Write("Nome do Produto: ");
            prod.NomeProduto = Console.ReadLine();
            Console.Write("Fornecedor do produto: ");
            prod.NomeFornecedor = Console.ReadLine();
            Console.Write("Quantidade do produto: ");
            prod.QuantidadeProduto = Convert.ToInt32(Console.ReadLine());
            Console.Write("Valor de cada unidade do produto: ");
            prod.ValorProduto = Convert.ToDouble(Console.ReadLine());
            Console.Write("Código do produto: ");
            prod.CodigoProduto = Convert.ToInt32(Console.ReadLine());

            try
            {
                produtos.Add(prod);
                Console.WriteLine("Produto Adicionado com sucesso!\n\n");

            }
            catch
            {
                Console.WriteLine("Erro ao adicionar produto");
            }

        }
        public static bool EfetuarCompras(int cod_produto)
        {
            int qtd_removida;
            foreach (Produto p in produtos)
            {
                if (p.CodigoProduto == cod_produto)
                {
                    if (p.QuantidadeProduto == 0)
                    {
                        Console.WriteLine("Produto com quantidade 0");
                        return false;
                    }
                    else
                    {
                        Console.Write("Quantidade: ");
                        qtd_removida = Convert.ToInt32(Console.ReadLine());
                        p.QuantidadeProduto -= qtd_removida;
                        return true;
                    }
                }
            }

            Console.WriteLine("Produto não cadastrado.");
            return false;
        }

        public static void ListarProdutos()
        {
            Console.WriteLine("------------------------------LISTA DE PRODUTOS NO SISTEMA------------------------------");
            Console.WriteLine("CÓDIGO | NOME | QUANTIDADE | VALOR | FORNECEDOR ");
            foreach (Produto p in produtos)
            {
                Console.WriteLine(p.CodigoProduto + " || " + p.NomeProduto + " || " + p.QuantidadeProduto + " || " + p.ValorProduto + " || " + p.NomeFornecedor);
            }
        }


    }
}
