using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRogueLife
{
    internal class Record
    {
        private int _remakeCount;
        private int _maxScore;
        private int _totalScore;
        private int _maxEvent;
        private int _totalEvent;
        public Dictionary<int, int> itemAttainCount = new();
        public Dictionary<int, int> eventOccurCount = new();

        public Record()
        {
            _remakeCount = 0;
            _maxScore = 0;
            _totalEvent = 0;
            _maxEvent = 0;
            _totalEvent= 0;
        }
        public int RemakeCount { get { return _remakeCount; } }
        public int MaxScore { get { return _maxScore;} }
        public int TotalScore { get { return _totalScore;} }
        public int MaxEvent { get { return _maxEvent;} }
        public int TotalEvent { get { return _totalEvent;} }
    }
}
