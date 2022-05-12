using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRogueLife
{
    internal class Collections
    {
        internal int _index;
        internal string _name = "";
        internal string _des = "";
        internal string _eff = "";
        internal bool _exclusive = false;
        internal List<int> exclude = new();
        internal List<int> require = new();

        public void AddExc(int index)
        {
            if(!exclude.Contains(index))
            {
                exclude.Add(index);
            }
        }

        public void AddReq(int index)
        {
            if(!require.Contains(index))
            {
                require.Add(index);
            }
        }

        public int Index { get { return _index; } }
        public string Name { get { return _name; } }
        public string Des { get { return _des; } }
        public string Eff { get { return _eff; } }
        public bool Exclusive { get { return _exclusive;} }
        
        public List<int> Exclude { get { return exclude;} }
        public List<int> Require { get { return require;} }
    }

    internal class Items:Collections
    {
        private readonly int _rare;
        private readonly int _dChm;
        private readonly int _dInt;
        private readonly int _dStr;
        private readonly int _dMny;
        private readonly int _dSpr;
        private readonly int _dLif;
        //藏品子类
        public Items(int index, string name, string eff, string des, bool exclusive,int rare,int dChm,int dInt,int dStr,int dMny,int dSpr,int dLif)
        {
            _index = index;
            _name = name;
            _des = des;
            _eff = eff;
            _exclusive = exclusive;
            _rare = rare;
            _dChm = dChm;
            _dInt = dInt;
            _dStr = dStr;
            _dMny = dMny;
            _dSpr = dSpr;
            _dLif = dLif;
        }

        public int DChm { get { return _dChm; } }
        public int DInt { get { return _dInt;} }
        public int DStr { get { return _dStr;} }
        public int DMny { get { return _dMny;} }
        public int DSpr { get { return _dSpr;} }
        public int DLif { get { return _dLif;} }
        public int Rare { get { return _rare; } }
    }
}
