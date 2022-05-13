using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRogueLife
{
    internal class Events:Collections
    {
        private int _rare;
        private List<int> _resultList;//结果列表

        public Events(int index, string name, string des, bool exclusive, int rare,List<int> resultList)
        {
            _exclusive = exclusive;
            _rare = rare;
            _index = index;
            _name = name;
            _des = des;
            _resultList = resultList;
        }
        public int Rare { get { return _rare; } }
        public List<int> ResultList
        {
            get { return _resultList; }
        }
    }
    internal class Results:Collections
    {
        internal List<int> _awards = new();//完成结果后获得的藏品列表
        internal string _cond;

        public Results(int index, string name, string eff, string des, List<int> awards,string conditions)
        {
            _index = index;
            _name = name;
            _des = des;
            _eff = eff;
            _awards = awards;
            _cond = conditions;
        }

        public void Occur()
        {
            if (Conditions.Check(Conditions.ParseConditions(_cond).Item1))
            {
                Debug.Print("触发了序号为" + _index + "的结果" + _name);
                foreach (int index in _awards)
                {
                    Globle.player.AttainItem(index);
                }
                return;
            }
            else
            {
                Debug.Print("无法触发序号为" + _index + "的结果" + _name + "：未满足所需求的条件", 1);
            }
        }
    }
}
