using System;

namespace Cadastro.serie
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoMenu = ObterOpcaoMenu();
            while (OpcaoMenu.ToUpper() != "X")
            {
                switch (OpcaoMenu)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Opção não reconhecida.");
                }

                OpcaoMenu = ObterOpcaoMenu();
            }
        }

        private static void VisualizarSeries()
        {
            Console.WriteLine();
            Console.WriteLine("========= Visualizar séries =========");
            Console.WriteLine("Séries cadastradas no sistema (todas):");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Não há séries cadastradas na lista...");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine($"ID {serie.RetornaId()} | {serie.RetornaTitulo()} | {(excluido ? "Excluído" : "Ativo")}");
            }
            Console.WriteLine("------------------------------------------");
            Console.Write("Insira o ID da série que deseja visualizar: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var descricao = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(descricao);
        }

        private static void ExcluirSeries()
        {
            Console.WriteLine();
            Console.WriteLine("========= Remoção de série =========");
            Console.WriteLine("Séries cadastradas no sistema:");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Não há séries cadastradas na lista...");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine($"ID {serie.RetornaId()} | {serie.RetornaTitulo()}");
            }
            Console.WriteLine("------------------------------------------");
            Console.Write("Insira o ID da série que deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());
                
            Console.WriteLine("Deseja mesmo excluir essa série do sistema? [S/N]");
            string resposta = Console.ReadLine().ToUpper();
            if (resposta == "S")
            {
                repositorio.Exclui(indiceSerie);
            }

        }

        private static void AtualizarSeries()
        {
            Console.WriteLine();
            Console.WriteLine("========= Atualização de série =========");
            Console.WriteLine("Séries cadastradas no sistema:");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Não há séries cadastradas na lista...");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                if (excluido != true)
                {
                    Console.WriteLine($"ID {serie.RetornaId()} | {serie.RetornaTitulo()}");
                }
            }
            Console.WriteLine("------------------------------------------");
            Console.Write("Insira o ID da série que deseja atualizar: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();
            /// <summary>
            /// Parâmetro reponsável por retornar índice e nome do gênero dentro do Enum Genero.
            /// </summary>
            /// <param name="Enum.GetValues(typeof(Genero))"></param>
            /// <returns></returns>
            foreach (int indice in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{indice,3} | {Enum.GetName(typeof(Genero), indice)}");
            }
            Console.WriteLine();
            Console.WriteLine("Insira o número conforme as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Insira o ano de início da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a descrição da série:");
            string entradadescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradadescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine();
            Console.WriteLine("========== Listagem de séries ==========");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Não há séries cadastradas na lista...");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                if (excluido != true)
                {
                    Console.WriteLine($"ID {serie.RetornaId()} | {serie.RetornaTitulo()}");
                }
            }
        }

        private static void InserirSeries()
        {
            Console.WriteLine("========== Inserir nova série ==========");

            /// <summary>
            /// Parâmetro reponsável por retornar índice e nome do gênero dentro do Enum Genero.
            /// </summary>
            /// <param name="Enum.GetValues(typeof(Genero))"></param>
            /// <returns></returns>
            foreach (int indice in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{indice,3} | {Enum.GetName(typeof(Genero), indice)}");
            }

            Console.WriteLine("Insira o número conforme as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Insira o ano de início da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a descrição da série:");
            string entradadescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradadescricao);
            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoMenu()
        {
            Console.WriteLine();
            Console.WriteLine("---------- SERIES LIST PROGRAM ----------");
            Console.WriteLine("[1] Listar séries cadastradas");
            Console.WriteLine("[2] Cadastrar nova série");
            Console.WriteLine("[3] Atualizar série cadastrada");
            Console.WriteLine("[4] Excluir série");
            Console.WriteLine("[5] Visualizar série");
            Console.WriteLine("[C] Limpar console");
            Console.WriteLine("[X] Sair");
            Console.WriteLine("=========================================");
            string OpcaoMenu = Console.ReadLine().ToUpper();
            return OpcaoMenu;
        }
    }
}
