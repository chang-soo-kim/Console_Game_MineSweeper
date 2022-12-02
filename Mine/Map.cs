using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine
{
    internal class Map
    {


        int mapsize_x;
        int mapsize_y;
        
        // 맵 좌표 Get
        public int Getmap_x()
        { return mapsize_x; }
        public int Getmap_y()
        { return mapsize_y; }

        //블록의 이미지
        char block = '■';
        
        //맵을 담을 2차배열
        char[,] blocks;

        
        // 생각해보기
        // 정해진 2차배열 블럭스 값에 플레이어의 좌표값과 char 문자를 받음
        public void Setblocks(int a, int b,char c)
        {
            blocks[a,b] = c;
        }


        public void Awake()
        {
            Console.WriteLine("가로 값을 입력하세요.");
            mapsize_x = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("세로 값을 입력하세요.");
            mapsize_y = int.Parse(Console.ReadLine());
            Console.Clear();

            blocks = new char[mapsize_x, mapsize_y];  // 블럭스의 2차배열 범위


            //블럭스 배열에 블럭값 넣기
            for (int i = 0; i < mapsize_y; i++)
            {
                for (int j = 0; j < mapsize_x; j++)
                {
                    blocks[j, i] = block;

                }
            }

        }

        //맵을 좌표의 맞게 반복해서 출력
        public void Render()
        {

            for (int i = 0; i < mapsize_y; i++)
            {

                for (int j = 0; j < mapsize_x; j++)
                {
                    Console.SetCursorPosition(j*2, i);
                    Console.Write($"{blocks[j, i]}");
                }
            }


        }
    }
}
