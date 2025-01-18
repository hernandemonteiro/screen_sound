// Screen Sound
string welcomeMessage = "Boas vindas ao Screen Sound!";
List<string> bandsList = new List<string> { "U2", "The Beatles", "Calypso" };

void ShowLogo()
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
}

void ListBands()
{
    Console.WriteLine("Listando bandas:");

    if (bandsList.Count == 0)
    {
        Console.WriteLine("Nenhuma banda cadastrada");
        return;
    }

    foreach (string band in bandsList)
    {
        Console.WriteLine($"Banda: {band}");
    }
}

void AddBand()
{
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
}

void showMenuOptions()
{
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Listar bandas");
    Console.WriteLine("2 - Adicionar banda");
    Console.WriteLine("3 - Limpar tela");
    Console.WriteLine("4 - Sair");

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
            Console.Clear();
            break;
        case "4":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}

ShowLogo();
while (true)
{
    showMenuOptions();
}

