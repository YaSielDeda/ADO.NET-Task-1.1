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
        public class Point
        {
            public double x { get; set; }
            public double y { get; set; }

        }
        static string path = @"input.txt";
        static ArgumentException LessThanZero = new ArgumentException("The radius can only be positive");
        public class File
        {
            private Point Center;
            private double r;
            private double Radius
            {
                get { return r; }
                set
                {
                    if (value < 0)
                        throw LessThanZero;
                    else
                        r = value;
                }
            }
            public Point GetCenter() { return Center; }
            public double GetRadius() { return Radius; }

            public void Load()
            {
                string str = null;

                #region file loading
                try
                {
                    FileStream stream = new FileStream(path, FileMode.Open);
                    StreamReader reader = new StreamReader(stream);
                    str = reader.ReadToEnd();
                    stream.Close();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("File has been loaded successfully!");
                    Console.ResetColor();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The file is missing!");
                    Console.ResetColor();
                }
                #endregion

                #region parsing
                try
                {
                    Regex reg = new Regex(@"(?<=\=)(.*?)(?=\,)");
                    MatchCollection matches = reg.Matches(str);
                    if (matches.Count > 0)
                    {
                        Center = new Point { x = int.Parse(matches[0].Value), y = int.Parse(matches[1].Value) };
                        Radius = int.Parse(matches[2].Value);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("File data is valid!");
                    Console.ResetColor();
                }
                catch (ArgumentException LessThanZero)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(LessThanZero.Message);
                    Console.ResetColor();
                }
                catch (System.FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Data contains invalid symbols!");
                    Console.ResetColor();
                }
                #endregion
            }
            public void PrintFile()
            {
                using (StreamWriter sw = new StreamWriter("output.txt", false, System.Text.Encoding.Default))
                {
                    StringBuilder str = new StringBuilder("x=" + Center.x + ",y=" + Center.y + ",r=" + Radius + ",");
                    sw.Write(str);
                    Console.WriteLine("File is created!");
                }
            }
        }
        public class Round
        {
            private Point Center;
            private double length;
            private double square;
            private double r;
            private double Radius
            {
                get
                {
                    return r;
                }
                set
                {
                    if (value < 0)
                        throw LessThanZero;
                    else
                        r = value;
                }
            }
            public Round()
            {
                Center = new Point { x = 0, y = 0 };
                Radius = 0;
            }
            public Round(Point Center, double Radius)
            {
                this.Center = Center;
                this.Radius = Radius;
            }
            public Round(File newFile)
            {
                Center = newFile.GetCenter();
                Radius = newFile.GetRadius();
            }
            public void SetParams(double x = int.MaxValue, double y = int.MaxValue, double r = int.MaxValue)
            {
                if (x != int.MaxValue)
                {
                    Center.x = x;
                }
                if (y != int.MaxValue)
                {
                    Center.y = y;
                }
                if (r != int.MaxValue)
                {
                    Radius = r;
                }
            }
            public void PrintInfo()
            {
                Console.WriteLine("Round with center in points x: {0}, y: {1} and radius: {2}", Center.x, Center.y, Radius);
            }
            public void LengthOfTheCircumscribedCircle()
            {
                    length = 2 * Math.PI * Radius;
                    Console.WriteLine("Length: {0}", length);
            }
            public void Square()
            {
                square = Math.PI * Math.Pow(Radius, 2);
                Console.WriteLine("Square; {0}", square);
            }
        }
        static void Main(string[] args)
        {
            #region Empty round
            Round roundEmpty = new Round();
            roundEmpty.PrintInfo();
            Console.WriteLine();
            #endregion

            #region Round with parameters
            Round roundWithParams = new Round(new Point {x = 2, y = 5 }, 9);
            roundWithParams.PrintInfo();
            Console.WriteLine();
            roundWithParams.SetParams(4, int.MaxValue, 10);
            roundWithParams.PrintInfo();
            Console.WriteLine();
            #endregion

            #region Round from file
            File file = new File();
            file.Load();
            Round roundFromFile = new Round(file);
            //roundFromFile.SetParams(2, 2, 5);
            roundFromFile.PrintInfo();
            #endregion

            Console.ReadLine();
        }
    }
}