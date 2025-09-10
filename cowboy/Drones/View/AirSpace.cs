namespace Drones
{
    // La classe AirSpace repr�sente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fen�tre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class AirSpace : Form
    {
        public static readonly int WIDTH = 1920;        // Dimensions of the airspace
        public static readonly int HEIGHT = 1080;
        private Image backgroundImage = Image.FromFile(@"D:\Poo\P_oo-Shoot-me-up\cowboy\Drones\Resources\background1.png");
        private Joueur joueur;




        // La flotte est l'ensemble des drones qui �voluent dans notre espace a�rien
        private List<Drone> fleet;

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;

        // Initialisation de l'espace a�rien avec un certain nombre de drones
        public AirSpace(List<Drone> fleet)


        {
            InitializeComponent();
            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this.fleet = fleet;

            joueur = new Joueur();
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            airspace.Graphics.DrawImage(backgroundImage, new Rectangle(0, 0, Width, Height));

            // draw drones
            foreach (Drone drone in fleet)
            {
                drone.Render(airspace);
                joueur.Render(airspace);
            }

            airspace.Render();
        }

        // Calcul du nouvel �tat apr�s que 'interval' millisecondes se sont �coul�es
        private void Update(int interval)
        {
            foreach (Drone drone in fleet)
            {
                drone.Update(interval);
                Joueur.Update();
            }
        }

        // M�thode appel�e � chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }
    }
}