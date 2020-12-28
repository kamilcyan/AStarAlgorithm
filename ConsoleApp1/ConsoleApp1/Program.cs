using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            draw.Rysuj(tab, 0, 0);

            Program p = new Program();
            //p.MalaTablica(tab);
            p.RoadCheck(tab, 1, 1);

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
            Console.Write("\n");

            for (int i = X - 1; i < X + 1; i++)
            {
                for(int j = Y -1; j<Y+1; j++)
                {
                    if(i ==0 )
                    {
                        i = 1;
                    }
                    if ( j == 0)
                    {
                        j = 1;
                    }
                    if (tab[i, j] == 1)
                    {
                        draw.Rysuj(tab, i, j);
                        tab[i, j] = 0;
                        RoadCheck(tab, i, j);
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
        public void Rysuj(int[,] tab, int X, int Y)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if(i == X)
                    {
                        if(j == Y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(tab[i, j]);
                            Console.ResetColor();
                        }
                    }
                    Console.Write(tab[i,j]);
                }
                Console.Write("\n");
            }
        }

        public void RysujMala(int[,] tab)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(tab[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
