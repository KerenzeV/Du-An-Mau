using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
namespace Assets.Khoa.Scripts
{
    
    
    public class StorageManagerSC2
    {
        public static bool SavetoFileSC2(string filename, string json)
        {
            try
            {
                var fileStream = new FileStream(filename, FileMode.Create);
                using(var writer = new StreamWriter(fileStream)) 
                {
                    writer.Write(json);
                }
                return true;
            }
            catch (System.Exception e)
            {
                Debug.Log("Error Saving file: "+e.Message);
                return false;
            }
        }

        public static string LoadFromFileSC2(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    var fileStream = new FileStream(filename, FileMode.Open);
                    using( var reader = new StreamReader(fileStream))
                    {
                        return reader.ReadToEnd();
                    }

                }
                else
                {
                    Debug.Log("File not found: "+filename);
                    return null;
                }
            }
            catch(System.Exception e) 
            {
                Debug.Log("Error Loading File: "+e.Message);
                return null;
            }
        }
    }
}
