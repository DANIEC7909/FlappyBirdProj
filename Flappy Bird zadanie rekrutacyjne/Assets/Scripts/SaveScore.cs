using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveScore 
{
    string path;
    public SaveScore()
    {
        path = Path.Combine(Application.persistentDataPath, "highScores.txt");
        Debug.Log(path);
    }
    /// <summary>
    /// Saves Data to .txt file 
    /// </summary>
    /// <param name="val"></param>
    public void saveScores(int val)
    {
        if (!File.Exists(path))
        {
            using (StreamWriter sW = File.CreateText(path))
            {
                sW.WriteLine(val);
                sW.Close();
            }
        }
        else
        {
            using (StreamWriter sW = new StreamWriter(path,true))
            {
                sW.WriteLine(val);
                sW.Close();
            }
        }
    }
    /// <summary>
    /// Loads data from .txt file then converts it to int list 
    /// </summary>
    /// <returns>result-int List</returns>
    public List<int> LoadScores()
    {
        List<int> allcores =new List<int>();
        if (File.Exists(path))
        {
           
            foreach (string line in File.ReadLines(path))
            {
                allcores.Add(int.Parse(line));
            }
        return allcores;
        }
        else
        {
            return null;
        }
    }
}
