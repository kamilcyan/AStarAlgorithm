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
            draw.Rysuj(tab);

            Program p = new Program();
            p.MalaTablica(tab);

            Console.ReadKey();
        }

        void MalaTablica(int[,] tab)
        {
            int iteratorX = 0;
            int iteratorY = 0;

            int[,] malyTab = new int[3, 3];

            Point point = new Point(1, 1);

            for(int i = point.X-1; i < point.X+2; i++)
            {
                for(int j = point.Y-1; j< point.Y+2; j++)
                {
                    malyTab[iteratorX, iteratorY] = tab[i, j];
                    while(iteratorX <2)
                        iteratorX++;
                }
                while(iteratorY<2)
                iteratorY++;
            }

            Draw draw = new Draw();
            draw.RysujMala(malyTab);
        }
    }

    public class Point
    {
        int _x;
        int _y;

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
        public void Rysuj(int[,] tab)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
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
