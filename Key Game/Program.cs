using System;

namespace Key_Game
{
    internal class Program
    {
        static void Stage1()
        {
            ConsoleKeyInfo KeyInfo;
            bool cont = true;

            while (cont == true)
            {
                KeyInfo = Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine(KeyInfo.Key + " Was Pressed");

                if (KeyInfo.Key == ConsoleKey.Escape)
                    cont = false;
            }
        }
        static void PaintTheSkeyInBlwo(int Num, string p)
        {
            if (Num != 0)
                Console.ForegroundColor = (ConsoleColor)Num;

            Console.Write(p);
        }
        static void Display(int x, int y, int Num, string p)
        {
            Console.SetCursorPosition(x, y);

            PaintTheSkeyInBlwo(Num, p);
        }
        static void Stage2()
        {
            Random random = new Random();

            ConsoleKeyInfo KeyInfo;

            bool FirstTime = true, Left = false, NewLine = false, Done = false, FinichLine = false;

            string p = "*";

            int[] Num = new int[2];

            int x = 0, y = 0, w = 0, h = 1;

            int Width, Height;

            Width = Console.WindowWidth;

            Height = Console.WindowHeight;

            Display(0, 19, Num[0], "C - Clear Screan, P - Change pen, R - Change Color to a random Color, W - Change color to Wite, U - Pen Up, D - Pen Down,B - Carriage Return, Escape - Exit");

            do
            {
                if (NewLine)
                    h = 1;

                if (Left)
                    Display(x + h, y, Num[0], "");

                if (Done)
                    Display(x + 1, y, Num[0], "");

                if (FinichLine)
                {
                    Display(Width - 1, y, Num[0], "");
                    x = Width - 2;
                }

                Done = false;

                Left = false;

                FinichLine = false;

                KeyInfo = Console.ReadKey();

                if (KeyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (!FirstTime)
                        x++;
                    if (x < Width - 1)
                        Display(x, y, Num[0], p);
                    else
                        FinichLine = true;

                    FirstTime = false;
                }

                else if (KeyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (x > 0)
                        h++;

                    Left = true;

                    if (x > 0)
                        Display(--x, y, Num[0], p);
                }

                else if (KeyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (y < Height - 2)
                        Display(x, ++y, Num[0], p);
                    else
                        Done = true;
                }

                else if (KeyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (y > 0)
                        Display(x, --y, Num[0], p);
                    else
                        Done = true;
                }

                else if (KeyInfo.Key == ConsoleKey.B)
                {
                    Display(0, y, Num[0], "");
                    x = -1;
                }

                else if (KeyInfo.Key == ConsoleKey.C)
                {
                    Console.Clear();
                }

                else if (KeyInfo.Key == ConsoleKey.P)
                {
                    Num[1] = random.Next(33, 48);

                    p = Convert.ToString(Convert.ToChar(Num[1]));
                }

                else if (KeyInfo.Key == ConsoleKey.R)
                {
                    Num[0] = random.Next(1, 15);

                    PaintTheSkeyInBlwo(Num[0], "");
                }

                else if (KeyInfo.Key == ConsoleKey.W)
                {
                    Num[0] = 15;
                    PaintTheSkeyInBlwo(Num[0], "");
                }

                else if (KeyInfo.Key == ConsoleKey.Escape)
                {
                    Num[0] = 0;

                    Display(0, 22, Num[0], "It was nice to have you here \n");
                    break;
                }

                NewLine = false;

                if (y != w)
                {
                    w = y;
                    NewLine = true;
                }

            } while (true);
        }
        static void Main(string[] args)
        {
            Stage1();
            Console.WriteLine("Hello World.");
        }
    }
}
