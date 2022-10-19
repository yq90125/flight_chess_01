using System;

namespace flight_chess
{
    class Program
    {
        public static int[] PlayerPos = new int[2];
        public static int[] Maps = new int[100];

        static void Main(string[] args)
        {
            welcome();
            init_map();
            Draw_map();
        }
        public static void welcome()
        {
            Console.WriteLine("##################");
            Console.WriteLine("Welcome");
            Console.WriteLine("##################");
            Console.WriteLine("Input Player 1:");
            Console.ReadLine();
            Console.WriteLine("Input Player 2:");
            Console.ReadLine();
        }
        public static void init_map()
        {
            //普通用□
            //幸运轮盘用♥
            int[] luckyturn = { 6, 23, 40, 55, 69, 83 };
            //地雷用☆
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
            //暂停用▲
            int[] pause = { 9, 27, 60, 93, };
            //时空隧道用卐
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };
            for (int i = 0; i < luckyturn.Length; i++)
            {
                Maps[luckyturn[i]] = 1;
            }
            for (int i = 0; i < landMine.Length; i++)
            {
                Maps[landMine[i]] = 2;
            }
            for (int i = 0; i < pause.Length; i++)
            {
                Maps[pause[i]] = 3;
            }
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                Maps[timeTunnel[i]] = 4;
            }
        }
        public static void Draw_map()
        {
            //画第一横行
            for (int i = 0; i < 30; i++)
            {
                Console.Write(DrawStringMap(i));
                //if (PlayerPos[0] == PlayerPos[1] && PlayerPos[1] == i)
                //{
                //    Console.Write(str);
                //}
                //else if (PlayerPos[0] == i)
                //{
                //    Console.Write(str);
                //}
                //else if (PlayerPos[1] == i)
                //{
                //    Console.Write(str);
                //}
                //else
                //{
                //    switch (Maps[i])
                //    {
                //        case 0:
                //            Console.ForegroundColor = ConsoleColor.White;
                //            Console.Write("□");
                //            break;
                //        case 1:
                //            Console.ForegroundColor = ConsoleColor.Yellow;
                //            Console.Write("◎");
                //            break;
                //        case 2:
                //            Console.ForegroundColor = ConsoleColor.Red;
                //            Console.Write("☆");
                //            break;
                //        case 3:
                //            Console.ForegroundColor = ConsoleColor.Cyan;
                //            Console.Write("▲");
                //            break;
                //        case 4:
                //            Console.ForegroundColor = ConsoleColor.Green;
                //            Console.Write("卐");
                //            break;
                //    }
                //}
            }
            Console.WriteLine();
            //画竖行
            for (int i = 30; i < 35; i++)
            {
                for (int j = 0; j < 29; j++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine(DrawStringMap(i));
            }
            //第二横行
            for (int i = 64; i > 34; i--)
            {
                Console.Write(DrawStringMap(i));
            }
            Console.WriteLine();
            //画竖行
            for (int i = 65; i < 70; i++)
            {
                Console.Write(DrawStringMap(i));
                for (int j = 1; j < 30; j++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            //第三横行
            for (int i = 70; i < 100; i++)
            {
                Console.Write(DrawStringMap(i));
            }
        }
        public static string DrawStringMap(int i)
        {
            string str = "";
            if (PlayerPos[0] == PlayerPos[1] && PlayerPos[1] == i)
            {
                str = "<>";
            }
            else if (PlayerPos[0] == i)
            {
                str = "Ａ";
            }
            else if (PlayerPos[1] == i)
            {
                str = "Ｂ";
            } 
            else
            {
                str = "  ";
                switch (Maps[i])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.White;
                        str = "□";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        str = "◎";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        str = "☆" ;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        str = "▲" ;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        str = "卐";
                        break;
                }
            }
            return str;
        }
    }
}
