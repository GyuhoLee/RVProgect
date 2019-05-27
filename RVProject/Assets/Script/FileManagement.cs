using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManagement : MonoBehaviour
{
    public string TextReadInAndroid(string path)
    {
        string jsonString;
        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(path);
            while (!reader.isDone) { }
            jsonString = reader.text;
        }
        else
        {
            jsonString = File.ReadAllText(path);
        }
        return jsonString;
    }

    public void writeStringToFile(string str, string filename)
    {
     #if !WEB_BUILD
        string path = pathForDocumentsFile(filename);
        FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(str);
        sw.Close();
        file.Close();
    #endif
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
