//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//// Swagger est maintenant désactivé, on retire ou commente les lignes suivantes :
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//// On désactive également Swagger ici.
//if (app.Environment.IsDevelopment())
//{
//    // app.UseSwagger();
//    // app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();

//app.Run();
using carte.Service;
using carte.Services;
using System;

class Program
{
    static void Main(string[] args)
    {
        var fichierService = new FichierService();
        var carte = fichierService.LireFichier("carte.txt");

        var simulationService = new SimulationService(carte);
        simulationService.Simuler();

        fichierService.EcrireFichier("resultat.txt", carte);
        Console.WriteLine("Simulation terminée. Résultat dans 'resultat.txt'.");
    }
}