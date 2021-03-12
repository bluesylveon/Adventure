using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

public class SaveFile 
{
    private readonly string _SaveFileName;
    private SaveData _SaveData;

    public SaveFile(string name, string filename)
    {
        _SaveFileName = filename;
        _SaveData = new SaveData(name);
        Save();
    }


    public void Save()
    {
        string jsonString = JsonSerializer.Serialize(_SaveData);
        File.WriteAllText(_SaveFileName, jsonString);
    }

    public SaveData Read()
    {
        string jsonString = File.ReadAllText(_SaveFileName);
        return JsonSerializer.Deserialize<SaveData>(jsonString);
    }

    public class SaveData
    {
        public string _PlayerName { get; set; }
        public int _Level { get; set; }
        public SaveData(string name)
        {
            _Level = 1;
            _PlayerName = name;
        }
    }


}

