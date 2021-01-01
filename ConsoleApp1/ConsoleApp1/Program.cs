using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MakingArray m = new MakingArray();
            Draw draw = new Draw();

            int[,] tab = new int[20,20];
            tab = m.GenerujTablice();
            //draw.Rysuj(tab, 2, 2, 10,10);

            Program p = new Program();
            //p.MalaTablica(tab);
            p.RoadCheck(tab, 1, 5);

            Console.ReadKey();
        }

        //void MalaTablica(int[,] tab)
        //{
        //    int iteratorX = 0;
        //    int iteratorY = 0;

        //    int[,] malyTab = new int[3, 3];

        //    Point point = new Point(1, 1);

        //    for(int i = point.X-1; i < point.X+2; i++)
        //    {
        //        for(int j = point.Y-1; j< point.Y+2; j++)
        //        {
        //            malyTab[iteratorX, iteratorY] = tab[i, j];
        //            while(iteratorX <2)
        //                iteratorX++;
        //        }
        //        while(iteratorY<2)
        //        iteratorY++;
        //    }

        //    Draw draw = new Draw();
        //    draw.RysujMala(malyTab);
        //}

        void RoadCheck(int[,] tab, int X, int Y)
        {
            Draw draw = new Draw();    
            
            for (int j= Y-1; j<Y+1; j++)
            {
                while (X + 1 < 19)
                {
                    if (j < 1)
                    {
                        j = 1;
                    }
                    if (tab[X + 1, j] == 1)
                    {
                        draw.Rysuj(tab, X, Y, X + 1, j);
                        RoadCheck(tab, X + 2, j);
                    }
                    else if (tab[X + 1, j-1] == 1)
                    {
                        draw.Rysuj(tab, X, Y, X + 1, j - 1);
                        RoadCheck(tab, X + 2, j-1);
                    }
                    else if (tab[X + 1, j + 1] == 1)
                    {
                        draw.Rysuj(tab, X, Y, X + 1, j + 1);
                        RoadCheck(tab, X + 2, j + 1);
                    }
                    else
                    {
                        Console.WriteLine("Brak Sciezki");
                        X = 19;
                        RoadCheck(tab, X + 2, j + 1);
                    }
                }

            }
        }

    }

    public class Point
    {

        public int X { get; set; }
        public int Y { get; set; }

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    public class MakingArray
    {
        public int[,] GenerujTablice()
        {
            int[,] numery = new int[20,20];
            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    numery[i,j] = random.Next(0, 2);
                }
            }

            return numery;
        }
    }

    public class Draw
    {
        public void Rysuj(int[,] tab, int X, int Y, int A, int B)
        {

            Console.Write("\n");
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (i == X || i == A)
                    {

                        if (i == X)
                        {
                            if (j == Y)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else if (i == A)
                        {
                            if (j == B)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                    Console.Write(tab[i, j]);
                }
                Console.Write("\n");
            }
            Console.WriteLine("Obecny: " + X + ", " + Y);
            Console.WriteLine("Nastepny: " + A + ", " + B);
        }
    }
}
