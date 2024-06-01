using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Playables;

namespace Assets.Loc.Scripts
{
    using System.IO;
    using UnityEngine;
    internal class StorageHelper
    {
        private readonly string filename = "game_data.txt";
        public GameDataPlayed played;

        public void LoadData()
        {
            played = new GameDataPlayed()
            {
                plays = new List<GameData>()
            };

            // Read string file
            string dataAsJson = StorageManager.LoadFromFile(filename);
            if (dataAsJson != null)
            {
                played = JsonUtility.FromJson<GameDataPlayed>(dataAsJson);
            }
        }
        public void SaveData()
        {
            string dataAsJon = JsonUtility.ToJson(played);
            StorageManager.SaveToFile(filename, dataAsJon);
        }
    }
}
