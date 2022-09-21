using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apple_compiler
{
    public class macroInfo
    {
        public int name;
        public string[] MacroLine;
    }
    public class macro
    {
        Program Program = new Program();
        string macropath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
            @"\Engine_Develop\Apple_Compiler\macros\";
        public string dirMacroPath;
        public conpiler conpiler;
        public macroInfo[] Macros;
        public macro()
        {
        }
        public bool hastest(string macropath)
        {
            if (File.ReadAllText(macropath) != "")
            {
                return true;
            }
            else
                return false;
        }
            DirectoryInfo directoryInfo;
        public void GetMacro(bool MacroHasText)
        {
            if (hastest(dirMacroPath) != true)
                directoryInfo = new DirectoryInfo(macropath);
            else
                directoryInfo = new DirectoryInfo(dirMacroPath);
            FileInfo[] files = directoryInfo.GetFiles();
            int Le = files.Length;
            int Tole = 0;
            Macros = new macroInfo[Le];
            for (int i = 0; i < Macros.Length; i++)
            {
                Macros[i] = new macroInfo();
            }
            foreach (var file in files)
            {
                string line = File.ReadAllText(file.DirectoryName + @"\" + file.Name);
                string comands = line.Split('[', ']')[1];
                int MacroNum = int.Parse(line.Split('$', '[')[1]);
                string[] OneComand = comands.Split(',');
                Macros[Tole].MacroLine = OneComand;
                Macros[Tole].name = MacroNum;
                Tole++;
            }
        }
        public void Read(int tag)
        {
            for (int i = 0; i < Macros.Length; i++)
                if (tag == Macros[i].name)
                    for (int II = 0; II < Macros[i].MacroLine.Length; II++)
                        Program.DoSwitch(Macros[i].MacroLine[II]);
        }
    }
}
