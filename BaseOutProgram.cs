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
        public int L;
        public void start()
        {
            Program = new Program();
            L = GetCode().Length;
        }
        public string GetOut(int i)
        {
            return GetCode()[i];
        }
        public string[] GetCode()
        {
            return File.ReadAllText(baseProgram.costomProgramFile).Split(',');
        }
    }
}
