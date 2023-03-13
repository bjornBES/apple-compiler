using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apple_compiler
{
    public class BaseOutProgram
    {
        BaseProgram baseProgram = new BaseProgram();
        Program Program;
        public bool HasText { get; set; }
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
            if (HasText == true)
                return GetCode()[i];
            else
                return "";
        }
        public string[] GetCode()
        {
            if (HasText == true)
                return File.ReadAllText(baseProgram.costomProgramFile).Split(',');
            else
                return new[] { "", ""};
        }
    }
}
