using System;

namespace DIO.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

           string opcaoUsuario = obterOpcaoUsuario();

           while(opcaoUsuario != "X"){ 

           switch(opcaoUsuario){

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

                VizualizarSerie();

                    break;

                case "C":
                Console.Clear();
                    break;

                case "X":
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Por Favor Seleciona uma opcao Valida");
                                           
             }

             opcaoUsuario = obterOpcaoUsuario();

           }   

           
           
        }

        private static void VizualizarSerie()
        {
           Console.WriteLine("digite o id da Série ");
           int indiceSerie = int.Parse(Console.ReadLine());

           var serie = repositorio.RetornaPorId(indiceSerie);

           Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {

            Console.WriteLine("digite o id da Série ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);

        }

        private static void AtualizarSerie()
        {
             Console.WriteLine("digite o id da Série ");
             int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){

                Console.WriteLine("{0}-{1}",i ,Enum.GetName(typeof(Genero),i ));

            }

            Console.WriteLine("Digite o genero entre as opcoes a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Serie: ");
            string entradaTítulo = Console.ReadLine();

            Console.WriteLine("Digite o ana de inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Serie: ");
            string entradaDescrecao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTítulo,
                                        ano: entradaAno,
                                        descricao: entradaDescrecao);

            repositorio.Atualizar(indiceSerie, atualizaSerie);                            

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var Lista = repositorio.Lista();

            if(Lista.Count == 0){

                Console.WriteLine("Nenhuma Serie Cadastrada");

            }

            foreach(var Serie in Lista){
                
                var excluido = Serie.retornaExcluido(); 
                Console.WriteLine("#ID {0} - {1} - {2}", Serie.retornaId(), Serie.retornaTitulo(),(excluido ? "Excluido" : ""));


            }
        }

        private static void InserirSerie(){

            Console.WriteLine("Inserir Série ");

            foreach(int i in Enum.GetValues(typeof(Genero))){

                Console.WriteLine("{0}-{1}",i ,Enum.GetName(typeof(Genero),i ));

            }

            Console.WriteLine("Digite o genero entre as opcoes a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Serie: ");
            string entradaTítulo = Console.ReadLine();

            Console.WriteLine("Digite o ana de inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Serie: ");
            string entradaDescrecao = Console.ReadLine();

            Serie novaSerie = new Serie(id:repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTítulo,
                                        ano: entradaAno,
                                        descricao: entradaDescrecao);

            repositorio.Insere(novaSerie);                            

        }

        private static string obterOpcaoUsuario(){

            Console.WriteLine();
            Console.WriteLine("DIO Series ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine();

            Console.WriteLine("1- Listar Series");
            Console.WriteLine("2- Inserir Series");
            Console.WriteLine("3- Atualizar Serie");
            Console.WriteLine("4- Excluir Serie");
            Console.WriteLine("5- Visualizar Serie");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
