using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Models
{
    abstract public class Pessoa
    {
        /// <summary>
        /// Classe  abstrata que representa uma Pessoa, que tem propriedades, informações e metodos que vão ser herdados pelas suas subclasses.
        /// </summary>
        #region Propriedades Privadas
        private string nome;
        private int telefone;
        private DateOnly dataNascimento;
        private string email;
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
                {
                    this.nome = value;
                }
            }
        }
        public int Telefone
        {
            get { return this.telefone; }
            set { this.telefone = value; }
        }
        public DateOnly DataNascimento
        {
            get { return this.dataNascimento; }
            set
            {
                this.dataNascimento = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (value.Length > 0)
                {
                    this.email = value;
                }
            }
        }
        #endregion

        #region Construtor
        /// <summary>
        /// Inicializa uma nova instância da classe Pessoa.
        /// </summary>
        /// <param name="nome">O nome da pessoa.</param>
        /// <param name="dataNascimento">A data de nascimento da pessoa.</param>
        /// <param name="email">O endereço de email da pessoa.</param>
        /// <param name="telefone">O número de telefone da pessoa.</param>
        public Pessoa(string nome, DateOnly dataNascimento, string email, int telefone)
        {
            this.nome = nome;
            this.dataNascimento = dataNascimento;
            this.email = email;
            this.telefone = telefone;
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Método abstrato para obter o número de telefone da pessoa, todas as subclasses terão de implementar este método.
        /// </summary>
        /// <returns>O número de telefone da pessoa.</returns>
        public abstract int GetTelefone();
        /// <summary>
        /// Método abstrato para obter o endereço de email da pessoa, todas as subclasses terão de implementar este método.
        /// </summary>
        /// <returns>O endereço de email da pessoa.</returns>
        public abstract string GetEmail();
        #endregion

    }

}
