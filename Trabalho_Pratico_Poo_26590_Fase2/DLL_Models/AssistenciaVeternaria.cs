using DLL_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Enums;
using DLL_Logs;

namespace DLL_Models
{
    /// <summary>
    /// Classe que representa uma assistencia, com as suas propriedades, informações e métodos.
    /// </summary>
    public class AssistenciaVeternaria
    {
        #region Propriedades Privadas
        private int id;
        private Animal animal;
        private List<Funcionario> funcionariosAssistencia = new List<Funcionario>();
        private DateTime dataAssistencia;
        private TipoAssistencia tipoAssistencia;
        private string relatorio;
        private FileLogger logger;
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
        public DateTime DataAssistencia
        {
            get { return this.dataAssistencia; }
            set { this.dataAssistencia = value; }
        }
        public TipoAssistencia TipoAssistencia
        {
            get { return this.tipoAssistencia; }
            set
            {
                if (Enum.IsDefined(typeof(TipoFuncionario), value))
                {
                    this.tipoAssistencia = value;
                }
            }
        }
        public Animal Animal
        {
            get { return this.animal; }
            set { this.animal = value; }
        }

        public string Relatorio
        {
            get { return this.relatorio; }
            set
            {
                if (value.Length > 0)
                {

                    this.relatorio = value;
                }
            }
        }
        #endregion
        /// <summary>
        /// Inicializa uma nova instância da classe AssistenciaVeternaria.
        /// </summary>
        /// <param name="id">O ID da assistência veterinária.</param>
        /// <param name="dataAssistencia">A data da assistência veterinária.</param>
        /// <param name="tipoAssistencia">O tipo de assistência veterinária.</param>
        /// <param name="relatorio">O relatório da assistência veterinária.</param>
        #region Construtor
        public AssistenciaVeternaria(int id, DateTime dataAssistencia, TipoAssistencia tipoAssistencia, string relatorio, Animal animal)
        {
            this.id = id;
            this.dataAssistencia = dataAssistencia;
            this.tipoAssistencia = tipoAssistencia;
            this.relatorio = relatorio;
            this.animal = animal;
            this.animal = animal;
            this.logger = new FileLogger();
        }
        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Adiciona um funcionário à lista de funcionários responsáveis pela assistência.
        /// </summary>
        /// <param name="funcionario">O funcionário a ser adicionado à assistência.</param>
        public void AdicionarFuncionarioAssistenciaLista(Funcionario funcionario)
        {
            try
            {
                if (funcionario == null)
                {
                    throw new Exception("O objeto que está a tentar inserir está vazio.");
                }
                if (funcionariosAssistencia.Contains(funcionario))
                {
                    throw new Exception($"O objeto {funcionario.Nome} já está presente na lista.");
                }
                funcionariosAssistencia.Add(funcionario);
                logger.EscreveFicheiroLog($"O funcionario {funcionario.Nome} foi adicionada com sucesso á lista.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                logger.EscreveFicheiroLog($"Erro: {ex.Message}");
            }
        }
        /// <summary>
        /// Retorna uma representação em formato string da instância assistencia veterinária.
        /// </summary>
        /// <returns>Uma string formatada com as informações da assistencia veterinária, com id, data da assistência, tipo de assistência e o relatório.</returns>
        public override string ToString()
        {
            string outStr = String.Format("Id: {0}, Data Assistencia: {1}, Tipo de Assistencia: {2}, Relatorio: {3}, Animal: {4}", Id, DataAssistencia, TipoAssistencia, Relatorio, Animal.Nome);
            return outStr;
        }

        /// <summary>
        /// Exibe na consola as informações detalhadas da assistência veterinária, incluindo animais assistidos e funcionários responsáveis.
        /// </summary>
        /// <param name="assistenciaVeternaria">A assistência veterinária cujas informações serão exibidas.</param>
        public void MostrarInformacoesAssistenciasVeternarias(AssistenciaVeternaria assistenciaVeternaria)
        {
            Console.WriteLine(assistenciaVeternaria.ToString());

            Console.WriteLine("Funcionários Responsáveis:");
            foreach (var funcionario in funcionariosAssistencia)
            {
                Console.WriteLine(funcionario.ToString());
            }
        }
        #endregion
    }
}
