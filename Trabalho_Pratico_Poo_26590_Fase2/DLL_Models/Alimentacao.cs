using DLL_Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DLL_Models
{
    /// <summary>
    /// Classe que uma refeição de um animal com as suas propriedadese, informações e métodos.
    /// </summary>
    /// </summary>
    public class Alimentacao
    {
        #region Propriedades Privadas
        private int calorias;
        private int quantidade;
        private TipoComida tipoComida;
        private DateTime dataRefeicao;
        private Animal animal;
        #endregion

        /// <summary>
        /// Permite ter acesso ou modificar as propriedades privadas, através das propriedades públicas
        /// </summary>
        #region Propriedades Publicas
        public int Calorias
        {
            get { return this.calorias; }
            set { this.calorias = value; }
        }

        public int Quantidade
        {
            get { return this.quantidade; }
            set { this.quantidade = value; }
        }

        public TipoComida TipoComida
        {
            get { return this.tipoComida; }
            set
            {
                if (Enum.IsDefined(typeof(TipoFuncionario), value))
                {
                    this.tipoComida = value;
                }
            }
        }

        public DateTime DataRefeicao
        {
            get { return this.dataRefeicao; }
            set { this.dataRefeicao = value; }
        }
        public Animal Animal
        {
            get { return this.animal; }
            set { this.animal = value; }
        }
        #endregion

        /// <summary>
        /// Inicializa uma nova instância da classe Alimentacao.
        /// </summary>
        /// <param name="calorias">A quantidade de calorias da refeição.</param>
        /// <param name="quantidade">A quantidade de alimento da refeição.</param>
        /// <param name="tipoComida">O tipo de comida da refeição.</param>
        /// <param name="dataRefeicao">A data e hora da refeição.</param>
        /// <param name="animal">O animal associado à refeição.</param>
        #region Construtor
        public Alimentacao(int calorias, int quantidade, TipoComida tipoComida, DateTime dataRefeicao, Animal animal)   
        {
            this.calorias = calorias;
            this.quantidade = quantidade;
            this.tipoComida = tipoComida;
            this.dataRefeicao = dataRefeicao;
            this.animal = animal;
        }
        #endregion
        /// <summary>
        /// Retorna uma representação em formato string da instância alimentacao.
        /// </summary>
        /// <returns>Uma string formatada com as informações da refeição, com calorias, quantidade, tipo de comida, data da refeição e o nome do animal.</returns>
        #region Metodos Publicos
        public override string ToString()
        {

            string outStr = String.Format("Calorias: {0}, Quantidade: {1}, Tipo Comida: {2}, Data Refeicao: {3}, Animal: {4}", Calorias, Quantidade, TipoComida, DataRefeicao, animal.Nome);
            return outStr;

        }
        #endregion

    }
}
