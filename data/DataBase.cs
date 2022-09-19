using System;
using System.IO;
using System.Xml.Linq;

namespace BEs.mathF.data
{
    public class DataBase : Base
    {
        static int StoreLimit { get; } = 25;
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\private\Password\data.txt";
        public static string[ ] LT = new string[100];
        public static string[ ] LTSet = new string[100];
        public static int LTSetI;
        public static void LoadData()
        {
            string name = "";
            Object val = "";
            types types = types.none;
            string[] text = File.ReadAllText(path).Split(',', '.', ':', ' ');
            LT = text;
            for (int i = 0; i < text.Length; i++)
            {
                int II = i + 1;
                if (text[i] == "Name")
                {
                    name = text[II];
                }
                if (text[i] == "Value")
                {
                    val = text[II];
                }
                if (text[i] == "Type")
                {
                    switch (text[II])
                    {
                        case "Ints":
                            types = types.Ints;
                            break;
                        case "Bool":
                            types = types.Bool;
                            break;
                        case "String":
                            types = types.String;
                            break;
                        case "Float":
                            types = types.Float;
                            break;
                    }
                }
            }
            Set(name, val, types);
            Index++;
        }
        public static void ResetData()
        {
            string[ ] Text = { "" };
            File.WriteAllLines(path, Text);
            Index = 0;
            for (int i = 0; i < DBaseName.Length; i++)
            {
                DBaseName[i] ="";
                DBaseValues[i] ="";
                DBaseTypes[i] =types.none;
            }
        }
        public static void Set(string name, Object value, types type)
        {
            DBaseName[Index] = name;
            DBaseValues[Index] = value;
            DBaseTypes[Index] = type;
            string[ ] Text = { File.ReadAllText(path) + " Index:" + Index +
                    ".Type:" + type.ToString() +
                    ".Name:" + name +
                    ".Value:" + value + " "};
            LTSet[LTSetI]=Text[0];
            LTSetI++;
            Index++;
        }
        public static Object Get(string name)
        {
            Object val = 1;
            for (int i = 0; i < DBaseName.Length; i++)
            {
                if (DBaseName[i] == name)
                {
                    val = DBaseValues[i];
                }
            }
            return val;
        }
        public static void DeleteN(string name)
        {
            for (int i = 0; i < DBaseName.Length; i++)
            {
                if (DBaseName[i] == name)
                {
                    Index--;
                    int II = i + 1;
                    DBaseName[i] = "";
                    DBaseValues[i] = "";
                    DBaseTypes[i] = types.none;
                    DBaseName[i]=DBaseName[II];
                    DBaseValues[i] = DBaseValues[II];
                    DBaseTypes[i]=DBaseTypes[II];
                    DBaseName[II] = "";
                    DBaseValues[II] = 0;
                    DBaseTypes[II] = types.none;
                }
            }
        }
        public static void DeleteV(string val)
        {
            for (int i = 0; i < DBaseName.Length; i++)
            {
                if (DBaseName[i] == val)
                {
                    Index--;
                    int II = i + 1;
                    DBaseName[i] = "";
                    DBaseValues[i] = "";
                    DBaseTypes[i] = types.none;
                    DBaseName[i]=DBaseName[II];
                    DBaseValues[i] = DBaseValues[II];
                    DBaseTypes[i]=DBaseTypes[II];
                    DBaseName[II] = "";
                    DBaseValues[II] = 0;
                    DBaseTypes[II] = types.none;
                }
            }
        }
        public static void NewVal(string Name, Object Val, types type)
        {
            DeleteN(Name);
            Set(Name, Val, type);
        }
    }
}
