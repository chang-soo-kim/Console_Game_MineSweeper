using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine
{
    internal class Mine
    {
        public Map map;

       //랜덤선언
        Random random = new Random();
        
        //마인의 좌표값
        int[] mine_x;
        int[] mine_y;

        //마인의 입력값
        int mine_num;
        //마인의 좌표값 2차배열 선언
        int [,] mine_xy;
        bool[,] open;
        // 지뢰의 값
        int mine_Hide = 100;
        
        // 마인 좌표값 Get
        public int Getmine_xy(int a,int b)
        {
            return mine_xy[a,b];
        }
        public bool GetOpen(int a, int b)
        { return open[a, b]; }

        public void SetOpen(int a, int b, bool c)
        {
            open[a, b] = c;
        }

        public void Awake()
        {

            Console.WriteLine("지뢰의 갯수를 입력하세요.");
            mine_num = int.Parse(Console.ReadLine());
            mine_x = new int[mine_num];
            mine_y = new int[mine_num];

            mine_xy = new int[map.Getmap_x()*2-1 , map.Getmap_y()];
            open = new bool[map.Getmap_x() * 2 - 1, map.Getmap_y()];
        }

        public void Start()
        {
            for (int i = 0; i < mine_num; i++)
            {
                do
                {
                    mine_x[i] = random.Next(0, map.Getmap_x() * 2 - 1);
                    if (mine_x[i] % 2 == 1)
                    {
                        --mine_x[i];
                    }
                    mine_y[i] = random.Next(0, map.Getmap_y());
                } while (mine_xy[mine_x[i], mine_y[i]] == mine_Hide);

                mine_xy[mine_x[i], mine_y[i]] = mine_Hide;

            }

        }


    }
}
