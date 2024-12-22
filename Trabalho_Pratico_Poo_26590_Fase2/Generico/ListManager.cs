namespace DLL_Generic;
using DLL_Logs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[CLSCompliant(true)]
/// <summary>
/// Classe genérica para gerenciamento de listas de objetos.
/// </summary>
/// <typeparam name="T">O tipo de objeto a ser gerenciado na lista.</typeparam>
public class ListManager<T> where T : class
{
    #region Fields
    private readonly List<T> _items;
    private readonly FileLogger _logger;
    #endregion

    #region Constructor

    public ListManager()
    {
        _items = new List<T>();
        _logger = new FileLogger();
    }
    #endregion
    #region Methods

    /// <summary>
    /// Adiciona um item à lista.
    /// </summary>
    /// <param name="item">O item a ser adicionado.</param>
    public void AdicionaLista(T item)
    {
        try
        {
            if (item == null)
            {
                throw new Exception($"Objeto nao pode ser null.");
            }
            if (_items.Contains(item))
            {
                throw new Exception($"O objeto, {item} ,adicionado já está presente na lista");
            }
            _items.Add(item);
            _logger.EscreveFicheiroLog($"o objeto, {item} ,foi adicionado á lista com sucesso");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            _logger.EscreveFicheiroLog($"Erro: {ex.Message}");

        }
    }

    /// <summary>
    /// Edita um item na lista.
    /// </summary>
    /// <param name="predicate">A condição para encontrar o item a ser editado.</param>
    /// <param name="newValues">A ação que define os novos valores para o item.</param>
    public void EditarLista(Func<T, bool> predicate, Action<T> newValues)
    {
        try
        {
            var item = _items.FirstOrDefault(predicate);
            newValues(item);
            _logger.EscreveFicheiroLog($"O objeto foi editado com sucesso");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro:a {ex.Message}");
            _logger.EscreveFicheiroLog($"Erro: {ex.Message}");
        }

    }

    /// <summary>
    /// Remove um item da lista.
    /// </summary>
    /// <param name="item">O item a ser removido.</param>
    public void Remove(T item)
    {
        try
        {
            if (item == null)
            {
                throw new Exception("O objeto não foi encontrado na lista, verifique o nome inserido");
            }
        _items.Remove(item);
        _logger.EscreveFicheiroLog($"O objeto foi removido com sucesso");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    /// <summary>
    /// Exibe as informações de todos os itens na lista.
    /// </summary>
    public void MostrarInformacoes()
    {
        foreach (T item in _items)
        {

            Console.WriteLine(item.ToString());
        }
    }

    /// <summary>
    /// Remove todos os itens da lista.
    /// </summary>
    public void Clear()
    {
        _items.Clear();
    }

    /// <summary>
    /// Adiciona os itens da lista a um ficheiro.
    /// </summary>
    /// <param name="filePath">O caminho do ficheiro onde os itens serão adicionados.</param>
    public void AdicionaListaFicheiro(string filePath)
    {
        try
        {
            var existingLines = File.ReadAllLines(filePath);

            var novosItens = new List<string>();

            foreach (var item in _items)
            {
                if (item != null)
                {
                    string itemString = item.ToString();

                    if (!existingLines.Contains(itemString))
                    {
                        novosItens.Add(itemString);
                    }
                    else
                    {
                        _logger.EscreveFicheiroLog($"O objeto '{itemString}' já está presente no ficheiro"); //Tirou-se o throw exception para nao dar break ao metodo, na primeira iteração da lista, pois a primeira e a segunda iteração vao dar erro pois ja existem no ficheiro
                    }
                }
            }
            File.AppendAllLines(filePath, novosItens);
            _logger.EscreveFicheiroLog($"Foram adicionados {novosItens.Count} itens ao ficheiro.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            _logger.EscreveFicheiroLog($"Erro: {ex.Message}");
        }
    }

    /// <summary>
    /// Adiciona itens de um arquivo à lista.
    /// </summary>
    /// <param name="filePath">O caminho do arquivo de onde os itens serão lidos.</param>
    /// <param name="converter">Uma função para converter as linhas do arquivo em objetos do tipo T.</param>
    public void AdicionarDadosDeFicheiroNaLista(string filePath, Func<string, T> converter)
    {
        try
        {
            var linhas = File.ReadAllLines(filePath);

            var itens = linhas.Select(converter).ToList();

            foreach (var item in itens)
            {
                if (!_items.Contains(item))
                {
                    _items.Add(item);
                }
                else
                {
                    _logger.EscreveFicheiroLog($"O objeto, {item}, adicionado já está presente na lista");  //Tirou-se o throw exception para nao dar break ao metodo, na primeira iteração da lista, pois a primeira e a segunda iteração vao dar erro pois ja existem no ficheiro
                }
            }

            _logger.EscreveFicheiroLog($"Foram adicionados {itens.Count} itens á lista.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro:  {ex.Message}");
            _logger.EscreveFicheiroLog($"Erro: {ex.Message}");
        }
    }
    #endregion
}