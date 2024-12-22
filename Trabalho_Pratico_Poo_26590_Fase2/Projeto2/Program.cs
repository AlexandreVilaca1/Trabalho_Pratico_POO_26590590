//-----------------------------------------------------------------
//    <author>Alexandre Vilaça</author>
//    <date>21-12-2024</date>
//    <time>18:00</time>
//-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using DLL_Enums;
using DLL_Models;
using DLL_Generic;

namespace Projeto_zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inicialização dos gerenciadores de listas para diferentes entidades do Zoo
            var gere_animais = new ListManager<Animal>();
            var gere_funcionarios = new ListManager<Funcionario>();
            var gere_habitats = new ListManager<Habitat>();
            var gere_limpezas_habitat = new ListManager<LimpezaHabitat>();
            var gere_assistencias_veterinarias = new ListManager<AssistenciaVeternaria>();
            var gere_clientes = new ListManager<Cliente>();
            var gere_espetaculos = new ListManager<Espetaculo>();
            var gere_bilhetes = new ListManager<Bilhete>();

            #region Zoo
            //Zoo
            // Criação e exibição das informações do Zoo
            Console.WriteLine("===============================Zoo===================================================");
            Informacao zoo = new Informacao("Zoo Braga", "Braga", "4705-194", "rua dos congregados", "Melhor zoo do país, com maior diversidade de animais");
            zoo.MostrarInformacao(zoo);
            #endregion

            #region Animais
            //Animais
            // Criação e gerenciamento de animais
            // Inclui adição de animais, edição, remoção e exibição de informações, e salvar dados em ficheiro txt.
            Console.WriteLine("===============================Lista Animais===================================================");
            Animal animal1 = new Animal(3, TipoAnimal.Hipopotamo, "Hipo", DateOnly.Parse("2021-09-24"), Grupo.Mamifero);
            Animal animal2 = new Animal(4, TipoAnimal.Golfinho, "Golfu", DateOnly.Parse("2019-07-16"), Grupo.Peixe);
            Animal animal3 = new Animal(5, TipoAnimal.Canario, "Paulo", DateOnly.Parse("2022-09-11"), Grupo.Ave);
            Animal animal4 = new Animal(6, TipoAnimal.Leao, "Simba", DateOnly.Parse("2020-04-15"), Grupo.Mamifero);
            Animal animal5 = new Animal(7, TipoAnimal.Tigre, "Somba", DateOnly.Parse("2018-06-17"), Grupo.Mamifero);
            gere_animais.AdicionarDadosDeFicheiroNaLista("../../../TxtFiles/animais.txt", linha =>
            {
                var partes = linha.Split(',');

                var id = int.Parse(partes[0].Split(':')[1].Trim());
                var tipo = Enum.Parse<TipoAnimal>(partes[1].Split(':')[1].Trim());
                var nome = partes[2].Split(':')[1].Trim();
                var dataNascimento = DateOnly.Parse(partes[3].Split(':')[1].Trim());
                var grupo = Enum.Parse<Grupo>(partes[4].Split(':')[1].Trim());

                return new Animal(id, tipo, nome, dataNascimento, grupo);
            }
            );
            gere_animais.AdicionaLista(animal1);
            gere_animais.AdicionaLista(animal2);
            gere_animais.AdicionaLista(animal3);
            gere_animais.AdicionaLista(animal4);
            gere_animais.AdicionaLista(animal5);
            gere_animais.EditarLista(
        x => x.Id == 3,
        x =>
        {
            x.Tipo = TipoAnimal.Hipopotamo;
            x.Nome = "Hopo";
            x.DataNascimento = DateOnly.Parse("2021-09-24");
            x.Grupo = Grupo.Mamifero;
        }
        );
            //gere_animais.Remove(animal1);
            gere_animais.MostrarInformacoes();
            gere_animais.AdicionaListaFicheiro("../../../TxtFiles/animais.txt");
            #endregion

            #region Alimentacao
            //Alimentacao
            // Criação e gerenciamento de alimentações
            // Inclui adição de alimentações e exibição de informações
            Alimentacao alimentacao1 = new Alimentacao(400, 2, TipoComida.Carne, DateTime.Parse("2024-12-14 11:40"), animal1);
            Alimentacao alimentacao2 = new Alimentacao(150, 4, TipoComida.Fruta, DateTime.Parse("2024-12-14 16:30"), animal1);
            animal1.AdicionarAlimentacaoAnimalLista(alimentacao1);
            animal1.AdicionarAlimentacaoAnimalLista(alimentacao2);
            animal1.MostrarAlimentacaoAnimal(animal1);
            animal1.AdicionaListaAlimentacoesFicheiro("../../../TxtFiles/alimentacoes.txt");
            Console.WriteLine("\n");
            #endregion

            #region Funcionários
            //Funcionarios
            // Criação e gerenciamento de funcionários
            // Inclui adição de funcionários e exibição de informações
            Console.WriteLine("===============================Lista Funcionarios===================================================");
            Funcionario funcionario1 = new Funcionario(1, "Alexandre Vilaca", DateOnly.Parse("2001-02-14"), "alexandrepv1357@gmail.com", 910543931, TipoFuncionario.Cuidador);
            Funcionario funcionario2 = new Funcionario(2, "Mafalada Coelho", DateOnly.Parse("1999-08-11"), "mafalda99@gmail.com", 967231780, TipoFuncionario.Veternario);
            Funcionario funcionario3 = new Funcionario(3, "Pedro Pires", DateOnly.Parse("1987-06-08"), "pedro@outlook.pt", 914790531, TipoFuncionario.Cuidador);
            Funcionario funcionario4 = new Funcionario(4, "Ricardo Gomes", DateOnly.Parse("1992-01-25"), "ricardo@outlook.pt", 924539214, TipoFuncionario.Limpeza);
            Funcionario funcionario5 = new Funcionario(5, "Maria Fonseca", DateOnly.Parse("1998-06-17"), "maria@outlook.pt", 967184521, TipoFuncionario.Cuidador);
            Funcionario funcionario6 = new Funcionario(6, "Joana Lopes", DateOnly.Parse("1984-09-11"), "joana@outlook.pt", 91782639, TipoFuncionario.Veternario);
            gere_funcionarios.AdicionaLista(funcionario1);
            gere_funcionarios.AdicionaLista(funcionario2);
            gere_funcionarios.AdicionaLista(funcionario3);
            gere_funcionarios.AdicionaLista(funcionario4);
            gere_funcionarios.AdicionaLista(funcionario5);
            gere_funcionarios.AdicionaLista(funcionario6);
            gere_funcionarios.MostrarInformacoes();
            funcionario1.CalcularIdade(funcionario1);
            gere_funcionarios.AdicionaListaFicheiro("../../../TxtFiles/funcionarios.txt");
            Console.WriteLine("\n");
            #endregion

            #region Habitats
            //Habitats
            // Criação e gerenciamento de habitats
            // Inclui adição e remoção de habitats, animais e funcionários aos habitats
            Console.WriteLine("===============================Lista Habitats===================================================");
            Habitat habitat1 = new Habitat(1, "Floresta Tropical Passaros", DateTime.Parse("2024-12-02 11:25"));
            Habitat habitat2 = new Habitat(2, "Piscina Golfinhos", DateTime.Parse("2024-12-03 17:45"));
            Habitat habitat3 = new Habitat(3, "Savana", DateTime.Parse("2024-12-03 09:50"));
            Habitat habitat4 = new Habitat(4, "Lagoa dos Hipopotamos", DateTime.Parse("2024-12-03 18:20"));
            gere_habitats.AdicionaLista(habitat1);
            gere_habitats.AdicionaLista(habitat2);
            gere_habitats.AdicionaLista(habitat3);
            gere_habitats.AdicionaLista(habitat4);
            habitat1.AdicionarAnimaisHabitatLista(animal3);
            habitat1.AdicionarFuncionariosHabitatLista(funcionario3);
            habitat2.AdicionarAnimaisHabitatLista(animal2);
            habitat2.AdicionarFuncionariosHabitatLista(funcionario1);
            habitat3.AdicionarAnimaisHabitatLista(animal4);
            habitat3.AdicionarAnimaisHabitatLista(animal5);
            habitat3.RemoverAnimalHabitatLista(animal5);
            habitat3.AdicionarFuncionariosHabitatLista(funcionario1);
            habitat3.AdicionarFuncionariosHabitatLista(funcionario5);
            habitat3.RemoverFuncionarioHabitatLista(funcionario1);
            habitat4.AdicionarAnimaisHabitatLista(animal1);
            habitat4.AdicionarFuncionariosHabitatLista(funcionario5);
            habitat1.MostrarInformacoesHabitat(habitat1);
            habitat1.Contador();
            habitat2.MostrarInformacoesHabitat(habitat2);
            habitat2.Contador();
            habitat3.MostrarInformacoesHabitat(habitat3);
            habitat3.Contador();
            habitat4.MostrarInformacoesHabitat(habitat4);
            habitat4.Contador();
            gere_habitats.AdicionaListaFicheiro("../../../TxtFiles/habitats.txt");
            #endregion

            #region Limpeza Habitats
            //Limpeza Habitats
            // Criação e gerenciamento de limpezas de habitats
            // Inclui adição de limpezas e exibição de informações
            Console.WriteLine("===============================Lista Limpezas===================================================");
            LimpezaHabitat limpezaHabitat1 = new LimpezaHabitat(1, habitat1, DateTime.Parse("2024-12-03 14:30"));
            limpezaHabitat1.AdicionarFuncionarioLimpezaLista(funcionario4);
            gere_limpezas_habitat.AdicionaLista(limpezaHabitat1);
            limpezaHabitat1.MostrarInformacaoLimpezaHabitats(limpezaHabitat1);
            gere_limpezas_habitat.AdicionaListaFicheiro("../../../TxtFiles/limpeza_habitats.txt");
            Console.WriteLine("\n");
            #endregion

            #region Assistência Animais
            // Criação e gerenciamento de assistências veterinárias
            // Inclui adição de assistências e exibição de informações
            //Assistencia Animais
            Console.WriteLine("===============================Lista Assistencia Animais===================================================");
            AssistenciaVeternaria assistenciaVeternaria1 = new AssistenciaVeternaria(1, DateTime.Parse("2024-11-16 14:30"), TipoAssistencia.Rotina, "Animal com pouca vontade de comer, possivelmente devido a congestão nasal", animal1);
            assistenciaVeternaria1.AdicionarFuncionarioAssistenciaLista(funcionario2);
            assistenciaVeternaria1.AdicionarFuncionarioAssistenciaLista(funcionario6);
            assistenciaVeternaria1.MostrarInformacoesAssistenciasVeternarias(assistenciaVeternaria1);
            gere_assistencias_veterinarias.AdicionaLista(assistenciaVeternaria1);
            gere_assistencias_veterinarias.AdicionaListaFicheiro("../../../TxtFiles/assistencias_veternarias.txt");
            Console.WriteLine("\n");
            #endregion

            #region Clientes
            // Criação e gerenciamento de clientes
            // Inclui adição de clientes e exibição de informações
            //Clientes
            Console.WriteLine("===============================Lista Clientes===================================================");
            Cliente cliente1 = new Cliente("Miguel", DateOnly.Parse("1992-07-19"), "miguel@outllok.pt", 923189417, Tipo.Novo, DateOnly.Parse("2024-10-31"));
            Cliente cliente2 = new Cliente("Maria", DateOnly.Parse("2001-03-24"), "maria@gmail.com", 918362084, Tipo.Socio, DateOnly.Parse("2022-11-04"));
            gere_clientes.AdicionaLista(cliente1);
            gere_clientes.AdicionaLista(cliente2);
            gere_clientes.MostrarInformacoes();
            gere_clientes.AdicionaListaFicheiro("../../../TxtFiles/clientes.txt");
            Console.WriteLine("\n");
            #endregion

            #region Espetaculos
            // Criação e gerenciamento de espetáculos
            // Inclui adição de espetáculos, animais, funcionários e clientes aos espetáculos
            //Espetaculos
            Console.WriteLine("===============================Lista Espetaculos===================================================");
            Espetaculo espetaculo1 = new Espetaculo(1, DateTime.Parse("2024-12-01 15:30"), "Espetaculo Golfinhos", TimeSpan.Parse("02:30:00"), TipoEspetaculo.Golfinhos);
            Espetaculo espetaculo2 = new Espetaculo(2, DateTime.Parse("2024-12-05 14:30"), "Espetaculo Canarios", TimeSpan.Parse("02:00:00"), TipoEspetaculo.Cnarios);
            espetaculo1.AdicionarAnimalEspetaculoLista(animal2);
            espetaculo1.AdicionarFuncionarioEspetaculoLista(funcionario1);
            espetaculo1.AdicionarClienteEspetaculoLista(cliente1);
            espetaculo2.AdicionarAnimalEspetaculoLista(animal3);
            espetaculo2.AdicionarFuncionarioEspetaculoLista(funcionario3);
            espetaculo2.AdicionarClienteEspetaculoLista(cliente2);
            gere_espetaculos.AdicionaLista(espetaculo1);
            gere_espetaculos.AdicionaLista(espetaculo2);
            espetaculo1.MostrarInformacoesEspetaculo(espetaculo1);
            espetaculo2.MostrarInformacoesEspetaculo(espetaculo2);
            gere_espetaculos.AdicionaListaFicheiro("../../../TxtFiles/espetaculos.txt");
            Console.WriteLine("\n");
            #endregion

            #region Bilhetes
            // Criação e gerenciamento de bilhetes
            // Inclui adição de bilhetes e exibição de informações
            //Bilhetes
            Console.WriteLine("===============================Lista Bilhetes===================================================");
            Bilhete bilhete1 = new Bilhete(1, 10, DateTime.Parse("2024-11-30 10:40"), "B16", cliente1, espetaculo1);
            Bilhete bilhete2 = new Bilhete(2, 10, DateTime.Parse("2024-12-05 12:20"), "A21", cliente2, espetaculo2);
            gere_bilhetes.AdicionaLista(bilhete1);
            gere_bilhetes.AdicionaLista(bilhete2);
            gere_bilhetes.MostrarInformacoes();
            gere_bilhetes.AdicionaListaFicheiro("../../../TxtFiles/bilhetes.txt");
            Console.WriteLine("\n");
            #endregion
        }
    }
}


