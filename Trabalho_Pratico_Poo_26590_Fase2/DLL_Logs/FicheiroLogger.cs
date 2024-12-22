using System.IO;

namespace DLL_Logs
{
    /// <summary>
    /// Classe responsável por registrar logs num ficheiro de texto.
    /// </summary>
    public class FileLogger
    {
        /// <summary>
        /// Escreve uma mensagem de log num ficheiro de texto.
        /// </summary>
        /// <param name="mensagem">A mensagem a ser registrada no log.</param>
        public void EscreveFicheiroLog(string mensagem)
        {
            using (StreamWriter writer = new StreamWriter("../../../TxtFiles/logs.txt", true))  // true para adicionar no final
            {
                Log(mensagem, writer);
            }
        }
        /// <summary>
        /// Formata e escreve uma mensagem de log usando o TextWriter fornecido.
        /// </summary>
        /// <param name="mensagem">A mensagem a ser registaada no log.</param>
        /// <param name="txtWriter">O TextWriter usado para escrever o log.</param>
        public void Log(string mensagem, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", mensagem);
                txtWriter.WriteLine("---------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                txtWriter.WriteLine(ex.ToString());
            }
        }
    }
}