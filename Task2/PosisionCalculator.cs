using System;
using System.Linq;
using VierticaXmasGame.Models.SantaLoc;

namespace VierticaXmasGame.Task2
{
    public class PosisionCalculator
    {
        public double lat;
        public double lon;
        readonly double m = 1d / (2d * Math.PI / 360d * 6378.137d) / 1000d; // 1 meter in degrees

        public void CalculateFinalPosition(Source data)
        {
            lat = data.canePosition.lat;
            lon = data.canePosition.lon;

            /** Didn't work, was always whrong on the longetute.
            foreach (SantaMovement movement in data.santaMovements)
            {
                UpdatePosition(movement);
            }
            **/

            foreach (SantaMovement movement in data.santaMovements.Where(x => x.direction == "right" || x.direction == "left"))
            {
                UpdatePosition(movement);
            }
            foreach (SantaMovement movement in data.santaMovements.Where(x => x.direction == "down" || x.direction == "up"))
            {
                UpdatePosition(movement);
            }
        }

        private void UpdatePosition(SantaMovement movement)
        {
            double meters = GetMeters(movement);

            switch (movement.direction)
            {
                case "right":
                    NewLon(meters);
                    break;
                case "left":
                    NewLon(-meters);
                    break;
                case "up":
                    NewLat(meters);
                    break;
                case "down":
                    NewLat(-meters);
                    break;
                default:
                    break;
            }
            //Console.WriteLine($"Moved: {meters} meters {movement.direction} - New Location: {lat}, {lon}");
        }

        private double GetMeters(SantaMovement movement)
        {
            switch (movement.unit)
            {
                case "meter":
                    return movement.value;

                case "kilometer":
                    return movement.value * 1000d;

                case "foot":
                    return movement.value * 0.304800610d;

                default:
                    throw new Exception("Stuff fucked up - Santa is off the reservation :)");                    
            }
        }

        private void NewLat(double deltaLat)
        {
            lat += deltaLat * m;
        }

        private void NewLon(double deltaLon)
        {
            lon += deltaLon * m / Math.Cos(lat * (Math.PI / 180d));
        }
    }
}
