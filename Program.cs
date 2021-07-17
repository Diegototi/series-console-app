using System;
using Series.Classes;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = OpcaoDoUsuario();
            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                        default:
                        throw new ArgumentOutOfRangeException();


                }

                OpcaoUsuario = OpcaoDoUsuario();

            }

            Console.WriteLine("Obrigado por usar nosso Aplicativo!");
            Console.ReadLine();

        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());  

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o numero referente Genero entre as oções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);         
        } 

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da Série que deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Atenção! Tem certeza que quer excluir a Série de id: {0}",indiceSerie);
            Console.WriteLine("Digite S para confirmar exlusão ou qualquer tecla cancelar exclusão:");
            var opcao = Console.ReadLine();
            if (opcao.ToUpper() == "S" )
            {
                     repositorio.Exclui(indiceSerie);
            }         

        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Atenção! Não existe nenhuma serie cadastrada!");
                return;
            }
            foreach (var serie in lista)
            {   
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#Id {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Exluído*" : ""));
            }
            

        }

        private static void InserirSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o numero referente Genero entre as oções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);                            
        }

        private static string OpcaoDoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("*** Cadastro de Séries ***");
            Console.WriteLine("Informe uma das opções abaixo:");
            Console.WriteLine("1 - Listas Séries Cadastradas");
            Console.WriteLine("2 - Inserir uma Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("x - Sair");

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;

        }


    }
}
