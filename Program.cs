using System;
using System.Collections.Generic;

class Program
{
    // Variáveis globais
    static string welcomeMessage = "Boas vindas ao Screen Sound!";
    static Dictionary<string, List<int>> bandsList = new Dictionary<string, List<int>> {
        { "U2", new List<int>() },
        { "The Beatles", new List<int>() },
        { "Calypso", new List<int>() }
        };

    static void ShowLogo()
    {
        Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
        Console.WriteLine(welcomeMessage);
        Thread.Sleep(2000);
        Console.Clear();
    }

    static void ListBands(bool showGrade)
    {
        ShowTitle("Listando Todas as Bandas Registradas:");

        if (bandsList.Count == 0)
        {
            Console.WriteLine("Nenhuma banda cadastrada");
            return;
        }

        foreach (string band in bandsList.Keys)
        {
            double gradeNote = 0;
            if (bandsList[band].Count > 0)
            {
                gradeNote = bandsList[band].Average();
            }
            Console.WriteLine($"Banda: {band} - Nota: {gradeNote}");
        }

        if (showGrade) return;
        Console.Write("\nPressione qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }

    static void ShowTitle(string title)
    {
        Console.Clear();
        int titleLength = title.Length;
        string titleSeparator = new string('*', titleLength);
        Console.WriteLine(titleSeparator);
        Console.WriteLine(title);
        Console.WriteLine(titleSeparator + "\n");
    }

    static void AddBand()
    {
        ShowTitle("Registro de Banda");
        Console.Write("Digite o nome da banda ou 'sair' para voltar: ");
        string bandName = Console.ReadLine() ?? string.Empty;

        if (bandName == "sair")
        {
            Console.Clear();
            return;
        }

        if (bandsList.ContainsKey(bandName))
        {
            Console.WriteLine("Banda já cadastrada!");
            Thread.Sleep(2000);
            Console.Clear();
            return;
        }

        if (string.IsNullOrEmpty(bandName))
        {
            Console.Clear();
            Console.WriteLine("Nome da banda não pode ser vazio!");
            Thread.Sleep(2000);
            AddBand();
            return;
        }

        bandsList.Add(bandName, new List<int>());
        Console.WriteLine("Banda adicionada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
    }

    static void RemoveBand()
    {
        ShowTitle("Remoção de Banda");
        ListBands(true);
        Console.Write("\nDigite o nome da banda ou 'sair' para voltar: ");
        string bandName = Console.ReadLine() ?? string.Empty;

        if (bandName == "sair")
        {
            Console.Clear();
            return;
        }

        if (!bandsList.ContainsKey(bandName))
        {
            Console.Clear();
            Console.WriteLine("\nBanda não encontrada!");
            Thread.Sleep(2000);
            RemoveBand();
            return;
        }

        bandsList.Remove(bandName);
        Console.WriteLine("\nBanda removida com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
    }

    static void BandNote()
    {
        ShowTitle("Avaliação de Banda");
        ListBands(true);
        Console.Write("\nDigite o nome da banda ou 'sair' para voltar: ");
        string bandName = Console.ReadLine() ?? string.Empty;

        if (bandName == "sair")
        {
            Console.Clear();
            return;
        }

        if (!bandsList.ContainsKey(bandName))
        {
            Console.Clear();
            Console.WriteLine("\nBanda não encontrada!");
            Thread.Sleep(2000);
            BandNote();
            return;
        }

        Console.Write("Digite a nota da banda: ");
        int note = int.Parse(Console.ReadLine() ?? string.Empty);

        if (note < 0 || note > 10)
        {
            Console.Clear();
            Console.WriteLine("\nNota inválida nota deve ser de 0 a 10!");
            Thread.Sleep(2000);
            BandNote();
            return;
        }

        bandsList[bandName].Add(note);
        Console.WriteLine("\nNota adicionada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();

    }

    static void ShowMenuOptions()
    {
        ShowTitle("Menu de opções");
        Console.WriteLine("1 - Listar bandas");
        Console.WriteLine("2 - Adicionar banda");
        Console.WriteLine("3 - Remover banda");
        Console.WriteLine("4 - Dar nota para banda");
        Console.WriteLine("5 - Sair\n");

        Console.Write("Digite a opção desejada: ");
        string option = Console.ReadLine() ?? string.Empty;


        switch (option)
        {
            case "1":
                ListBands(false);
                break;
            case "2":
                AddBand();
                break;
            case "3":
                RemoveBand();
                break;
            case "4":
                BandNote();
                break;
            case "5":
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                ShowTitle("Opção inválida!");
                Thread.Sleep(2000);
                break;
        }
    }

    static void Main()
    {

        ShowLogo();
        while (true)
        {
            ShowMenuOptions();
        }
    }
}
