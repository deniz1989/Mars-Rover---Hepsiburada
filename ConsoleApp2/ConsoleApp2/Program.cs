using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Boşluk bırakarak sınır kordinatlarını giriniz. Örnek input: 5 5 ");
            string upperRightCoordinates = Console.ReadLine();

            Plateau plateau = new Plateau
            {
                UpperRightCoordinates = new Coordinate
                {
                    X = int.Parse(upperRightCoordinates[0].ToString()),
                    Y = int.Parse(upperRightCoordinates[0].ToString())
                },
                Rovers = new List<Rover>()
            };

            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine("Boşluk bırakarak rover'ın kordinatlarını ve hangi yöne baktığını giriniz. Örnek input: 1 2 N");
                string roverInfo = Console.ReadLine();

                Console.WriteLine("Hareket komutlarını giriniz. Örnek input: LMLMLMLMM");
                string movementCommands = Console.ReadLine();

                Rover rover = new Rover
                {
                    Facing = roverInfo[4].ToString(),
                    RoverCoordinate = new Coordinate
                    {
                        X = int.Parse(roverInfo[0].ToString()),
                        Y = int.Parse(roverInfo[2].ToString()),
                    },
                    MovementCommands = movementCommands
                };

                plateau.Rovers.Add(rover);

                Console.WriteLine("Başka bir rover için giriş yapmak istiyormusunuz? E/H");
                if (Console.ReadLine() == "H")
                {
                    FindFinalCoordinates(plateau);
                    keepGoing = false;
                }
            }
        }

        private static void FindFinalCoordinates(Plateau plateau)
        {
            foreach (var rover in plateau.Rovers)
            {
                foreach (var command in rover.MovementCommands)
                {
                    if (command == 'L')
                    {
                        switch (rover.Facing)
                        {
                            case "N":
                                rover.Facing = "W";
                                break;
                            case "W":
                                rover.Facing = "S";
                                break;
                            case "S":
                                rover.Facing = "E";
                                break;
                            case "E":
                                rover.Facing = "N";
                                break;
                        }
                    }
                    else if (command == 'R')
                    {
                        switch (rover.Facing)
                        {
                            case "N":
                                rover.Facing = "E";
                                break;
                            case "E":
                                rover.Facing = "S";
                                break;
                            case "S":
                                rover.Facing = "W";
                                break;
                            case "W":
                                rover.Facing = "N";
                                break;
                        }
                    }
                    else if (command == 'M')
                    {
                        switch (rover.Facing)
                        {
                            case "N":
                                if (rover.RoverCoordinate.Y < plateau.UpperRightCoordinates.Y)
                                {
                                    rover.RoverCoordinate.Y++;
                                }
                                else
                                {
                                    //Rover alan dışına çıkmaya çalıştığı için olduğu yerde kalıyor.
                                }
                                break;
                            case "W":
                                if (rover.RoverCoordinate.X > 0)
                                {
                                    rover.RoverCoordinate.X--;
                                }
                                else
                                {
                                    //Rover alan dışına çıkmaya çalıştığı için olduğu yerde kalıyor.
                                }
                                break;
                            case "S":

                                if (rover.RoverCoordinate.Y > 0)
                                {
                                    rover.RoverCoordinate.Y--;
                                }
                                else
                                {
                                    //Rover alan dışına çıkmaya çalıştığı için olduğu yerde kalıyor.
                                }
                                break;
                            case "E":
                                if (rover.RoverCoordinate.X < plateau.UpperRightCoordinates.X)
                                {
                                    rover.RoverCoordinate.X++;
                                }
                                else
                                {
                                    //Rover alan dışına çıkmaya çalıştığı için olduğu yerde kalıyor.
                                }
                                break;
                        }
                    }
                }
                Console.WriteLine(string.Format("{0} {1} {2}", rover.RoverCoordinate.X, rover.RoverCoordinate.Y, rover.Facing));
            }
        }
    }

    public class Plateau
    {
        public Coordinate UpperRightCoordinates { get; set; }
        public List<Rover> Rovers { get; set; }
    }

    public class Rover
    {
        public string Facing { get; set; }
        public Coordinate RoverCoordinate { get; set; }
        public string MovementCommands { get; set; }
    }

    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
