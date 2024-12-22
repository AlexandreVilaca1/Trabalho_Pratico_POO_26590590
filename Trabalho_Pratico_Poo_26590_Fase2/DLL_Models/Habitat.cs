using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Enums;
using DLL_Models;
using DLL_Interfaces;
using DLL_Logs;

namespace DLL_Models
{
    public class Habitat : IContador
    {
        /// <summary>
        /// Classe que representa um Habitat do zoo, que tem propriedades, informações e métodos, implementa método proveniente da interface.
        /// </summary>
        #region Propriedades Privadas
        private int id;
        private string nome;
        private List<Funcionario> funcionariosHabitat = new List<Funcionario>();
        private List<Animal> animaisHabitat = new List<Animal>();
        private DateTime ultimaManutencao;
        private readonly FileLogger logger;
        #endregion

        /// <summary>
        /// Permite ter acesso e modificar as propriedades privadas, através das propriedades públicas
        /// </summary>
        #region Propriedades Publicas
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Nome
        {
            get { return this.nome; }
            set
            {
                if (value.Length > 0)
                {
                    this.nome = value;
                }
            }
        }
        public DateTime UltimaManutencao
        {
            get { return this.ultimaManutencao; }
            set
            {
                this.ultimaManutencao = value;
            }
        }
        #endregion

        #region Construtor
        /// <summary>
        /// Inicializa uma nova instância da classe Habitat.
        /// </summary>
        /// <param name="id">O ID do habitat.</param>
        /// <param name="nome">O nome do habitat.</param>
        /// <param name="ultimaManutencao">A data da última manutenção do habitat.</param>
        public Habitat(int id, string nome, DateTime ultimaManutencao)
        {
            this.id = id;
            this.nome = nome;
            this.ultimaManutencao = ultimaManutencao;
            this.logger = new FileLogger();
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Adiciona um funcionário à lista de funcionários do habitat.
        /// </summary>
        /// <param name="funcionario">O funcionário a ser adicionado ao habitat.</param>
        public void AdicionarFuncionariosHabitatLista(Funcionario funcionario)
        {
            try
            {
                if (funcionario == null)
                {
                    throw new Exception("O funcionario que está a tentar inserir está vazio.");
                }
                if (funcionariosHabitat.Contains(funcionario))
                {
                    throw new Exception($"O objeto {funcionario.Nome} já está presente na lista.");
                }
                funcionariosHabitat.Add(funcionario);
                logger.EscreveFicheiroLog($"O funcionario {funcionario.Nome} foi adicionado com sucesso á lista.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                logger.EscreveFicheiroLog($"Erro: {ex.Message}");
            }
            
        }

        /// <summary>
        /// Remove um funcionário da lista de funcionários do habitat.
        /// </summary>
        /// <param name="funcionario">O funcionário a ser removido do habitat.</param>
        public void RemoverFuncionarioHabitatLista(Funcionario funcionario)
        {
            try
            {
                if (funcionario == null)
                {
                    throw new Exception("O funcionario que está a tentar remover está vazio.");
                }
                if (!funcionariosHabitat.Contains(funcionario))
                {
                    throw new Exception($"O funcionario {funcionario.Nome} já não está presente na lista.");
                }
                funcionariosHabitat.Remove(funcionario);
                logger.EscreveFicheiroLog($"O funcionario {funcionario.Nome} foi removido com sucesso da lista.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                logger.EscreveFicheiroLog($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Adiciona um animal à lista de animais do habitat.
        /// </summary>
        /// <param name="animal">O animal a ser adicionado ao habitat.</param>
        public void AdicionarAnimaisHabitatLista(Animal animal)
        {
            try
            {
                if (animal == null)
                {
                    throw new Exception("O animal que está a tentar inserir está vazio.");
                }
                if (animaisHabitat.Contains(animal))
                {
                    throw new Exception($"O animal {animal.Nome} já está presente na lista.");
                }
                animaisHabitat.Add(animal);
                logger.EscreveFicheiroLog($"O animal {animal.Nome} foi adicionado com sucesso á lista.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                logger.EscreveFicheiroLog($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Remove um animal da lista de animais do habitat.
        /// </summary>
        /// <param name="animal">O animal a ser removido do habitat.</param>
        public void RemoverAnimalHabitatLista(Animal animal)
        {
            try
            {
                if (animal == null)
                {
                    throw new Exception("O animal que está a tentar remover está vazio.");
                }
                if (!animaisHabitat.Contains(animal))
                {
                    throw new Exception($"O animal {animal.Nome} já não está presente na lista.");
                }
                animaisHabitat.Remove(animal);
                logger.EscreveFicheiroLog($"O animal {animal.Nome} foi removido com sucesso da lista.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                logger.EscreveFicheiroLog($"Erro: {ex.Message}");

            }
        }

        /// <summary>
        /// Conta e mostra a quantidade de animais no habitat.
        /// </summary>
        /// <returns>O número de animais no habitat.</returns>
        public int Contador()
        {
            Console.WriteLine($"Quantidade de Animais: {animaisHabitat.Count}\n");
            return animaisHabitat.Count;
        }

        /// <summary>
        /// Retorna uma representação em formato string da instância Habitat.
        /// </summary>
        /// <returns>Uma string formatada com as informações do habitat, com o id, nome e ultima manutenção.</returns>
        public override string ToString()
        {
            string outStr = String.Format("Id: {0}, Nome: {1}, Ultima Manutencaoa: {2}", Id, Nome, UltimaManutencao);
            return outStr;
        }

        /// <summary>
        /// Exibe no console as informações detalhadas do habitat, incluindo funcionários e animais.
        /// </summary>
        /// <param name="habitat">O habitat cujas informações serão exibidas.</param>
        public void MostrarInformacoesHabitat(Habitat habitat)
        {

            Console.WriteLine(habitat.ToString());

            Console.WriteLine("Funcionarios");
            foreach (var funcionario in funcionariosHabitat)
            {
                Console.WriteLine(funcionario.ToString());
            }

            Console.WriteLine("Animais");
            foreach (var animal in animaisHabitat)
            {
                Console.WriteLine(animal.ToString());
            }
        }
        #endregion

    }

}
