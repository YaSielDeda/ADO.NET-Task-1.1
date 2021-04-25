using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Написать класс Round, задающий круг с указанными координатами центра, радиусом, а также свойствами, 
//позволяющими узнать длину описанной окружности и площадь круга. Обеспечить нахождение объекта в заведомо корректном состоянии. 
//Написать программу, демонстрирующую использование данного круга.

namespace Round
{   
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteRoundToFile();
            string path = "round.json";
            Console.WriteLine(CreateRound(path));

            Console.ReadLine();
        }
        public static Round CreateRound(string path)
        {
            Round round = null;
            RoundWorker fileWorker = new RoundWorker();
            try
            {
                round = fileWorker.GetRound(path);
            }
            catch(Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            return round;
        }
        public static void WriteRoundToFile()
        {
            Round round = new Round();
            RoundWorker fileWorker = new RoundWorker();
            try
            {
                Console.Write("Enter X: ");
                round.Center.X = double.Parse(Console.ReadLine());
                Console.Write("Enter Y: ");
                round.Center.Y = double.Parse(Console.ReadLine());
                Console.Write("Enter Radius: ");
                round.Radius = double.Parse(Console.ReadLine());
                fileWorker.ToFile(round);

                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("The file has successfully written!");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
        public static void Serialization()
        {
            Round round = new Round(
                    new Point(
                        2.1,
                        1.2
                        ),
                    3.7
                    );
            JsonSerializer json = new JsonSerializer();
            using (StreamWriter fs = new StreamWriter("round.json"))
            {
                using (JsonWriter jw = new JsonTextWriter(fs))
                {
                    json.Serialize(jw, round);
                }
            }
        }
    }
}