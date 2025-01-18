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
        Console.Clear();
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
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }

    static void ShowTitle(string title)
    {
        int titleLength = title.Length;
        string titleSeparator = new string('*', titleLength);
        Console.WriteLine(titleSeparator);
        Console.WriteLine(title);
        Console.WriteLine(titleSeparator);
    }

    static void AddBand()
    {
        Console.Clear();
        ShowTitle("Registro de Banda");
        Console.WriteLine("Digite o nome da banda:");
        string bandName = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrEmpty(bandName))
        {
            Console.WriteLine("Nome da banda não pode ser vazio");
            return;
        }

        bandsList.Add(bandName, new List<int>());
        Console.WriteLine("Banda adicionada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
    }

    static void BandNote()
    {
        ShowTitle("Avaliação de Banda");
        ListBands(true);
        Console.WriteLine("\nDigite o nome da banda que deseja avaliar:");
        string bandName = Console.ReadLine() ?? string.Empty;

        if (!bandsList.ContainsKey(bandName))
        {
            Console.WriteLine("Banda não encontrada");
            return;
        }

        Console.WriteLine("Digite a nota da banda:");
        int note = int.Parse(Console.ReadLine() ?? string.Empty);

        if (note < 0 || note > 10)
        {
            Console.WriteLine("\nNota inválida nota deve ser de 0 a 10");
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
        Console.WriteLine("3 - Dar nota para banda");
        Console.WriteLine("4 - Sair");

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
                BandNote();
                break;
            case "4":
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida!");
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
