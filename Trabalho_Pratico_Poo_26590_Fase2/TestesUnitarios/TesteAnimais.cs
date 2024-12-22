using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Models;
using DLL_Enums;
namespace Testes
{
    /// <summary>
    /// Classe de testes para a classe Animal.
    /// </summary>
    public class TesteAniamis
    {
        /// <summary>
        /// Testa para verificar se o método ToString da classe Animal retorna a string formatada corretamente.
        /// </summary>
        [TestCase(4, TipoAnimal.Leao, "Simba", "2020-04-15", Grupo.Mamifero, "Id: 4, Tipo: Leao, Nome: Simba, DataNascimento: 15/04/2020, Grupo: Mamifero")]
        [TestCase(5, TipoAnimal.Tigre, "Somba", "2018-06-17", Grupo.Mamifero, "Id: 5, Tipo: Tigre, Nome: Somba, DataNascimento: 17/06/2018, Grupo: Mamifero")]
        public void ToString_DeveRetornarStringCorreta(int id, TipoAnimal tipo, string nome, string dataNascimento, Grupo grupo, string excpected)
        {
            // Arrange
            DateOnly dataNascimentoFormatada = DateOnly.Parse(dataNascimento);
            Animal animal = new Animal(id, tipo, nome, dataNascimentoFormatada, grupo);

            // Act
            string resultado = animal.ToString();

            // Assert
            Assert.That(resultado, Is.EqualTo(excpected));
        }

        /// <summary>
        /// Testa para verificar se o método CalcularIdade da classe Animal retorna a idade correta com base na data de nascimento.
        /// </summary>
        [TestCase(2021, 4, 18, 3)] // Espera-se que a idade seja 3 em 2024
        [TestCase(2019, 2, 2, 5)] // Espera-se que a idade seja 5 em 2024
        [TestCase(2017, 8, 31, 7)] // Espera-se que a idade seja 7 em 2024
        [TestCase(2022, 10, 12, 2)] // Espera-se que a idade seja 2 em 2024
        public void CalcularIdade_DeveRetornarIdadeCorreta(int ano, int mes, int dia, int excpected)
        {
            // Arrange
            Animal animal = new Animal(10, TipoAnimal.Elefante, "Telmo", new DateOnly(ano, mes, dia), Grupo.Mamifero);

            // Act
            int resultado = animal.CalcularIdade(animal);

            // Assert
            Assert.That(resultado, Is.EqualTo(excpected));
        }
    }
}
