using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetarySystem
{
    internal class Rocket
    {
        public Color Color;
        public float Mass;

        public float XPosition;
        public float YPosition;
        public float Vx;
        public float Vy;

        public Rocket()
        {
            Mass = 1;
        }

        float Distance2ToPlanet(Planet planet)
        {
            return (XPosition-planet.XPosition)* (XPosition - planet.XPosition) + (YPosition-planet.YPosition)* (YPosition - planet.YPosition);
        }

        float DistanceToPlanet(Planet planet)
        { 
            return MathF.Sqrt(Distance2ToPlanet(planet));
        }

        float DistanceXToPlanet(Planet planet)
        {
            return planet.XPosition-XPosition;
        }

        float DistanceYToPlanet(Planet planet)
        {
            return planet.YPosition - YPosition;
        }

        public void Init()
        {

        }

        public void Draw(Graphics g, int xCenter, int yCenter)
        {
            Brush brush = new SolidBrush(Color);
            g.FillRectangle(brush, XPosition - 5 - xCenter, YPosition - 5 - yCenter, 10, 10);

        }

        public void Update(List<Planet> planets)
        {
            float Fx = 0;
            float Fy = 0;

            float G = 10f;

            foreach( Planet planet in planets)
            {
                float F = G*Mass * planet.Mass / Distance2ToPlanet(planet);

                Fx += F * DistanceXToPlanet(planet) / DistanceToPlanet(planet);
                Fy += F * DistanceYToPlanet(planet) / DistanceToPlanet(planet);
            }


            float Ax = Fx / Mass;
            float Ay = Fx / Mass;

            Vx += Ax;
            Vy += Ax;

            XPosition += Vx;
            YPosition += Vy;

        }
    }
}
