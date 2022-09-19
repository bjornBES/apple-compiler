using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apple_compiler
{
    public class conpiler
    {
        public void C_start(string[] line, int Length)
        {
            //code line:code
            //10|wait|num
            for (int i = 0; i < Length; i++)
            {
                string[] oneS = line[i].Split('"');
                if(oneS[0].Length != 0)
                    if (oneS[0][oneS[0].Length - 1] == ' ')
                        oneS[0] = oneS[0].Remove(oneS[0].Length-1);
                switch (oneS[0])
                {
                    default:
                        break;
                    case "wait":
                        int D = 10000;
                        do
                        {
                            D--;
                        } while (D != 0);
                        break;
                    case "print":
                        print(oneS[1]);
                        break;
                    case "let":
                        int II = i + 1;

                        break;
                    case "home":
                        break;
                }
            }
        }
        public void print(string mess)
        {
            Console.WriteLine(mess);
        }
    }
}
