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
    }

    public void SetFlower(Collectible flower)
    {
        _SaveData._Flower = new CollectibleData(flower);
    }

    public void SetPlayer(Player player)
    {
        _SaveData._Player = new PlayerData(player.gameObject.transform.position);
    }

    public void SetLevelData(int levelNumber, int itemsCollected, bool isDoorOpen, Collectible[] collectibles)
    {
        _SaveData._LevelData = new LevelData(levelNumber, itemsCollected, isDoorOpen, collectibles);
    }

    public void SetNextLevel(int level)
    {
        _SaveData._LevelData = new LevelData();
        _SaveData._LevelData._LevelNumber = level;
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
        }
        else
        {
            data = new SaveData();
        }
        return data;
    }

    public void NewSaveFile()
    {
        _SaveData = new SaveData();
    }

    public bool IsExist()
    {
        return File.Exists(_SaveFileName);
    }

    public void Delete()
    {
        if (IsExist())
            File.Delete(_SaveFileName);
    }

    public PlayerData GetPlayer()
    {
        return _SaveData._Player;
    }

    public LevelData GetLevelData()
    {
        return _SaveData._LevelData;
    }

    public CollectibleData GetCollectibleDataById(int id)
    {
        try
        {
            CollectibleData data = _SaveData._LevelData._Collectibles[id];
            return data;
        }
        catch
        {
            return new CollectibleData();
        }
    }

    [Serializable]
    public class SaveData
    {
        public LevelData _LevelData { get; set; }
        public string _SaveTime { get; set; }
        public CollectibleData _Flower { get; set; }
        public PlayerData _Player { get; set; }

        public SaveData()
        {
            this._Flower = new CollectibleData();
            this._Player = new PlayerData();
            this._LevelData = new LevelData();
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
