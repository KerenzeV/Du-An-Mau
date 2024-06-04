using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Khoa.Scripts
{
    //luu tru thong tin
    [Serializable]  
    public class GameDataSC2
    {
        public int score = 0;
        public string timePlayed;
    }
    [Serializable]
    public class GameDataPlayedSC2
    {
        public List<GameDataSC2> plays;
    }
}
