using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apple_compiler
{
    public class BaseOutProgram
    {
        BaseProgram baseProgram = new BaseProgram();
        Program Program;
        /// <summary>
        /// all the code the program.apple file
        /// </summary>
        public string[] ProgramFileCode;
        public void start()
        {
            Program = new Program();
            ProgramFileCode = File.ReadAllText(baseProgram.costomProgramFile).Split(',');
            for (int i = 0; i < ProgramFileCode.Length; i++)
            {
                Program.DoSwitch(ProgramFileCode[i]);
            }
        }
    }
}
