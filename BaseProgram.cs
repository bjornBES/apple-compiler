using System;
using System.IO;

namespace apple_compiler
{
    public class BaseProgram
    {
        public string help;
        public string costomMacroFile = @"C:\Users\bjornBEs\source\repos\test apple compiler\macro.m";
        public bool MacroFileHasTestin;
        public string costomProgramFile = @"C:\Users\bjornBEs\source\repos\test apple compiler\program.apple";
        public string propath = @"\Engine_Develop\Apple_Compiler";
        public string Wpropath = @"Engine_Develop\Apple_Compiler";
        public string macropath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + 
            @"\Engine_Develop\Apple_Compiler\macros\";
        public string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public bool dir = false;
        public string[] macroFileName = { ".macro", ".m", ".M", ".Macro" };
        public int ListIndex = 0;
        public int StroeByte = 16384;
        public int ListByte = 5000;
        public string[] listCode = new string[5000];
        public int[] listNum = new int[5000];
        public conpiler conpiler;
        public macro macro;
        public void PBStart()
        {
            conpiler = new conpiler();
            macro = new macro();
        }
        public void Writeline(string line)
        {
            Console.WriteLine(line);
        }
        public void consoleStuff()
        {
            Writeline("CC:Engine Develop 2022");
            Console.Clear();
            Writeline("Welcome to BEs_Code v0.0.1.");
            Writeline("Type .help for more infomation.");
            help =
                ">    home      clears the console\r\n" +
                ">    run       runing the code/Program\r\n" +
                ">    list      you get a list of all code\r\n" +
                ">    info      what is this program about?\r\n" +
                ">    macro     make a macro and use it in code";
        }
        public int toint(string s)
        {
            return int.Parse(s);
        }
        public void wait()
        {
            int wait = 0;
            do
            {
                if (dir != true)
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    directory.CreateSubdirectory(@"Engine_Develop\Apple_Compiler");
                    directory.CreateSubdirectory(Wpropath + @"\Value");
                    directory.CreateSubdirectory(Wpropath + @"\macros");
                    File.Create(path + propath + @"\Value\data.txt");
                    dir = true;
                }
                wait++;
            } while (wait != 2147483647);
        }
    }
}
