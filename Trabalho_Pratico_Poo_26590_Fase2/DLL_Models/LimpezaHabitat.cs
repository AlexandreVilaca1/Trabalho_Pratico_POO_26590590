using DLL_Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Models
{
    /// <summary>
    /// Classe que representa as limpezas dos habitats, que tem propriedades, informações e métodos
    public class LimpezaHabitat
    {
        #region Propriedades Privadas
        private int id;
        private Habitat habitat;
        private List<Funcionario> funcionariosLimpeza = new List<Funcionario>();
        private DateTime ultimaLimpeza;
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

        public Habitat Habitat
        {
            get { return this.habitat; }
            set { this.habitat = value; }
        }

        public DateTime UltimaLimpeza
        {
            get { return this.ultimaLimpeza; }
            set { this.ultimaLimpeza = value; }
        }
        #endregion

        #region Construtor
        /// <summary>
        /// Inicializa uma nova instância da classe LimpezaHabitat.
        /// </summary>
        /// <param name="id">O ID da limpeza do habitat.</param>
        /// <param name="habitat">O habitat associado à limpeza.</param>
        /// <param name="ultimaLimpeza">A data da última limpeza realizada.</param>
        public LimpezaHabitat(int id, Habitat habitat, DateTime ultimaLimpeza)
        {
            this.id = id;
            this.habitat = habitat;
            this.ultimaLimpeza = ultimaLimpeza;
            this.logger = new FileLogger();
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Adiciona um funcionário à lista de funcionários responsáveis pela limpeza do habitat.
        /// </summary>
        /// <param name="funcionario">O funcionário a ser adicionado à lista de limpeza.</param>
        public void AdicionarFuncionarioLimpezaLista(Funcionario funcionario)
        {
            try
            {
                if (funcionario == null)
                {
                    throw new Exception("O funcionario que está a tentar inserir está vazio.");
                }
                if (funcionariosLimpeza.Contains(funcionario))
                {
                    throw new Exception($"O funcionario {funcionario.Nome} já está presente na lista.");
                }
                funcionariosLimpeza.Add(funcionario);
                logger.EscreveFicheiroLog($"O funcionario {funcionario.Nome} foi adicionado com sucesso da lista.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                logger.EscreveFicheiroLog($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Retorna uma representação em formato string da instância limpezaHabitat.
        /// </summary>
        /// <returns>Uma string formatada com as informações das limpezas dos habitats, com o id, o habitat referente e a ultima limpeza realizada.</returns>
        public override string ToString()
        {
            string outStr = String.Format("Id: {0}, Habitat: {1}, Ultima Limpeza: {2}", Id, Habitat.Nome, UltimaLimpeza);
            return outStr;
        }

        /// <summary>
        /// Exibe no console as informações detalhadas da limpeza do habitat, incluindo os funcionários responsáveis.
        /// </summary>
        /// <param name="limpezaHabitat">A instância de LimpezaHabitat cujas informações serão exibidas.</param>
        public void MostrarInformacaoLimpezaHabitats(LimpezaHabitat limpezaHabitat)
        {
            Console.WriteLine(limpezaHabitat.ToString());
            Console.WriteLine("Funcionarios Responsaveis:");

            foreach (var funcionario in funcionariosLimpeza)
            {
                Console.WriteLine(funcionario.ToString());
            }
        }
        #endregion
    }
}
