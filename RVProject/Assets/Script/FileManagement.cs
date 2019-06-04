using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManagement : MonoBehaviour
{
    public string TextReadInAndroid(string path)
    {
        FileInfo fi = new FileInfo(path);
        if (fi.Exists)
        {
            string srTemp;
            WWW reader = new WWW(path);
            while (!reader.isDone) { }
            srTemp = reader.text;
            return srTemp;
        }
        else
        {
            string srTemp;
            WWW reader = new WWW("jar:file://" + Application.dataPath + "!/assets/BallSkin.txt");
            while (!reader.isDone) { }
            srTemp = reader.text;
            File.WriteAllText(path, srTemp);
            return srTemp;
        }
    }
    public string ReadAllFromFile(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        string temp = sr.ReadToEnd();
        sr.Close();
        return temp;
    }

    public void Write0To1InWeb(string name)
    {
        string path = @"Assets\StreamingAssets\BallSkin.txt";
        string srTemp = ReadAllFromFile(path);
        FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        string[] values = srTemp.Split(' ', '\n');
        for (int i = 0; i < values.Length - 3; i = i + 4)
        {
            if (i != 0)
            {
                sw.Write("\n");
            }
            if (values[i+2].Equals(name))
            {
                values[i + 3] = "1";
            }
            string value = values[i] + ' ' + values[i + 1] + ' ' + values[i + 2] + ' ' + values[i + 3];
            sw.Write(value);
        }
        sw.Close();
    }

    public void Write0To1InAndroid(string name)
    {
        string path = "jar:file://" + Application.dataPath + "!/assets/BallSkin.txt";
        GameObject fTemp = GameObject.Find("FileManager");
        string srTemp = fTemp.GetComponent<FileManagement>().TextReadInAndroid(path);
        FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        string[] values = srTemp.Split(' ', '\n');
        for (int i = 0; i < values.Length - 3; i = i + 4)
        {
            if (i != 0)
            {
                sw.Write("\n");
            }
            if (values[i + 2].Equals(name))
            {
                values[i + 3] = "1";
            }
            string value = values[i] + ' ' + values[i + 1] + ' ' + values[i + 2] + ' ' + values[i + 3];
            sw.Write(value);
        }
        sw.Close();
    }

    public string readStringFromFile(string filename)
    {
    #if !WEB_BUILD
        string path = pathForDocumentsFile(filename);
        if(File.Exists(path))
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            string str = null;
            str = sr.ReadLine();
            if (str == null)
            {
                sr.Close();
                file.Close();
            }
            return str;
        }
        else
        {
            return null;
        }
    #else
            return null;
    #endif
    }

    public string pathForDocumentsFile(string filename)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }
        else
        {
            return null;
        }
    }

}
