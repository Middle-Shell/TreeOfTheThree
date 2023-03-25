using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Text;
//using Newtonsoft.Json.Linq;
using Spine;
/// <summary>
/// Modify the Spine file version
/// </summary>
public class SpineImportSetting : AssetPostprocessor
{
    /*// Any resource (including folder) imports will be called
    void OnPreprocessAsset()
    {
        try
        {

            if (!this.assetPath.EndsWith(".json"))
                return;
               
            // Judgment is a spine file
            string msg = File.ReadAllText(this.assetPath, Encoding.UTF8);
            
            Json jo = Json.Deserialize(msg);
            string item = jo["skeleton"]["spine"].ToString();
               
            if (!string.IsNullOrEmpty(item)&& item.ToString()!="3.8")
            {
                jo["skeleton"]["spine"] = "3.8";// Modify version 3.8 version
                File.WriteAllText(this.assetPath, jo.ToString());
                AssetDatabase.Refresh();
            }
               

        }
        catch (Exception e)
        {
            Debug.LogError("SpineImportSetting exception {e.Message}");
        }
    }*/
  
}