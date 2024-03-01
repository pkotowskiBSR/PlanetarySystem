using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetarySystem
{
    internal class Planet
    {
        public Color Color;
        public float Mass;
        public int PlanetRadius;
        public int OrbitRadius;
        public float AngularVelocity; //predkosc kątowa w stopniach
        public float Angle; //aktualny kąt przmieszczenia

        public Planet? ParentPlanet;

        public Planet(Color color, float mass, int planetRadius, int orbitRadius, float angularVelocity, float angle, Planet? parentPlanet)
        {
            Color = color;
            Mass = mass;
            PlanetRadius = planetRadius;
            OrbitRadius = orbitRadius;
            AngularVelocity = angularVelocity;
            Angle = angle;
            ParentPlanet = parentPlanet;
        }

        public float XPosition;
        public float YPosition;

        public void UpdatePosition()
        {
            Angle += AngularVelocity;

            if (ParentPlanet == null)
            {
                XPosition = OrbitRadius * MathF.Cos(Angle * MathF.PI / 180);
                YPosition = OrbitRadius * MathF.Sin(Angle * MathF.PI / 180);
            }
            else
            {
                XPosition = ParentPlanet.XPosition+OrbitRadius * MathF.Cos(Angle * MathF.PI / 180);
                YPosition = ParentPlanet.YPosition+OrbitRadius * MathF.Sin(Angle * MathF.PI / 180);
            }

        }

        public void Draw(Graphics g, int xCenter, int yCenter)
        {
            Brush brush = new SolidBrush(Color);
            g.FillEllipse(brush, XPosition - PlanetRadius - xCenter, YPosition - PlanetRadius - yCenter, 2 * PlanetRadius, 2 * PlanetRadius);
        }
    }
}
