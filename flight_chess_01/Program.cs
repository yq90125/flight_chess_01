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
            for (int i = 0; i < 30; i++)
            {
                if (PlayerPos[0] == PlayerPos[1] && PlayerPos[1] == i)
                {
                    Console.Write("<>");
                }
                else if (PlayerPos[0] == i)
                {
                    Console.Write("Ａ");
                }
                else if (PlayerPos[1] == i)
                {
                    Console.Write("Ｂ");
                }
                else
                {
                    switch (Maps[i])
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("□");
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("♥");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("☆");
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("▲");
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("卐");
                            break;
                    }
                }
            }
        }
    }
}
