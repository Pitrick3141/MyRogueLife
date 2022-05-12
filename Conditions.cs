using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRogueLife
{
    internal static class Conditions
    {
        public static bool Check(ArrayList conditions)
        {
            if (conditions.Count == 0)
                return true;
            else if (conditions.Count == 1)
                return conditions[0].GetType() == typeof(ArrayList) ? Check((ArrayList)conditions[0]!) : CheckLogic(conditions[0].ToString()!); 
            bool result = conditions[0].GetType() == typeof(ArrayList) ? Check((ArrayList)conditions[0]!) : CheckLogic(conditions[0].ToString()!);
            for (int i = 1; i < conditions.Count; i+=2)
            {
                switch(conditions[i])
                {
                    case "&":
                        if (result)
                            result = conditions[i+1].GetType() == typeof(ArrayList) ? Check((ArrayList)conditions[i+1]!) : CheckLogic(conditions[i+1].ToString()!);
                        break;
                    case "|":
                        if (result)
                            return true;
                        result = conditions[i + 1].GetType() == typeof(ArrayList) ? Check((ArrayList)conditions[i + 1]!) : CheckLogic(conditions[i + 1].ToString()!);
                        break;
                    default:
                        return false;
                }
            }
            return result;
        }
        public static bool CheckLogic(string condition)
        {
            Debug.Print("正在判断语句："+condition);
            char[] symbol = { '>', '<', '!', '?', '=' };
            int index = condition.IndexOfAny(symbol);
            string prop = condition[..index];
            int valcomp = 0;
            string sym, val;
            string[] parseVal = Array.Empty<string>();
            
            Property player = Globle.player;
            if(condition[index+1] == '=')
            {
                sym = condition.Substring(index,2);
                val = condition[(index + 2)..];
            }
            else
            {
                sym = condition.Substring(index, 1);
                val = condition[(index + 1)..];
                if (val[0] == '[')
                {
                    parseVal = val[1..^1].Split(',');
                }
                    
            }
            switch (prop)
            {
                case "CHM":
                    valcomp = player.CHM;
                    break;
                case "INT":
                    valcomp = player.INT;
                    break;
                case "STR":
                    valcomp = player.STR;
                    break;
                case "MNY":
                    valcomp = player.MNY;
                    break;
                case "SPR":
                    valcomp = player.SPR;
                    break;
                case "LIF":
                    valcomp = player.LIF;
                    break;
                case "TLT":
                    switch (sym)
                    {
                        case "?":
                            foreach (string current in parseVal)
                            {
                                if (player.tlt.Contains(Convert.ToInt32(current)))
                                {
                                    Debug.Print("结果为真");
                                    return true;
                                }
                                    
                            }
                            Debug.Print("结果为假");
                            return false;
                        case "!":
                            foreach (string current in parseVal)
                            {
                                if (player.tlt.Contains(Convert.ToInt32(current)))
                                {
                                    Debug.Print("结果为假");
                                    return false;
                                }
                            }
                            Debug.Print("结果为真");
                            return true;
                    }
                    Debug.Print("结果为假");
                    return false;
                case "EVT":
                    switch (sym)
                    {
                        case "?":
                            foreach (string current in parseVal)
                            {
                                if (player.evt.Contains(Convert.ToInt32(current)))
                                {
                                    Debug.Print("结果为真");
                                    return true;
                                }
                            }
                            Debug.Print("结果为假");
                            return false;
                        case "!":
                            foreach (string current in parseVal)
                            {
                                if (player.evt.Contains(Convert.ToInt32(current)))
                                {
                                    Debug.Print("结果为假");
                                    return false;
                                }
                            }
                            Debug.Print("结果为真");
                            return true;
                    }
                    Debug.Print("结果为假");
                    return false;
            }
            bool result = sym switch
            {
                ">" => valcomp > Convert.ToInt32(val),
                "<" => valcomp < Convert.ToInt32(val),
                "=" => valcomp == Convert.ToInt32(val),
                ">=" => valcomp >= Convert.ToInt32(val),
                "<=" => valcomp <= Convert.ToInt32(val),
                _ => false,
            };
            if(result)
            {
                Debug.Print("结果为真");
            }
            else
                Debug.Print("结果为假");
            return result;
        }
        public static (ArrayList,int) ParseConditions(string condition)
        {
            ArrayList conditions = new();
            int length = condition.Length;
            int current = 0;
            for (int i = 0; i < length; i++)
            {
                switch(condition[i].ToString())
                {
                    case "(":
                        (ArrayList sub, int sublen) = ParseConditions(condition[(i + 1)..]);
                        conditions.Add(sub);
                        i += sublen + 1;
                        current += sublen+2;
                        break;
                    case "&":
                        if(condition[current..i]!="")
                            conditions.Add(condition[current..i]);
                        conditions.Add("&");
                        current = i+1;
                        break;
                    case "|":
                        if (condition[current..i] != "")
                            conditions.Add(condition[current..i]);
                        conditions.Add("|");
                        current = i + 1;
                        break;
                    case ")":
                        if (condition[current..i] != "")
                            conditions.Add(condition[current..i]);
                        return (conditions,i);
                    default:
                        break;
                }
            }
            if(condition[current..] !="")
                conditions.Add(condition[current..]);
            return (conditions, 0);
        }
        public static void TestParse(ArrayList conditions,int level)
        {
            
            for(int i=0;i<conditions.Count;i++)
            {
                if(conditions[i]!.GetType() == typeof(string))
                {
                    Debug.Print(conditions[i]!.ToString()! + " 优先级[" +level.ToString()+"]");
                }
                else if(conditions[i]!.GetType() == typeof(ArrayList))
                {
                    TestParse((ArrayList)conditions[i]!,level+1);
                }
            }
            return;
        }
    }
}
