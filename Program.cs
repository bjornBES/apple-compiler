using System;
using System.IO;

namespace apple_compiler
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.start();
        }
        public void start()
        {
            PBStart();
            macro.conpiler = conpiler;
            macro.dirMacroPath = costomMacroDir;
            MacroFileHasTestin = macro.hastest(costomMacroFile);
            BaseOutProgram.start();
            if (MacroFileHasTestin != true)
            {
                Writeline("starting program...");
                wait();
                consoleStuff();
            }
            update();
        }
        public void update()
        {
            if (MacroFileHasTestin != true)
            {
                Console.Write("]");
                string User = Console.ReadLine();
                DoSwitch(User);
            }
            else
                for (int i = 0; i < BaseOutProgram.L; i++)
                {
                    DoSwitch(BaseOutProgram.GetOut(i));
                }
            update();
        }
        public void DoSwitch(string User)
        {
            switch (User)
            {
                default:
                    makeComant(User);
                    break;
                case "macro":
                    startmakemacro();
                    macro.GetMacro(MacroFileHasTestin);
                    break;
                case "help":
                    Writeline(help);
                    break;
                case "rmacro":
                    macro.GetMacro(MacroFileHasTestin);
                    Writeline("what macro");
                    Console.Write("$macro #");
                    int user = toint(Console.ReadLine());
                    macro.Read(user);
                    break;
                case "home":
                    Console.Clear();
                    break;
                case "list":
                    Array.Sort(listNum, listCode, 0, ListIndex);
                    for (int i = 0; i < ListIndex; i++)
                    {
                        Writeline(listNum[i] + ": " + listCode[i]);
                    }
                    break;
                case "run":
                    conpiler.C_start(listCode, ListIndex);
                    break;
            }
        }
        public void makeComant(string User)
        {
            int lineNum = 0;
            for (int i = 0; i < User.Length; i++)
            {
                if (User[i] == ' ')
                {
                    if (i == 1)
                    {
                        string num = User[i - 1].ToString();
                        lineNum = toint(num);
                    }
                    if (i == 2)
                    {
                        string num = User[i - 2].ToString() + User[i - 1].ToString();
                        lineNum = toint(num);
                    }
                }
            }
            string NewCode = "";
            string[] _Suser = User.Split(' ');
            int cP = 1;
            if (lineNum != 0)
                cP = 1;
            else
                cP = 0;
            for (int c = cP; c < _Suser.Length; c++)
            {
                if (c > 1)
                    NewCode = NewCode + " " + _Suser[c];
                else
                    NewCode = NewCode + _Suser[c];
            }
            listCode[ListIndex] = listCode[ListIndex] + NewCode;
            listNum[ListIndex] = listNum[ListIndex] + lineNum;
            ListIndex++;
        }
        public void MakeMacro(string path)
        {
            string comands = Console.ReadLine();
            if (comands != "end")
            {
                File.WriteAllText(path, File.ReadAllText(path) + comands + ",");
                MakeMacro(path);
            }
            else
            {
                File.WriteAllText(path, File.ReadAllText(path) + "]");
                Writeline("]");
            }
        }
        void startmakemacro()
        {
            Writeline("start making the macro");
            Console.Write("$macro #");
            int MacroName = toint(Console.ReadLine());
            Writeline("$macro #" + MacroName + "\r\n[");
            Writeline("make a file name for ex .m, .macro and lower and upper");
            string filename = Console.ReadLine();
            Writeline("write any comand in the macro");
            Console.Write("]");
            string MacropathFull = macropath + MacroName + filename;
            if (File.Exists(MacropathFull))
            {
                File.WriteAllText(MacropathFull, "");
                File.WriteAllText(MacropathFull, "$" + MacroName + "\r\n" + "[\r\n");
            }
            else
            {
                File.Create(MacropathFull);
                File.WriteAllText(MacropathFull, "$" + MacroName + "\r\n" + "[");
            }
            MakeMacro(MacropathFull);
        }
    }
}