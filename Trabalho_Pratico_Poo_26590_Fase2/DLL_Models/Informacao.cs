using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Models
{
    /// <summary>
    /// Classe que representa informações do zoo, que tem propriedades, informações e métodos.
    /// </summary>
    public class Informacao
    {
        #region Propriedades Privadas
        private string nome;
        private string distrito;
        private string codigoPostal;
        private string rua;
        private string descricao;
        #endregion

        /// <summary>
        /// Permite ter acesso e modificar as propriedades privadas, através das propriedades públicas
        /// </summary>
        #region Propriedades Publicas
        public string Nome
        {
            get { return this.nome; }
            set
            {
                if (value.Length > 0)
                    this.nome = value;
            }
        }
        public string Distrito
        {
            get { return this.distrito; }
            set
            {
                if (value.Length > 0)
                    this.distrito = value;
            }
        }
        public string CodigoPostal
        {
            get { return this.codigoPostal; }
            set
            {
                if (value.Length > 0)
                    this.codigoPostal = value;
            }
        }
        public string Rua
        {
            get { return this.rua; }
            set
            {
                if (value.Length > 0)
                    this.rua = value;
            }
        }
        public string Descricao
        {
            get { return this.descricao; }
            set
            {
                if (value.Length > 0)
                    this.descricao = value;
            }
        }
        #endregion

        #region Construtor
        /// <summary>
        /// Inicializa uma nova instância da classe Informacao.
        /// </summary>
        /// <param name="nome">O nome do zoo.</param>
        /// <param name="distrito">O distrito onde o zoo está localizado.</param>
        /// <param name="codigoPostal">O código postal do zoo.</param>
        /// <param name="rua">A rua onde o zoo está localizado.</param>
        /// <param name="descricao">A descrição do zoo.</param>
        public Informacao(string nome, string distrito, string codigoPostal, string rua, string descricao)
        {
            this.nome = nome;
            this.distrito = distrito;
            this.codigoPostal = codigoPostal;
            this.rua = rua;
            this.descricao = descricao;
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Retorna uma representação em formato string da instância informação.
        /// </summary>
        /// <returns>Uma string formatada com as informações do zoo, com o nome, distrito, codigo de postal, rua e odescrição.</returns>
        public override string ToString()
        {
            string outStr = String.Format("Nome: {0}, Distrito: {1}, Codigo-Postal: {2}, Rua: {3}, Descricao: {4}\n", Nome, Distrito, CodigoPostal, Rua, Descricao);
            return outStr;
        }

        /// <summary>
        /// Exibe no console as informações detalhadas do zoo.
        /// </summary>
        /// <param name="zoo">A instância de Informacao cujas informações serão exibidas.</param>
        public void MostrarInformacao(Informacao zoo)
        {
            Console.WriteLine(zoo.ToString());
        }
        #endregion
    }
}
