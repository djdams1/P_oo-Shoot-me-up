namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Joueur
    {
        public static readonly int FULLCHARGE = 1000;   // Charge maximale de la batterie
        private int _vie = 50;                            // La charge actuelle de la batterie                        // Un nom
        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y = 50;                                 // Position en Y depuis le haut de l'espace aérien

        // Constructeur
        public Joueur()
        {
            _x = AirSpace.WIDTH / 2;
        }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        // Cette méthode calcule le nouvel sétat dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public static void Update()
        {
            
        }

    }
}
