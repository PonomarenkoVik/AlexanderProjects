using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public enum Figure { Square, Diamond, Circle, Ellipse };

    class Program
    {

        const int _size = 15;
        const string symbol = "#";


        static void Main(string[] args)
        {
            int menuCount = Enum.GetNames(typeof(Figure)).Length;
            ProcessMenu(menuCount);
        }

        private static void ProcessMenu(int menuCount)
        {
            int chosen = 0;
            bool needRedrawMenu = true;
            while (true)
            {
                if (needRedrawMenu)
                {
                    Console.Clear();
                    DrawMenu(chosen);
                    needRedrawMenu = false;
                }

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (chosen <= 0)
                            break;
                        chosen--;
                        needRedrawMenu = true;
                        break;

                    case ConsoleKey.DownArrow:
                        if (chosen >= menuCount - 1)
                            break;
                        chosen++;
                        needRedrawMenu = true;
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        DrawFigure(chosen);
                        needRedrawMenu = true;
                        break;

                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        private static void DrawFigure(int figureNumber)
        {
            Figure figure = (Figure)figureNumber;
            switch (figure)
            {
                case Figure.Square:
                    DrawSquare();
                    break;
                case Figure.Diamond:
                    break;
                case Figure.Circle:
                    break;
                case Figure.Ellipse:
                    break;
            }
        }

        private static void DrawSquare()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine(string.Empty);
            }
            Console.ReadLine();
        }

        private static void DrawMenu(int chosen)
        {
            string[] array = Enum.GetNames(typeof(Figure));
            for (int i = 0; i < array.Length; i++)
            {
                string figure = (string)array[i];
                string chString = i == chosen ? "*" : string.Empty;

                Console.Write($"{figure}");
                Console.SetCursorPosition(8, Console.CursorTop);
                Console.Write($"{chString}\n");
            }
            Console.WriteLine();
            Console.WriteLine("Press \"ESC\" for quit");
        }
    }
}
