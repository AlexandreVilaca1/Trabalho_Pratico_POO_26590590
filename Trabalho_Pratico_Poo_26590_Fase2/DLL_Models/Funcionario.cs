using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using DLL_Enums;

namespace DLL_Models
{
    public class Funcionario : Pessoa
    {
        /// <summary>
        /// Classe que representa um funcionario que herda da classe Pessoa propeiedades e métoddos.
        /// </summary>
        #region Propriedades Privadas
        private int id;
        private TipoFuncionario especificacao;
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
        public TipoFuncionario Especificacao
        {
            get { return this.especificacao; }

            set
            {
                if (Enum.IsDefined(typeof(TipoFuncionario), value))
                {
                    this.especificacao = value;
                }
            }
        }
        #endregion

        #region Construtor
        public Funcionario(int id, string nome, DateOnly dataNnascimento, string email, int telefone, TipoFuncionario especificacao) : base(nome, dataNnascimento, email, telefone)
        {
            this.id = id;
            this.especificacao = especificacao;
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Calcula a idade do funcionário com base na data atual.
        /// </summary>
        /// <param name="funcionário">O animal cuja idade será calculada.</param>
        /// <returns>A idade do funcionário em anos.</returns>
        public int CalcularIdade(Funcionario funcionario)
        {
            DateOnly data_atual = DateOnly.FromDateTime(DateTime.Now);
            int idade = data_atual.Year - funcionario.DataNascimento.Year;
            if (DataNascimento > data_atual.AddYears(-idade)) idade--;
            Console.WriteLine($"O funcionario {funcionario.Nome} tem {idade} anos");
            return idade;
        }
        /// <summary>
        /// Retorna uma representação em formato string da instância funcionário.
        /// </summary>
        /// <returns>Uma string formatada com as informações do funcionario, com o id, nome, data de nascimento, enail, teledone e especificacao.</returns>
        public override string ToString()
        {
            string outStr = String.Format("Id: {0}, Nome: {1}, DataNascimento: {2}, Email: {3}, Telefone: {4}, Especificacao: {5}", Id, Nome, DataNascimento, Email, Telefone, Especificacao);
            return outStr;
        }
        /// <summary>
        /// Obtém o número de telefone do funcionário, método herdado da classe abstrata Pessoa.
        /// </summary>
        /// <returns>O número de telefone do funcionário.</returns>
        public override int GetTelefone()
        {
            return Telefone;
        }

        /// <summary>
        /// Obtém o email do funcionário, método herdado da classe abstrata Pessoa.
        /// </summary>
        /// <returns>O email do funcionário.</returns>
        public override string GetEmail()
        {
            return Email;
        }
        #endregion
    }
}






