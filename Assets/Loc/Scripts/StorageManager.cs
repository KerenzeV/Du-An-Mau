using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Loc.Scripts
{
    using System.IO;
    using UnityEngine;
    public class StorageManager
    {
        public static bool SaveToFile(string filename, string json)
        {
            try
            {
                var fileStream = new FileStream(filename, FileMode.Create);
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write(json);
                }
                return true;
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogError("Error saving file: " + e.Message);
                return false;
            }
        }

        public static string LoadFromFile(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    var fileStream = new FileStream(filename, FileMode.Open);
                    using (var reader = new StreamReader(fileStream))
                    {
                        return reader.ReadToEnd();
                    }

                }
                else
                {
                    Debug.Log("File not found: " + filename);
                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.Log("Error loading file: " + e.Message);
                return null;
            }
        }
    }
}
