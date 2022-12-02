using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine
{
    internal class GameLoop
    {
        ConsoleKeyInfo key;
        Map map = new Map();
        Player player = new Player();
        Mine mine = new Mine();

        public bool gameover = false;


        public int BOARD_WIDTH = 60;
        public int BOARD_HEIGHT = 30;

        public void Awake()
        {
            player.map = map;
            player.mine = mine;
            mine.map = map;

            map.Awake();
            mine.Awake();


            BOARD_WIDTH = map.Getmap_x()*2;
            BOARD_HEIGHT = map.Getmap_y();
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth = BOARD_WIDTH;
            Console.BufferHeight = Console.WindowHeight = BOARD_HEIGHT+2;

           

        }

        public void Start()
        {
            mine.Start();
        }
        public void Update()
        {

            
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            Console.Clear();
                            player.Move_Left();
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        {
                            Console.Clear();
                            player.Move_Right();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        {
                            Console.Clear();
                            player.Move_Up();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            Console.Clear();
                            player.Move_Down();
                        }
                        break;
                        case ConsoleKey.Spacebar:
                    {
                        
                        Console.Clear();
                        
                        player.Move_Open(player.GetPlayer_x(),player.GetPlayer_y());
                    }
                         break;

                }


            if (player.Alive == true)
            {
               gameover = true;
            }

        }
            public void Render()
            {
            if(gameover == false)
            {
            map.Render();
            player.Render();

            }
            else if(gameover == true)
            {
                Console.SetCursorPosition(BOARD_WIDTH / 2-5, BOARD_HEIGHT / 2);
                Console.Write("Game Over");
            }
        }

    } 
}
