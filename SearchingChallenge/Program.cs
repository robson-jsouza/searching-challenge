// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using SearchingChallenge;
using SearchingChallenge.Interfaces;

int linhas = 4;
int colunas = 5;
int[,] matriz = new int[4, 5];

// 0   1   1   1   1
// 0   1   1   0   1
// 0   0   0   1   1
// 1   1   1   1   0

matriz[0, 0] = 0;
matriz[0, 1] = 1;
matriz[0, 2] = 1;
matriz[0, 3] = 1;
matriz[0, 4] = 1;

matriz[1, 0] = 0;
matriz[1, 1] = 1;
matriz[1, 2] = 1;
matriz[1, 3] = 0;
matriz[1, 4] = 1;

matriz[2, 0] = 0;
matriz[2, 1] = 0;
matriz[2, 2] = 0;
matriz[2, 3] = 1;
matriz[2, 4] = 1;

matriz[3, 0] = 1;
matriz[3, 1] = 1;
matriz[3, 2] = 1;
matriz[3, 3] = 1;
matriz[3, 4] = 0;

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);
var serviceProvider = serviceCollection.BuildServiceProvider();

var eventService = serviceProvider.GetService<IBuraco>();

Console.WriteLine("Iniciando a aplicação");

var quantidadeBuracos = eventService?.ObterQuantidadeBuracos(matriz, linhas, colunas);

Console.WriteLine($"Buracos: {quantidadeBuracos}");

static void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IBuraco, Buraco>();
}

// TODO: estudar life cycles da injeção de dependência (scoped, transient...)
