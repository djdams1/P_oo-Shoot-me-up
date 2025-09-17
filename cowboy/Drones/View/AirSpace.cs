namespace Drones
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class AirSpace : Form
    {
        public static readonly int WIDTH = 1920;        // Dimensions of the airspace
        public static readonly int HEIGHT = 1080;
        private Image backgroundImage = Image.FromFile(@"D:\Poo\P_oo-Shoot-me-up\cowboy\Drones\Resources\background1.png");
        private Joueur joueur;





        // La flotte est l'ensemble des drones qui évoluent dans notre espace aérien
        private List<Drone> fleet;

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;





        // Initialisation de l'espace aérien avec un certain nombre de drones
        public AirSpace(List<Drone> fleet)
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += AirSpace_KeyDown;

            currentContext = BufferedGraphicsManager.Current;
            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this.fleet = fleet;
            joueur = new Joueur();
        }
        private void AirSpace_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:

                    joueur.gauche();
                    break;

                case Keys.D:

                    joueur.droit();
                    break;
            }
        }


        // Affichage de la situation actuelle
        private void Render()
        {
            airspace.Graphics.DrawImage(backgroundImage, new Rectangle(0, 0, Width, Height));
            joueur.Render(airspace);
            // draw drones
            foreach (Drone drone in fleet)
            {
                drone.Render(airspace);

            }

            airspace.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            joueur.addvie();
            foreach (Drone drone in fleet)
            {
                drone.Update(interval);


            }

        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }

        private void AirSpace_Load(object sender, EventArgs e)
        {

        }
    }
}