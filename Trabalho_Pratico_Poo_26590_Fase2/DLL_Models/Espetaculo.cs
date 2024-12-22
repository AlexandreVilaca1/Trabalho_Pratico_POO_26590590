using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Enums;
using DLL_Logs;
using DLL_Models;

namespace DLL_Models
{
    public class Espetaculo
    {
        /// <summary>
        /// Classe que representa um espetaculo, que tem propriedades, informações e métodos.
        /// </summary>
        #region Propriedades Privadas
        private int id;
        private DateTime data;
        private string nome;
        private List<Animal> animaisEspetaculo = new List<Animal>();
        private List<Funcionario> funcionariosEspetaculo = new List<Funcionario>();
        private List<Cliente> clientesEspetaculo = new List<Cliente>();
        private TimeSpan duracao;
        private TipoEspetaculo tipoEspetaculo;
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
        public DateTime Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public string Nome
        {
            get { return this.nome; }
            set
            {
                if (value.Length > 0)
                    this.nome = value;
            }
        }
        public TimeSpan Duracao
        {
            get { return this.duracao; }
            set { this.duracao = value; }
        }
        public TipoEspetaculo TipoEspetaculo
        {
            get { return this.tipoEspetaculo; }
            set
            {
                if (Enum.IsDefined(typeof(TipoFuncionario), value))
                {
                    this.tipoEspetaculo = value;
                }
            }
        }
        #endregion

        #region Construtor
        /// <summary>
        /// Inicializa uma nova instância da classe Espetaculo.
        /// </summary>
        /// <param name="id">O ID do espetáculo.</param>
        /// <param name="data">A data do espetáculo.</param>
        /// <param name="nome">O nome do espetáculo.</param>
        /// <param name="duracao">A duração do espetáculo.</param>
        /// <param name="tipoEspetaculo">O tipo de espetáculo.</param>
        public Espetaculo(int id, DateTime data, string nome, TimeSpan duracao, TipoEspetaculo tipoEspetaculo)
        {
            this.id = id;
            this.data = data;
            this.nome = nome;
            this.duracao = duracao;
            this.tipoEspetaculo = tipoEspetaculo;
            this.logger = new FileLogger();
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Adiciona um animal à lista de animais do espetáculo.
        /// </summary>
        /// <param name="animal">O animal a ser adicionado ao espetáculo.</param>
        public void AdicionarAnimalEspetaculoLista(Animal animal)
        {
            try
            {
                if (animal == null)
                {
                    throw new Exception($"O animal que está a tentar inserir está vazio.");
                }
                if (animaisEspetaculo.Contains(animal))
                {
                    throw new Exception($"O animal {animal.Nome} já está presente na lista.");
                }
                animaisEspetaculo.Add(animal);
                logger.EscreveFicheiroLog($"O animal {animal.Nome} foi adicionada com sucesso á lista.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                logger.EscreveFicheiroLog($"Erro: {ex.Message}");
            }
        }
        /// <summary>
        /// Adiciona um funcionário à lista de funcionários do espetáculo.
        /// </summary>
        /// <param name="funcionario">O funcionário a ser adicionado ao espetáculo.</param>
        public void AdicionarFuncionarioEspetaculoLista(Funcionario funcionario)
        {
            try
            {
                if (funcionario == null)
                {
                    throw new Exception("O funcionario que está a tentar inserir está vazio.");
                }
                if (funcionariosEspetaculo.Contains(funcionario))
                {
                    throw new Exception($"O funcionario {funcionario.Nome} já está presente na lista.");
                }
                funcionariosEspetaculo.Add(funcionario);
                logger.EscreveFicheiroLog($"O funcionario {funcionario.Nome} foi adicionado com sucesso á lista.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                logger.EscreveFicheiroLog($"Erro: {ex.Message}");
            }
        }
        /// <summary>
        /// Adiciona um cliente à lista de clientes do espetáculo.
        /// </summary>
        /// <param name="cliente">O cliente a ser adicionado ao espetáculo.</param>
        public void AdicionarClienteEspetaculoLista(Cliente cliente)
        {
            try
            {
                if (cliente == null)
                {
                    throw new Exception("O cliente que está a tentar inserir está vazio.");
                }
                if (clientesEspetaculo.Contains(cliente))
                {
                    throw new Exception($"O cliente {cliente.Nome} já está presente na lista.");
                }
                clientesEspetaculo.Add(cliente);
                logger.EscreveFicheiroLog($"O cliente {cliente.Nome} foi adicionado com sucesso á lista.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                logger.EscreveFicheiroLog($"Erro: {ex.Message}");
            }
        }
        /// <summary>
        /// Retorna uma representação em formato string da instância espetáculo.
        /// </summary>
        /// <returns>Uma string formatada com as informações do espetáculo, com o id, nome, data do espetáculo e duração.</returns>
        public override string ToString()
        {
            string outStr = String.Format("Id: {0}, Nome: {1}, Data: {2}, Duracao: {3}", Id, Nome, Data, Duracao);
            return outStr;
        }

        /// <summary>
        /// Retorna uma representação em formato string da instância espetáculo.
        /// </summary>
        /// <returns>Uma string formatada com as informações do espetáculo, incluindo id, nome, data do espetáculo e duração.</returns>
        public void MostrarInformacoesEspetaculo(Espetaculo espetaculo)
        {

            Console.WriteLine(espetaculo.ToString());


            Console.WriteLine("Animais Participantes:");
            foreach (var animal in animaisEspetaculo)
            {
                Console.WriteLine(animal.ToString());
            }

            Console.WriteLine("Funcionários Responsáveis:");
            foreach (var funcionario in funcionariosEspetaculo)
            {
                Console.WriteLine(funcionario.ToString());
            }

            Console.WriteLine("Clientes a assistir:");
            foreach (var cliente in clientesEspetaculo)
            {
                Console.WriteLine(cliente.ToString());
            }
        }
        #endregion
    }


}
