using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveFile : Singleton<SaveFile>
{
    private readonly string _FILEPATH = "./data/";
    private string _SaveFileName;
    public SaveData _SaveData;
    private JsonSerializerOptions options;
    public static List<SaveData> savedGames = new List<SaveData>();

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _SaveFileName = _FILEPATH + "/save.gd";
        _SaveData = Read();
        print(_SaveData.ToString());
    }

    public void SetFlower (Flower flower)
    {
        _SaveData._Flower = new FlowerData(flower);
    }

    public void SetPlayer(Player player)
    {
        _SaveData._Player = new PlayerData(player.gameObject.transform.position);
    }

    public void Save()
    {
        _SaveData._SaveTime = DateTime.Now.ToString("dd-MM-yyyy H:mm");
        if (!Directory.Exists(_FILEPATH))
        {
            Directory.CreateDirectory(_FILEPATH);
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Create(_SaveFileName, (int)FileMode.Create);
        formatter.Serialize(stream, _SaveData);
        stream.Close();
        print("Save: " + _SaveData.ToString());
    }

    public SaveData Read()
    {
        SaveData data;
        
        if (File.Exists(_SaveFileName))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_SaveFileName, FileMode.Open);
            data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            print("Load save data: \n" + data.ToString());
            
        } else
        {
            print("creating save data...");
            data = new SaveData("Player 1");
        }
        return data;
    }

    public FlowerData GetFlower()
    {
        return Read()._Flower;
    }

    public PlayerData GetPlayer()
    {
        return Read()._Player;
    }

    [Serializable]
    public class SaveData
    {
        public string _PlayerName { get; set; }

        public int _Level { get; set; }

        public string _SaveTime { get; set; }

        public FlowerData _Flower { get; set; }

        public PlayerData _Player { get; set; }

        public SaveData(string _PlayerName)
        {
            this._Level = 0;
            this._PlayerName = _PlayerName;
            this._Flower = new FlowerData();
            this._Player = new PlayerData();
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

