using System;
using System.Collections.Generic;
using ScreenSound.Teste;

class Program
{
    // Variáveis globais
    static string welcomeMessage = "Boas vindas ao Screen Sound!";
    static List<string> bandsList = new List<string> { "U2", "The Beatles", "Calypso" };

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

    static void ListBands()
    {
        Console.Clear();
        ShowTitle("Listando Todas as Bandas Registradas:");

        if (bandsList.Count == 0)
        {
            Console.WriteLine("Nenhuma banda cadastrada");
            return;
        }

        foreach (string band in bandsList)
        {
            Console.WriteLine($"Banda: {band}");
        }

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

        bandsList.Add(bandName);
        bandsList.Sort();
        Console.WriteLine("Banda adicionada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
    }

    static void ShowMenuOptions()
    {
        ShowTitle("Menu de opções");
        Console.WriteLine("1 - Listar bandas");
        Console.WriteLine("2 - Adicionar banda");
        Console.WriteLine("3 - Sair");

        string option = Console.ReadLine() ?? string.Empty;

        switch (option)
        {
            case "1":
                ListBands();
                break;
            case "2":
                AddBand();
                break;
            case "3":
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
