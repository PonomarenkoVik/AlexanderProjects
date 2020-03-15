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
        const int topStartPosition = 25;
        const int leftStartposition = 25;
        const int _size = 26;
        const string symbol = "#";


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
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
                    DrawDiamond();
                    break;
                case Figure.Circle:
                    DrawCircle();
                    break;
                case Figure.Ellipse:
                    DrawEllipse();
                    break;
            }
            Console.ReadLine();
        }

        private static void DrawEllipse()
        {
            throw new NotImplementedException();
        }

        private static void DrawCircle()
        {
            int xInit = leftStartposition + _size / 2;
            int yInit = topStartPosition + _size / 2;
            for (int i = 0; i <= _size/2; i++)
            {

                int x = i;
                int y = (int)Math.Sqrt(Math.Pow(_size / 2, 2) - Math.Pow(i, 2));
                //bottom right part
                Console.SetCursorPosition(xInit + x, yInit + y);
                Console.Write(symbol);
                //bottom left part
                Console.SetCursorPosition(xInit - x, yInit + y);
                Console.Write(symbol);
                //top right part
                Console.SetCursorPosition(xInit + x, yInit - y);
                Console.Write(symbol);
                //top left part
                Console.SetCursorPosition(xInit - x, yInit - y);
                Console.Write(symbol);
            }
        }

        private static void DrawDiamond()
        {
            for (int i = -_size/2; i < _size/2; i++)
            {
                for (int j = -_size/2 + Math.Abs(i); j < _size / 2 - Math.Abs(i); j++)
                {
                    Console.SetCursorPosition(leftStartposition + j + _size/2, topStartPosition + i + _size/2);
                    Console.Write(symbol);
                }
                Console.WriteLine(string.Empty);
            }
        }

        private static void DrawSquare()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.SetCursorPosition(leftStartposition + i, topStartPosition + j);
                    Console.Write(symbol);
                }
                Console.WriteLine(string.Empty);
            }
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
