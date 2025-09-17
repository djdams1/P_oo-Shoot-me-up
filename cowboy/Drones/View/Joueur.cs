using Drones.Helpers;
using Drones.Properties;
using System.Resources;

namespace Drones
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Joueur
    {
        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);
        private Image joueur = Image.FromFile(@"D:\Poo\P_oo-Shoot-me-up\cowboy\Drones\Resources\cowboy.png");

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(joueur, new Rectangle(X, AirSpace.HEIGHT, 100,100));
        }

    }
}
