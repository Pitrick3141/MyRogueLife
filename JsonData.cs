﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyRogueLife
{
    internal static class JsonData
    {
        public static void SavePlayer(Property prop)
        {
            JsonSerializer serializer = new();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using(StreamWriter sw  = new("player.json"))
            {
                using JsonWriter writer = new JsonTextWriter(sw);
                serializer.Serialize(writer, prop);
            }
            Debug.Print("玩家存档信息已保存");
        }
        public static Property LoadPlayer()
        {
            if (!File.Exists("player.json"))
            {
                Debug.Print("玩家存档信息不存在，已建立新的存档信息并读取", 2);
                Property newprop = new();
                SavePlayer(newprop);
                return newprop;
            }
            string playerInfo = File.ReadAllText(@"player.json");
            if (JsonConvert.DeserializeObject<Property>(playerInfo) != null)
            {
                Property? prop = JsonConvert.DeserializeObject<Property>(playerInfo);
                Debug.Print("玩家信息已读取");
                return prop!;//null抑制符，已判别不为null
            }
            else
            {
                Debug.Print("读取玩家存档信息时出现错误，已返回空的玩家信息", 1);
                return new Property();
            }
        }
        public static void LoadCollections()
        {
            if (!File.Exists("data/items.json"))
            {
                Debug.Print("藏品数据文件不存在或完整性错误", 1);
                return;
            }
            Debug.Div();
            Globle.items.Clear();
            Globle.weightList.Clear();
            Debug.Print("开始读取藏品数据文件...");
            using (StreamReader sr = new("data/items.json"))
            {
                using JsonReader reader = new JsonTextReader(sr);
                Debug.Print("正在读取藏品...");
                foreach (var item in JToken.ReadFrom(reader))
                {
                    int index = (int)item["id"]!;
                    string name = item["name"]!.ToString();
                    string eff = item["eff"]!.ToString();
                    string des = item["des"]!.ToString();
                    bool exclusive = (bool)item["exclusive"]!;
                    int rare = (int)item["rare"]!;
                    int dChm = (int)item["CHM"]!;
                    int dInt = (int)item["INT"]!;
                    int dStr = (int)item["STR"]!;
                    int dMny = (int)item["MNY"]!;
                    int dSpr = (int)item["SPR"]!;
                    int dLif = (int)item["LIF"]!;
                    //Debug.Print(index + " " + name + " " + eff + " " + des);
                    Items temp = new(index, name, eff, des, exclusive,rare,dChm,dInt,dStr,dMny,dSpr,dLif);
                    foreach (var req in item["require"]!)
                    {
                        int reqId = (int)req;
                        temp.AddReq(reqId);
                    }
                    foreach (var exc in item["exclude"]!)
                    {
                        int excId = (int)exc;
                        temp.AddExc(excId);
                    }
                    Globle.items.Add(index, temp);
                    if(!temp.Exclusive)
                    {
                        Globle.weightList.Add(index, temp.Rare);
                    }
                }
            }
            Debug.Print("藏品读取完成");
            Debug.Div();

        }
        public static void UnloadCollections()
        {
            Debug.Div();
            Debug.Print("开始卸载藏品数据文件...");
            Globle.items.Clear();
            Debug.Print("藏品数据文件卸载完成");
            Debug.Div();
        }

        public static void LoadEvents()
        {
            if (!File.Exists("data/events.json"))
            {
                Debug.Print("事件数据文件不存在或完整性错误", 1);
                return;
            }
            Debug.Div();
            Globle.events.Clear();
            Globle.eventWeightList.Clear();
            Debug.Print("开始读取事件数据文件...");
            using (StreamReader sr = new("data/events.json"))
            {
                using JsonReader reader = new JsonTextReader(sr);
                Debug.Print("正在读取事件...");
                foreach (var item in JToken.ReadFrom(reader))
                {
                    int index = (int)item["id"]!;
                    string name = item["name"]!.ToString();
                    string des = item["des"]!.ToString();
                    bool exclusive = (bool)item["exclusive"]!;
                    int rare = (int)item["rare"]!;
                    List<int> resultList = new();
                    foreach (var res in item["results"]!)
                    {
                        int resId = (int)res;
                        resultList.Add(resId);
                    }
                    Events temp = new(index, name, des, exclusive, rare,resultList);
                    foreach (var req in item["require"]!)
                    {
                        int reqId = (int)req;
                        temp.AddReq(reqId);
                    }
                    foreach (var exc in item["exclude"]!)
                    {
                        int excId = (int)exc;
                        temp.AddExc(excId);
                    }
                    Globle.events.Add(index, temp);
                    if (!temp.Exclusive)
                    {
                        Globle.eventWeightList.Add(index, temp.Rare);
                    }
                }
            }
            Debug.Print("事件读取完成");
            Debug.Div();
        }
        public static void UnloadEvents()
        {
            Debug.Div();
            Debug.Print("开始卸载事件数据文件...");
            Globle.events.Clear();
            Debug.Print("事件数据文件卸载完成");
            Debug.Div();
        }

        public static void LoadResults()
        {
            if (!File.Exists("data/results.json"))
            {
                Debug.Print("结果数据文件不存在或完整性错误", 1);
                return;
            }
            Debug.Div();
            Globle.results.Clear();
            Debug.Print("开始读取结果数据文件...");
            using (StreamReader sr = new("data/results.json"))
            {
                using JsonReader reader = new JsonTextReader(sr);
                Debug.Print("正在读取结果...");
                foreach (var item in JToken.ReadFrom(reader))
                {
                    int index = (int)item["id"]!;
                    string name = item["name"]!.ToString();
                    string eff = item["eff"]!.ToString();
                    string des = item["des"]!.ToString();
                    string cond = item["conditions"]!.ToString();
                    List<int> awards = new();
                    foreach (var awd in item["awards"]!)
                    {
                        int awdId = (int)awd;
                        awards.Add(awdId);
                    }
                    Results temp = new(index, name, eff, des, awards, cond);
                    foreach (var req in item["require"]!)
                    {
                        int reqId = (int)req;
                        temp.AddReq(reqId);
                    }
                    foreach (var exc in item["exclude"]!)
                    {
                        int excId = (int)exc;
                        temp.AddExc(excId);
                    }
                    Globle.results.Add(index, temp);
                }
            }
            Debug.Print("结果读取完成");
            Debug.Div();
        }

        public static void UnloadResults()
        {
            Debug.Div();
            Debug.Print("开始卸载结果数据文件...");
            Globle.results.Clear();
            Debug.Print("结果数据文件卸载完成");
            Debug.Div();
        }
        public static void SaveRecord(Record rec)
        {
            JsonSerializer serializer = new();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new("record.json"))
            {
                using JsonWriter writer = new JsonTextWriter(sw);
                serializer.Serialize(writer, rec);
            }
            Debug.Print("统计与记录信息已保存");
        }

        public static Record LoadRecord()
        {
            if (!File.Exists("record.json"))
            {
                Debug.Print("统计与记录不存在，已建立新的统计与记录并读取", 2);
                Record newrec = new();
                SaveRecord(newrec);
                return newrec;
            }
            string recordInfo = File.ReadAllText(@"record.json");
            if (JsonConvert.DeserializeObject<Record>(recordInfo) != null)
            {
                Record? rec = JsonConvert.DeserializeObject<Record>(recordInfo);
                Debug.Print("统计与记录已读取");
                return rec!;//null抑制符，已判别不为null
            }
            else
            {
                Debug.Print("读取统计与记录时出现错误，已返回空的统计与记录", 1);
                return new Record();
            }
        }
    }
}
