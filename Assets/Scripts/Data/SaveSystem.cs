using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// save system mostly written from tutorial https://www.youtube.com/watch?v=5roZtuqZyuw
public static class SaveSystem
{
    // Write SaveData.cs values to the save file
    public static void Save(object saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    // return object with values from the save file
    public static object Load()
    {
        string path = Application.persistentDataPath + "/save.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            object save = formatter.Deserialize(stream);
            stream.Close();

            return save;
        } 
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}