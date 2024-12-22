using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Enums;


namespace DLL_Models
{
    /// <summary>
    /// Classe que representa um cliente que herda da classe pessoa propriedades, informações e métodos.
    /// </summary>
    public class Cliente : Pessoa
    {
        #region Propriedades Privadas
        private Tipo tipo;
        private DateOnly dataRegisto;
        #endregion

        /// <summary>
        /// Permite ter acesso e modificar as propriedades privadas, através das propriedades públicas
        /// </summary>
        #region Propriedades Publicas
        public Tipo TipoCliente
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

        public DateOnly DataRegisto
        {
            get { return this.dataRegisto; }
            set { this.dataRegisto = value; }

        }
        #endregion

        #region Construtor
        /// <summary>
        /// Inicializa uma nova instância da classe Cliente.
        /// </summary>
        /// <param name="nome">O nome do cliente.</param>
        /// <param name="dataNascimento">A data de nascimento do cliente.</param>
        /// <param name="email">O email do cliente.</param>
        /// <param name="telefone">O número de telefone do cliente.</param>
        /// <param name="tipo">O tipo de cliente.</param>
        /// <param name="dataRegisto">A data de registo do cliente.</param>
        public Cliente(string nome, DateOnly dataNascimento, string email, int telefone, Tipo tipo, DateOnly dataRegisto) : base(nome, dataNascimento, email, telefone)
        {
            this.tipo = tipo;
            this.dataRegisto = dataRegisto;
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Obtém o número de telefone do cliente, método herdado da classe abstrata Pessoa.
        /// </summary>
        /// <returns>O número de telefone do cliente.</returns>
        public override int GetTelefone()
        {
            return Telefone;
        }

        /// <summary>
        /// Obtém o email do cliente, método herdado da classe abstrata Pessoa.
        /// </summary>
        /// <returns>O email do cliente.</returns>
        public override string GetEmail()
        {
            return Email;
        }
        /// <summary>
        /// Retorna uma representação em formato string da instância cliente.
        /// </summary>
        /// <returns>Uma string formatada com as informações do cliente, com o nome, data de nascimento email, telefone, tipo e data de registo</returns>
        public override string ToString()
        {
            string outStr = String.Format("Nome: {0}, DataNascimento: {1}, Email: {2}, Telefone: {3}, Tipo: {4}, DataRegisto: {5}", Nome, DataNascimento, Email, Telefone, TipoCliente, DataRegisto);
            return outStr;
        }
        #endregion
    }
}
