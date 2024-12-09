namespace TestCarte
{
    using Xunit;
    using carte.Models;
    using carte.Service;
    using System.Collections.Generic;
    using carte.Services;

    public class SimulationServiceTests
    {
        [Fact]
        public void TestSimulerDeplacementAvance()
        {
            Carte carte = new Carte
            {
                Largeur = 3,
                Hauteur = 4,
                Aventuriers = new List<Aventurier>
                {
                    new Aventurier
                    {
                        Nom = "Lara",
                        X = 1,
                        Y = 1,
                        Orientation = "N",
                        Mouvements = "A"
                    }
                }
            };

            var simulation = new SimulationService(carte);
            simulation.Simuler();

            var aventurier = carte.Aventuriers[0];
            Assert.Equal(0, aventurier.Y);
            Assert.Equal(1, aventurier.X);
        }

        [Fact]
        public void TestSimulerCarteAvecFichier()
        {
            var fichierEntree = "carte.txt";
            var fichierSortie = "resultat.txt";

            var fichierService = new FichierService();
            var carte = fichierService.LireFichier(fichierEntree);
            var simulationService = new SimulationService(carte);
            simulationService.Simuler();

            fichierService.EcrireFichier(fichierSortie, carte);


            var resultatAttendu = new string[]
            {
                "C - 3 - 4",
                "M - 1 - 1",
                "M - 2 - 2",
                "T - 0 - 3 - 0",
                "T - 1 - 3 - 0",
                "A - Lara - 0 - 3 - S - 3"
            };

            var lignesSortie = File.ReadAllLines(fichierSortie);

            Assert.Equal(resultatAttendu, lignesSortie);
        }
    }
}
