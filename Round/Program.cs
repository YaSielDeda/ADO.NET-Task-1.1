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
    class Program
    {
        public static void radiusCheck(Round round)
        {
            if (round.Radius < 0)
                throw new LessThanZero("The radius can only be positive");
        }
        static void Main(string[] args)
        {
            FileWorker fileWorker = new FileWorker();
            Parser parser = new Parser();

            /*#region Empty round
            Round roundEmpty = new Round();
            Console.WriteLine(roundEmpty.ToString());
            roundEmpty.Center.X = 12.5;
            roundEmpty.Center.Y = 7.3;
            roundEmpty.Radius = 2.1;
            fileWorker.PrintFile(roundEmpty);
            Console.WriteLine();
            #endregion*/

            /*#region Round with parameters
            Round roundWithParams = new Round(new Point {x = 2, y = 5 }, 9);
            roundWithParams.PrintInfo();
            Console.WriteLine();
            #endregion*/

            #region Round from file           
            try
            {
                var line = fileWorker.Load();
                var arrayOfPoint = parser.ParseRawData(line);

                Round roundFromFile = new Round(new Point { X = arrayOfPoint[0], Y = arrayOfPoint[1] }, arrayOfPoint[2]);
                //roundFromFile.Radius = -5;
                radiusCheck(roundFromFile);
                Console.WriteLine(roundFromFile.ToString());
            }
            catch(LessThanZero e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            #endregion

            Console.ReadLine();
        }
    }
}