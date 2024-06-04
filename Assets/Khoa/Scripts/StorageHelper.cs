using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

namespace Assets.Khoa.Scripts
{
    public class StorageHelper
    {
        private readonly string filename = "game_data.txt";
        public GameDataPlayedSC2 played;

        public void LoadDataSC2()
        {
            played = new GameDataPlayedSC2()
            {
                plays = new List<GameDataSC2>()
                
            };

            //doc chuoi tu file
            string dataAsJson = StorageManagerSC2.LoadFromFileSC2(filename);
            if (dataAsJson != null) 
            {
                //chuyen chuoi json thanh object
                played = JsonUtility.FromJson<GameDataPlayedSC2>(dataAsJson);
            }
        }

        public void SaveDataSC2()
        {
            //chuyen object thanh chuoi
            string dataAsJson = JsonUtility.ToJson(played);
            //luu chuoi json vao file
            StorageManagerSC2.SavetoFileSC2(filename, dataAsJson);
        }
    }
}
