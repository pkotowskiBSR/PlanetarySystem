using System.Numerics;

namespace PlanetarySystem
{
    public partial class Form1 : Form
    {
        //model:
        List<Planet> planets = new List<Planet>();
        List<Rocket> rockets = new List<Rocket>();

        public Form1()
        {
            InitializeComponent();

            planets.Add(new Planet(Color.Yellow, 100, 50, 0, 0, 0, null));
            planets.Add(new Planet(Color.Red, 100, 20, 200, 2, 0, null));
            planets.Add(new Planet(Color.Green, 30, 5, 50, 10, 0, planets[1]));

            foreach (Planet planet in planets)
            {
                planet.UpdatePosition();
            }

            //Tworzymy rakiety
            Rocket rocket = new Rocket();
            rocket.Color = Color.Black;
            rocket.XPosition = planets[0].XPosition;
            rocket.YPosition = planets[0].YPosition+planets[0].PlanetRadius;
            rockets.Add(rocket);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.ScaleTransform(1, -1);
            g.TranslateTransform(pictureBox1.Width / 2, -pictureBox1.Height / 2);

            foreach (Planet planet in planets)
            {
                planet.Draw(g, (int)planets[0].XPosition, (int)planets[0].YPosition);
            }

            foreach (Rocket rocket in rockets)
            {
                rocket.Draw(g, (int)planets[0].XPosition, (int)planets[0].YPosition);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Planet planet in planets)
            {
                planet.UpdatePosition();
            }

            foreach (Rocket rocket in rockets)
            {
                rocket.Update(planets);
            }
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
