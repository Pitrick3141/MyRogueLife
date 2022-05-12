using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRogueLife
{
    internal class Property
    {
        private int _chm = 0;//魅力
        private int _int = 0;//智力
        private int _str = 0;//体质
        private int _mny = 0;//家境
        private int _spr = 0;//精神
        private int _lif = 0;//剩余生命
        public List<int> evt = new();//藏品列表
        public List<int> tlt = new();//事件列表
        private int _family = 0;//出身
        private int _diff = 0;//难度

        public int CHM { get { return _chm; } set { _chm = value; } }
        public int INT { get { return _int; } set { _int = value; } }
        public int STR { get { return _str; } set { _str = value; } }
        public int MNY { get { return _mny; } set { _mny = value; } }
        public int SPR { get { return _spr; } set { _spr = value; } }
        public int LIF { get { return _lif; } set { _lif = value; } }
        public int Family { get { return _family; } set { _family = value; } }
        public int Difficulty { get { return _diff; } set { _diff = value; } }
        public Property()
        {

        }
        public bool AttainItem(int index)
        {
            if(Globle.items.ContainsKey(index))
            {
                Items item = Globle.items[index];
                foreach(int exclude in item.Exclude)
                {
                    if(tlt.Contains(exclude))
                    {
                        Debug.Print("无法获取序号为" + index + "的藏品" + item.Name+"：与序号为"+exclude+"的藏品"+ Globle.items[exclude].Name+"互斥",1);
                        return false;
                    }
                }
                foreach (int require in item.Require)
                {
                    if (!tlt.Contains(require))
                    {
                        Debug.Print("无法获取序号为" + index + "的藏品" + item.Name + "：需要先获取序号为" + require + "的藏品" + Globle.items[require].Name, 1);
                        return false;
                    }
                }
                Debug.Print("获取了序号为" + index + "的藏品" + item.Name);
                _chm += item.DChm;
                _int += item.DInt;
                _str += item.DStr;
                _mny += item.DMny;
                _spr += item.DSpr;
                _lif += item.DLif;
                tlt.Add(index);
                if(!Globle.record.itemAttainCount.ContainsKey(index))
                {
                    Globle.record.itemAttainCount.Add(index, 0);
                }
                Globle.record.itemAttainCount[index]++;
                return true;
            }
            else
            {
                Debug.Print("不存在序号为" + index + "的藏品", 1);
                return false;
            }
        }
        public void PrintInfo()
        {
            Debug.Div();
            Debug.Print("当前玩家信息:");
            Debug.Print("魅力 " + _chm.ToString());
            Debug.Print("智力 " + _int.ToString());
            Debug.Print("体质 " + _str.ToString());
            Debug.Print("财富 " + _mny.ToString());
            Debug.Print("心态 " + _spr.ToString());
            Debug.Print("剩余生命 " + _lif.ToString());
            Debug.Div();
        }
    }
}
