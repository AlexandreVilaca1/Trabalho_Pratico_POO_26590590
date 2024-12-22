using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Enums;

namespace DLL_Models
{
    /// <summary>
    /// Classe que representa um bilhete, com as suas propriedades, informações e métodos.
    /// </summary>
    public class Bilhete
    {
        #region Propriedades Privadas
        private int id;
        private DateTime dataEmissao;
        private decimal preco;
        private string numeroAssento;
        private Cliente cliente;
        private Espetaculo espetaculo;
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

        public decimal Preco
        {
            get { return this.preco; }
            set { this.preco = value; }
        }
        public DateTime DataEmissao
        {
            get { return this.dataEmissao; }
            set { this.dataEmissao = value; }
        }
        public Cliente Cliente
        {
            get { return this.cliente; }
            set { this.cliente = value; }
        }
        public Espetaculo Espetaculo
        {
            get { return this.espetaculo; }
            set { this.espetaculo = value; }
        }
        public string NumeroAssento
        {
            get { return this.numeroAssento; }
            set { this.numeroAssento = value; }
        }
        #endregion

        #region Construtor
        /// <summary>
        /// Inicializa uma nova instância da classe Bilhete.
        /// </summary>
        /// <param name="id">O ID do bilhete.</param>
        /// <param name="preco">O preço do bilhete.</param>
        /// <param name="dataEmissao">A data de emissão do bilhete.</param>
        /// <param name="numero_assento">O número de assento do bilhete.</param>
        /// <param name="cliente">O cliente associado ao bilhete.</param>
        /// <param name="espetaculo">O espetáculo associado ao bilhete.</param>
        public Bilhete(int id, decimal preco, DateTime dataEmissao, string numero_assento, Cliente cliente, Espetaculo espetaculo)
        {
            this.id = id;
            this.preco = preco;
            this.dataEmissao = dataEmissao;
            this.numeroAssento = numero_assento;
            this.cliente = cliente;
            this.espetaculo = espetaculo;
        }
        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Retorna uma representação em formato string da instância bilhete.
        /// </summary>
        /// <returns>Uma string formatada com as informações do bilhete, com o id, preço, data de emissão, número do assente, o nome do cliente associado ao bilhete, o tipo de espetaculo e a sua data.</returns>
        public override string ToString()
        {
            string outStr = String.Format("Id: {0}, Preco: {1}, DataEmissao: {2}, NumeroAssento: {3}, Cliente: {4}, TipoEspetaculo: {5}, DataEspetaculo: {6}", Id, Preco, DataEmissao, NumeroAssento, Cliente.Nome, Espetaculo.TipoEspetaculo, Espetaculo.Data);
            return outStr;
        }
        #endregion
    }
}
