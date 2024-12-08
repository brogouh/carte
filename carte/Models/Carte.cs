namespace carte.Models
{
    public class Carte
    {
        public int Largeur { get; set; }
        public int Hauteur { get; set; }
        public List<Montagne> Montagnes { get; set; } = new List<Montagne>();
        public List<CaseTresor> Tresors { get; set; } = new List<CaseTresor>();
        public List<Aventurier> Aventuriers { get; set; } = new List<Aventurier>();
    }

}
