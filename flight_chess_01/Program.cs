using System;

namespace flight_chess
{
    //游戏规则A踩B，则B退6格
    //踩地雷退6格
    //踩时空隧道进10格
    //踩幸运轮盘 1交换位置  2轰炸对方退6格
    //踩暂停 暂停一回合
    //踩方块 无事发生
    class Program
    {
        //声明静态数组存储玩家坐标
        public static int[] PlayerPos = new int[2];
        //静态变量模拟全局变量
        public static int[] Maps = new int[100];
        //player姓名数组
        public static string[] PlayerName = new string[2];
        //暂停置位
        public static int[] PausePos = new int[2];
        static void Main(string[] args)
        {
            welcome();
            Console.Clear();
            welcome();
            Console.WriteLine("Player1:{0}表示为Ａ", PlayerName[0]);
            Console.WriteLine("Player2:{0}表示为Ｂ", PlayerName[1]);
            init_map();
            Draw_map();
            //player轮流投掷,限定不结束的条件为playerpos<99
            while (PlayerPos[0]<99 && PlayerPos[1]<99)
            {
                if (PausePos[0] == 0)
                {
                    PlayGame(0);
                    if (PlayerPos[0] == 99)
                    {
                        break;
                    }
                }
                else
                {
                    Console.Clear();
                    Draw_map();
                    Console.WriteLine("{0} 本回合停止行动",PlayerName[0]);                    
                    PausePos[0] = 0;
                    Console.ReadKey(true);                    
                }
                if (PausePos[1] == 0)
                {
                    PlayGame(1);
                }
                else
                {
                    Console.Clear();
                    Draw_map();
                    Console.WriteLine("{0} 本回合停止行动",PlayerName[1]);
                    PausePos[1] = 0;
                    Console.ReadKey(true);                    
                }
                //Console.WriteLine("{0}按任意键开始", PlayerName[0]);
                ////下面用true,在console界面就可以屏蔽输入的值
                //Console.ReadKey(true);
                ////
                ////
                ////玩家1踩到玩家2
                //if (PlayerPos[0] == PlayerPos[1])
                //{
                //    Console.WriteLine("{0}踩到{1},{2}退6格", PlayerName[0], PlayerName[1], PlayerName[1]);
                //    PlayerPos[1] = PlayerPos[1] - 6;
                //    Console.ReadKey(true);
                //}
                ////踩到关卡
                //else
                //{
                //    switch (Maps[PlayerPos[0]])
                //    {
                //        case 0:
                //            Console.WriteLine("{0}踩到□，无事发生");
                //            break;
                //        case 1:
                //            Console.WriteLine("{0}踩到◎，进行1.交换位置，2.轰炸对方并是对方退6格");
                //            string choose = Console.ReadLine();
                //            while (true)
                //            {
                //                if (choose == "1")
                //                {
                //                    Console.WriteLine("{0}和{1}交换位置", PlayerName[0], PlayerName[1]);
                //                    Console.ReadKey(true);
                //                    int temp = 0;
                //                    temp = PlayerPos[1];
                //                    PlayerPos[1] = PlayerPos[0];
                //                    PlayerPos[0] = temp;
                //                    break;
                //                }
                //                else if (choose == "2")
                //                {
                //                    Console.WriteLine("{0}轰炸{1}，击退{2}6格",PlayerName[0],PlayerName[1],PlayerName[1]);
                //                    Console.ReadKey(true);
                //                    PlayerPos[1] -= 6;                                   
                //                    break;
                //                }                                
                //            }
                //            break;
                //        case 2:
                //            Console.WriteLine("{0}踩雷，退6格", PlayerName[0]);
                //            Console.ReadKey(true);
                //            PlayerPos[0] -= 6;
                //            break;
                //        case 3:
                //            Console.WriteLine("{0}踩暂停，暂停一回合", PlayerName[0]);
                //            Console.ReadKey(true);
                //            break;
                //        case 4:
                //            Console.WriteLine("{0}踩时空隧道,前进10格", PlayerName[0]);
                //            Console.ReadKey(true);
                //            PlayerPos[0] += 10;
                //            break;
                //    }
                //}
                //Console.Clear();
                //Draw_map();
            }
            if (PlayerPos[0] == 99)
            {
                Console.WriteLine("{0} 胜出，game over",PlayerName[0]);
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("{1} 胜出，game over", PlayerName[1]);
                Console.ReadKey(true);
            }
            
        }
        //头部
        public static void welcome()
        {
            Console.WriteLine("##################");
            Console.WriteLine("Welcome");
            Console.WriteLine("##################");
            while (PlayerName[0] == null || PlayerName[0] == "" || PlayerName[1]==null || PlayerName[1]=="" || PlayerName[0]==PlayerName[1])
            {
                Console.WriteLine("Input Player 1:");
                PlayerName[0] = Console.ReadLine();
                Console.WriteLine("Input Player 2:");
                PlayerName[1] = Console.ReadLine();
            }
            //Console.ReadLine();
        }
        //初始化地图
        public static void init_map()
        {
            //普通用□
            //幸运轮盘用◎
            int[] luckyturn = { 6, 23, 40, 55, 69, 83 };
            //地雷用☆
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
            //暂停用▲
            int[] pause = { 9, 27, 60, 93, };
            //时空隧道用卐
            int[] timeTunnel = { 21, 25, 45, 63, 72, 88, 90 };
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
        //画图
        public static void Draw_map()
        {
            //图例
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("普通:□  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("幸运轮盘:◎  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("地雷:☆  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("暂停:▲  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("时空隧道:卐");

            //画第一横行
            for (int i = 0; i < 30; i++)
            {
                Console.Write(DrawStringMap(i));
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
            Console.WriteLine();
        }
        //地图格状态
        public static string DrawStringMap(int i)
        {
            string str = "";
            if (PlayerPos[0] == PlayerPos[1] && PlayerPos[1] == i)
            {
                str = "<>";
            }
            else if (PlayerPos[0] == i)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                str = "Ａ";
            }
            else if (PlayerPos[1] == i)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
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
        //随机,传参0位player1，1为player2
        public static void Random_dice(int playerNumber) 
        {
            Random random_dice_num = new Random();
            int k = random_dice_num.Next(1, 6);
            //k = 20;
            PlayerPos[playerNumber] = k + PlayerPos[playerNumber];
            if (PlayerPos[playerNumber] > 99)
            {
                PlayerPos[playerNumber] = 99;
            }
            Console.WriteLine("{0} 投掷为{1}",PlayerName[playerNumber],k);
            //PlayerPos[Player] = rule(new_pos);
            
        }
        //规则
        public static void PlayGame(int playerNumber)
        {
            Console.WriteLine("{0}按任意键开始", PlayerName[playerNumber]);
            //下面用true,在console界面就可以屏蔽输入的值
            Console.ReadKey(true);
            //投骰子
            Random_dice(playerNumber);
            Console.ReadKey(true);
            //
            //
            //玩家1踩到玩家2
            if (PlayerPos[playerNumber] == PlayerPos[1-playerNumber])
            {
                Console.WriteLine("{0}踩到{1},{2}退6格", PlayerName[playerNumber], PlayerName[1-playerNumber], PlayerName[1-playerNumber]);
                PlayerPos[1-playerNumber] = PlayerPos[1-playerNumber] - 6;
                if (PlayerPos[1 - playerNumber] < 0)
                {
                    PlayerPos[1 - playerNumber] = 0;
                }
                Console.ReadKey(true);
            }
            //踩到关卡
            else
            {
                switch (Maps[PlayerPos[playerNumber]])
                {
                    case 0:
                        Console.WriteLine("{0}踩到□，无事发生",PlayerName[playerNumber]);
                        break;
                    case 1:
                        Console.WriteLine("{0}踩到◎，进行1.交换位置，2.轰炸对方并是对方退6格",PlayerName[playerNumber]);
                        //string choose = Console.ReadLine();
                        while (true)
                        {
                            string choose = Console.ReadLine();
                            if (choose == "1")
                            {
                                Console.WriteLine("{0}和{1}交换位置", PlayerName[playerNumber], PlayerName[1-playerNumber]);
                                //Console.WriteLine("press any key to go on!");
                                Console.ReadKey(true);
                                int temp = 0;
                                Console.WriteLine("before {0}:{1}", PlayerName[playerNumber], PlayerPos[playerNumber]);
                                Console.WriteLine("before {0}:{1}", PlayerName[1- playerNumber], PlayerPos[1- playerNumber]);
                                temp = PlayerPos[playerNumber];
                                PlayerPos[playerNumber] = PlayerPos[1 - playerNumber];                                
                                PlayerPos[1 - playerNumber] = temp;
                                Console.WriteLine("after {0}:{1}", PlayerName[playerNumber], PlayerPos[playerNumber]);
                                Console.WriteLine("after {0}:{1}", PlayerName[1- playerNumber], PlayerPos[1- playerNumber]);

                                //temp = PlayerPos[1 - playerNumber];
                                //PlayerPos[1 - playerNumber] = PlayerPos[playerNumber];
                                //PlayerPos[playerNumber] = temp;
                                //Console.WriteLine("{0} and {1} switch is done and go on please press any key",PlayerName[playerNumber],PlayerName[1-playerNumber]);
                                //Console.ReadKey(true);
                                break;
                            }
                            else if (choose == "2")
                            {
                                Console.WriteLine("{0}轰炸{1}，击退{2}6格", PlayerName[playerNumber], PlayerName[1 - playerNumber], PlayerName[1 - playerNumber]);
                                Console.ReadKey(true);
                                PlayerPos[1-playerNumber] -= 6;
                                if (PlayerPos[1 - playerNumber] < 0)
                                {
                                    PlayerPos[1 - playerNumber] = 0;
                                }
                                Console.WriteLine("boom ! {0} fallback 6 step",PlayerName[1-playerNumber]);
                                break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("{0}踩雷，退6格", PlayerName[playerNumber]);
                        //Console.ReadKey(true);
                        PlayerPos[playerNumber] -= 6;
                        if (PlayerPos[playerNumber] < 0)
                        {
                            PlayerPos[playerNumber] = 0;
                        }
                        break;
                    case 3:
                        Console.WriteLine("{0}踩暂停，暂停一回合", PlayerName[playerNumber]);
                        PausePos[playerNumber] = 1;
                        Console.ReadKey(true);
                        break;
                    case 4:
                        Console.WriteLine("{0}踩时空隧道,前进10格", PlayerName[playerNumber]);
                        //Console.ReadKey(true);
                        PlayerPos[playerNumber] += 10;
                        if (PlayerPos[playerNumber] > 99)
                        {
                            PlayerPos[playerNumber] = 99;
                        }
                        //Console.ReadKey(true);
                        break;
                }
            }
            Console.WriteLine("press any key to go on!");
            Console.ReadKey(true);
            Console.Clear();
            Draw_map();
        }
    }
}
