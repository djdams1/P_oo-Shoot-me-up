namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Joueur
    {
        public static readonly int FULLCHARGE = 1000;   // Charge maximale de la batterie
        private int _vie = 50;                            // La charge actuelle de la batterie                        // Un nom
        private int _x = AirSpace.WIDTH /2;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y = AirSpace.HEIGHT-200;
        private int _direction = 100;

        // Constructeur
        public Joueur()
        {
            _x = AirSpace.WIDTH / 2;
        }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Direction { get => _direction; set => _direction = value; }

        // Cette méthode calcule le nouvel sétat dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void gauche()
        {
            _x-=15;
            
            if (_direction == 100) 
            {
                _x += 100;
                _direction = -100;
            }
                
        }
        public void droit()
        {
            _x+=15;
            if (_direction == -100)
            {
                _x -= 100;
                _direction = 100;
            }
        }

    }
}
