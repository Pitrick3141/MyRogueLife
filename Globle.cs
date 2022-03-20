using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRogueLife
{
    internal class Globle
    {
        //全局变量
        public enum Lang//语言
        {
            zh_CN,
            en_CA,
        };
        public static Lang currentLanguage = Lang.zh_CN;//当前语言
        public static bool isDebug = true;//是否启用调试

        public static FormSetting formSetting = new();
        public static FormRecord formRecord = new();
        public static FormReady formReady = new();
        public static FormMain formMain = new();

        public static Property player = new();//角色信息
        public static Record record = new();//统计与记录
        public static Dictionary<int, Items> items = new();//藏品数据
        public static Dictionary<int, int> weightList = new();//藏品稀有度权重
    }
}
