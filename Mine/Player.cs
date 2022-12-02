using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine
{
    internal class Player
    {
        public Map map;
        public Mine mine;

        
        int player_x = 0;
        int player_y = 0;
        int count = 0;
        
        


        // 지뢰를 밟았을때 false
        public bool Alive = false;

  


        // 플레이어 좌표 Get
        public int GetPlayer_x()
        { return player_x; }
        public int GetPlayer_y()
        { return player_y; }



        // 플레이어 상하좌우
        public void Move_Left()
        {
            if (player_x != 0)
            {
                player_x -= 2;
            }
        }
        public void Move_Right()
        {
            if (player_x < map.Getmap_x() * 2 - 2)
            {

                player_x += 2;
            }

        }
        public void Move_Up()
        {
            if (player_y != 0)
            {
                --player_y;
            }
        }
        public void Move_Down()
        {
            if (player_y != map.Getmap_y() - 1)
            {
                ++player_y;
            }
        }
        // 플레이어 위치에 오픈
   
        
        public void Move_Open(int player_x, int player_y)
        {
            

            if (player_y <0 || player_y >= map.Getmap_y()) return;

            if (player_x <0 || player_x >= map.Getmap_x()*2) return;



            if (mine.GetOpen(player_x,player_y) == true)
            { return; }


            

            // 플레이어 좌표와 지뢰의 좌표가 같을때 Alive = true로 만듬
            if (mine.Getmine_xy(player_x, player_y) == 100)
            {
                
                Alive = true;
            }
            else
            {
                count = 0;
                // 좌상단
                if (player_x > 0 && player_y > 0)
                {
                    if (mine.Getmine_xy(player_x - 2, player_y - 1) == 100)
                    {
                        ++count;
                    }
                }
                // 상단
                if (player_y > 0)
                {
                    if (mine.Getmine_xy(player_x, player_y - 1) == 100)
                    {
                        ++count;
                    }
                }
                // 우상단
                if (player_x < map.Getmap_x() * 2 - 2 && player_y > 0)
                {
                    if (mine.Getmine_xy(player_x + 2, player_y - 1) == 100)
                    {
                        ++count;
                    }
                }
                // 좌측
                if (player_x > 0)
                {
                    if (mine.Getmine_xy(player_x - 2, player_y) == 100)
                    {
                        ++count;
                    }
                }
                // 우측
                if (player_x < map.Getmap_x() * 2 - 2)
                {
                    if (mine.Getmine_xy(player_x + 2, player_y) == 100)
                    {
                        ++count;
                    }

                }
                // 좌하단
                if (player_x > 0 && player_y < map.Getmap_y() - 1)
                {
                    if (mine.Getmine_xy(player_x - 2, player_y + 1) == 100)
                    {
                        ++count;
                    }

                }
                // 하단
                if (player_y < map.Getmap_y() - 1)
                {
                    if (mine.Getmine_xy(player_x, player_y + 1) == 100)
                    {
                        ++count;
                    }

                }
                //우하단
                if (player_x < map.Getmap_x() * 2 - 2 && player_y < map.Getmap_y() - 1)
                {
                    if (mine.Getmine_xy(player_x + 2, player_y + 1) == 100)
                    {
                        ++count;
                    }
                }
                mine.SetOpen(player_x, player_y, true);

                if (mine.GetOpen(player_x, player_y) == true)
                { 
                //카운터의 갯수로 case를 출력
                switch (count)
                {
                    case 0:
                        {

                            map.Setblocks(player_x / 2, player_y, ' ');
                            
                            break;
                        }
                    case 1:
                        {
                            map.Setblocks(player_x / 2, player_y, '１');
                            
                            break;
                        }
                    case 2:
                        {
                            map.Setblocks(player_x / 2, player_y, '2');

                            break;
                        }
                    case 3:
                        {
                            map.Setblocks(player_x / 2, player_y, '3');
                            
                            break;
                        }
                    case 4:
                        {
                            map.Setblocks(player_x / 2, player_y, '4');
                            
                            break;
                        }
                    case 5:
                        {
                            map.Setblocks(player_x / 2, player_y, '5');
                            
                            break;
                        }
                    case 6:
                        {
                            map.Setblocks(player_x / 2, player_y, '6');
                            
                            break;
                        }
                    case 7:
                        {
                            map.Setblocks(player_x / 2, player_y, '7');
                            
                            break;
                        }
                    case 8:
                        {
                            map.Setblocks(player_x / 2, player_y, '8');
                            
                            break;
                        }
                            
                }
                }

                

                if (count > 0) return;

                if (mine.Getmine_xy(player_x, player_y) == 100) return;


                //좌상단
                Move_Open(player_x - 2, player_y - 1);


                ////상단
                Move_Open(player_x, player_y - 1);

                ////우상단
                Move_Open(player_x + 2, player_y - 1);

                ////좌측
                Move_Open(player_x - 2, player_y);

                //////우측
                Move_Open(player_x + 2, player_y);

                //좌하단
                Move_Open(player_x - 2, player_y + 1);

                //하단
                Move_Open(player_x, player_y + 1);

                //우하단
                Move_Open(player_x + 2, player_y + 1);









            }
        }


        
        public void Render()
        {
            // Console.WriteLine($"{player_x}, {player_y}");

            Console.SetCursorPosition(player_x, player_y);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write('■');
            Console.ResetColor();//글씨색상 초기화
        }
    }
}

