namespace carte.Services
{
    using carte.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FichierService
    {
        public Carte LireFichier(string chemin)
        {
            var carte = new Carte();
            var lignes = File.ReadAllLines(chemin);

            foreach (var ligne in lignes)
            {
                if (ligne.StartsWith("#")) continue;

                var parts = ligne.Split(" - ");
                switch (parts[0])
                {
                    case "C":
                        carte.Largeur = int.Parse(parts[1]);
                        carte.Hauteur = int.Parse(parts[2]);
                        break;

                    case "M":
                        carte.Montagnes.Add(new Montagne
                        {
                            X = int.Parse(parts[1]),
                            Y = int.Parse(parts[2])
                        });
                        break;

                    case "T":
                        carte.Tresors.Add(new CaseTresor
                        {
                            X = int.Parse(parts[1]),
                            Y = int.Parse(parts[2]),
                            NombreTresors = int.Parse(parts[3])
                        });
                        break;

                    case "A":
                        carte.Aventuriers.Add(new Aventurier
                        {
                            Nom = parts[1],
                            X = int.Parse(parts[2]),
                            Y = int.Parse(parts[3]),
                            Orientation = parts[4],
                            Mouvements = parts[5]
                        });
                        break;
                }
            }

            return carte;
        }

        public void EcrireFichier(string chemin, Carte carte)
        {
            var lignes = new List<string>
        {
            $"C - {carte.Largeur} - {carte.Hauteur}"
        };

            foreach (var montagne in carte.Montagnes)
            {
                lignes.Add($"M - {montagne.X} - {montagne.Y}");
            }

            foreach (var tresor in carte.Tresors)
            {
                lignes.Add($"T - {tresor.X} - {tresor.Y} - {tresor.NombreTresors}");
            }

            foreach (var aventurier in carte.Aventuriers)
            {
                lignes.Add($"A - {aventurier.Nom} - {aventurier.X} - {aventurier.Y} - {aventurier.Orientation} - {aventurier.TresorsRamasses}");
            }

            File.WriteAllLines(chemin, lignes);
        }
    }

}
