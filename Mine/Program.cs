using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GameLoop gl = new GameLoop();
            gl.Awake();
            gl.Start();

            while (true)
            {
                gl.Render();
                gl.Update();
            }
        }

    }
}


