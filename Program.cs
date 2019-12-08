using System;
using VierticaXmasGame.Task1;
using VierticaXmasGame.Task2;
using VierticaXmasGame.Task3;

namespace VierticaXmasGame
{
    public class Program
    {
        static void Main(string[] args)
        {

            GetCreds creds = new GetCreds(); //Task1
                        
            Models.SantaLoc.Source santaLoc = ElastiscRepo.Connect(creds.creds);

            PosisionCalculator posisionCalculator = new PosisionCalculator();

            posisionCalculator.CalculateFinalPosition(santaLoc);

            Console.WriteLine($"{posisionCalculator.lat}, {posisionCalculator.lon}");

            SendRescue sendRescue = new SendRescue();

            sendRescue.MakeHttpCall(creds.creds, posisionCalculator); //Task2

            FindRaindeer findRaindeer = new FindRaindeer(sendRescue.rescueResponse);

            findRaindeer.calculateRaindeer();

            Console.ReadLine();
        }
    }
}
