using DLL_Models;
using DLL_Enums;
using NUnit.Framework;

namespace Testes
{
    /// <summary>
    /// Classe de testes para a classe Funcionario.
    /// </summary>
    public class TesteFuncionarios
    {
        /// <summary>
        /// Testa para verificar se o método ToString da classe Funcionario retorna a string formatada corretamente.
        /// </summary>
        [TestCase(1, "João Silva", "1990-05-20", "joaosilva@gmail.com", 926371260, TipoFuncionario.Manutenção, "Id: 1, Nome: João Silva, DataNascimento: 20/05/1990, Email: joaosilva@gmail.com, Telefone: 926371260, Especificacao: Manutenção")]
        [TestCase(2, "Maria Santos", "2002-10-10", "mariasantos@gmail.com", 987654321, TipoFuncionario.Manutenção, "Id: 2, Nome: Maria Santos, DataNascimento: 10/10/2002, Email: mariasantos@gmail.com, Telefone: 987654321, Especificacao: Manutenção")]
        public void ToString_DeveRetornarStringCorreta(int id, string nome, string dataNascimento, string email, int telefone, TipoFuncionario tipo, string excpected)
        {
            // Arrange
            DateOnly dataNascimentoFormatada = DateOnly.Parse(dataNascimento);
            Funcionario funcionario = new Funcionario(id, nome, dataNascimentoFormatada, email, telefone, tipo);

            // Act
            string resultado = funcionario.ToString();

            // Assert
            Assert.That(resultado, Is.EqualTo(excpected));
        }

        /// <summary>
        /// Testa para verificar se o método CalcularIdade da classe Funcionario retorna a idade correta com base na data de nascimento.
        /// </summary>
        [TestCase(2000, 1, 1, 24)] // Espera-se que a idade seja 24 em 2024
        [TestCase(1995, 12, 31, 28)] // Espera-se que a idade seja 28 em 2024
        public void CalcularIdade_DeveRetornarIdadeCorreta(int ano, int mes, int dia, int excpected)
        {
            // Arrange
            Funcionario funcionario = new Funcionario(10, "João Silva", new DateOnly(ano, mes, dia), "joao.silva@email.com", 926371260, TipoFuncionario.Manutenção);

            // Act
            int resultado = funcionario.CalcularIdade(funcionario);

            // Assert
            Assert.That(resultado, Is.EqualTo(excpected));
        }
    }
}