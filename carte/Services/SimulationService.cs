namespace carte.Service
{
    using carte.Models;
    using System;
    using System.Linq;

    public class SimulationService
    {
        private Carte _carte;

        public SimulationService(Carte carte)
        {
            _carte = carte;
        }

        public void Simuler()
        {
            foreach (var aventurier in _carte.Aventuriers)
            {
                foreach (var mouvement in aventurier.Mouvements)
                {
                    switch (mouvement)
                    {
                        case 'A':
                            Avancer(aventurier);
                            break;
                        case 'G':
                            TournerGauche(aventurier);
                            break;
                        case 'D':
                            TournerDroite(aventurier);
                            break;
                    }
                }
            }
        }

        private void Avancer(Aventurier aventurier)
        {
            int x = aventurier.X;
            int y = aventurier.Y;

            switch (aventurier.Orientation)
            {
                case "N": y--; break;
                case "S": y++; break;
                case "E": x++; break;
                case "O": x--; break;
            }

            if (x >= 0 && x < _carte.Largeur && y >= 0 && y < _carte.Hauteur &&
                !_carte.Montagnes.Any(m => m.X == x && m.Y == y))
            {
                aventurier.X = x;
                aventurier.Y = y;

                var tresor = _carte.Tresors.FirstOrDefault(t => t.X == x && t.Y == y && t.NombreTresors > 0);
                if (tresor != null)
                {
                    aventurier.TresorsRamasses++;
                    tresor.NombreTresors--;
                }
            }
        }

        private void TournerGauche(Aventurier aventurier)
        {
            aventurier.Orientation = aventurier.Orientation switch
            {
                "N" => "O",
                "O" => "S",
                "S" => "E",
                "E" => "N",
                _ => aventurier.Orientation
            };
        }

        private void TournerDroite(Aventurier aventurier)
        {
            aventurier.Orientation = aventurier.Orientation switch
            {
                "N" => "E",
                "E" => "S",
                "S" => "O",
                "O" => "N",
                _ => aventurier.Orientation
            };
        }
    }

}
