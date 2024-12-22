using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Models;
using DLL_Enums;
using DLL_Logs;

namespace DLL_Models
{
    /// <summary>
    /// Classe que representa um animal com as suas propriedades, informações e métodos.
    /// </summary>
    public class Animal
    {
        #region Propriedades Privadas
        private int id;
        private TipoAnimal tipo;
        private string nome;
        private DateOnly dataNascimento;
        private Grupo grupo;
        private List<Alimentacao> dietaAnimais = new List<Alimentacao>();
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

        public TipoAnimal Tipo
        {
            get { return this.tipo; }
            set
            {
                if (Enum.IsDefined(typeof(TipoFuncionario), value))
                {
                    this.tipo = value;
                }
            }
        }

        public DateOnly DataNascimento
        {
            get { return this.dataNascimento; }
            set { this.dataNascimento = value; }
        }

        public Grupo Grupo
        {
            get { return this.grupo; }
            set
            {
                if (Enum.IsDefined(typeof(TipoFuncionario), value))
                {
                    this.grupo = value;
                }
            }
        }
        #endregion

        /// <summary>
        /// Inicializa uma nova instância da classe Animal.
        /// </summary>
        /// <param name="id">O ID do animal.</param>
        /// <param name="tipo">O tipo do animal.</param>
        /// <param name="nome">O nome do animal.</param>
        /// <param name="dataNascimento">A data de nascimento do animal.</param>
        /// <param name="grupo">O grupo do animal.</param>
        #region Construtor
        public Animal(int id, TipoAnimal tipo, string nome, DateOnly dataNascimento, Grupo grupo)
        {
            this.id = id;
            this.tipo = tipo;
            this.nome = nome;
            this.dataNascimento = dataNascimento;
            this.grupo = grupo;
            this.logger = new FileLogger();
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Compara os animais presentes na lista com o animal genérico passado por parâmetro para verificar se são iguais.
        /// </summary>
        /// <param name="generico">O objeto a ser comparado.</param>
        /// <returns>True se os objetos são iguais, False caso contrário.</returns>
        public override bool Equals(object generico)
        {
            if (generico is not Animal other) return false; 

            return Id == other.Id;
        }

        /// <summary>
        /// Adiciona uma alimentação à lista de dieta do animal.
        /// </summary>
        /// <param name="alimentacao">A alimentação a ser adicionada.</param>
        public void AdicionarAlimentacaoAnimalLista(Alimentacao alimentacao)
        {
            try
            {
                if (alimentacao == null)
                {
                    throw new Exception("A alimentacao que está a tentar inserir está vazia.");
                }
                if (dietaAnimais.Contains(alimentacao))
                {
                    throw new Exception($"A alimentacao com data {alimentacao.DataRefeicao} já está presente na lista.");
                }
                dietaAnimais.Add(alimentacao);
                logger.EscreveFicheiroLog($"A alimentacao com data {alimentacao.DataRefeicao} foi adicionada com sucesso á lista.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                logger.EscreveFicheiroLog($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Adiciona a lista de alimentações do animal a um ficheiro.
        /// </summary>
        /// <param name="filePath">O caminho do ficheiro onde as alimentações vão ser adicionadas.</param>
        public void AdicionaListaAlimentacoesFicheiro(string filePath)
        {
            try
            {
                var existingLines = File.ReadAllLines(filePath);

                var novasAlimentacoes = new List<string>();

                foreach (var alimentacao in dietaAnimais)
                {
                    if (alimentacao != null)
                    {
                        string alimentacoes = alimentacao.ToString();

                        if (!existingLines.Contains(alimentacoes))
                        {
                            novasAlimentacoes.Add(alimentacoes);
                        }
                        else
                        {
                            logger.EscreveFicheiroLog($"A alimentacao, {alimentacao}, já está presente no ficheiro e foi ignorado.");
                        }
                    }
                }
                File.AppendAllLines(filePath, novasAlimentacoes);
                logger.EscreveFicheiroLog($"Foram adicionados {novasAlimentacoes.Count} alimentacoes ao ficheiro com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                logger.EscreveFicheiroLog($"Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Calcula a idade do animal com base na data atual.
        /// </summary>
        /// <param name="animal">O animal cuja idade será calculada.</param>
        /// <returns>A idade do animal em anos.</returns>
        public int CalcularIdade(Animal animal)
        {
            DateOnly data_atual = DateOnly.FromDateTime(DateTime.Now);
            int idade = data_atual.Year - animal.DataNascimento.Year;
            if (DataNascimento > data_atual.AddYears(-idade)) idade--;
            return idade;
        }

        /// <summary>
        /// Retorna uma representação em formato string da instância alimentacao.
        /// </summary>
        /// <returns>Uma string formatada com as informações da refeição, com calorias, quantidade, tipo de comida, data da refeição e o nome do animal.</returns>
        public override string ToString()
        {

            string outStr = String.Format("Id: {0}, Tipo: {1}, Nome: {2}, DataNascimento: {3}, Grupo: {4}", Id, Tipo, Nome, DataNascimento, Grupo);
            return outStr;

        }

        /// <summary>
        /// Exibe a alimentação do animal na consola.
        /// </summary>
        /// <param name="animal">O animal cuja alimentação serão exibida.</param>
        public void MostrarAlimentacaoAnimal(Animal animal)
        {
            Console.WriteLine($"Alimentacao Animal {animal.id}:");
            foreach (var alimentacao in dietaAnimais)
            {
                Console.WriteLine(alimentacao.ToString());
            }
        }
        #endregion
    }
}

