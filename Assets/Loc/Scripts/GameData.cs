using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Loc.Scripts
{
    
        [SerializeField]
        public class GameData
        {
            public int score = 0;
            public string timePlayed;
        }

        [SerializeField]
        public class GameDataPlayed
        {
            public List<GameData> plays;
        }
 }



