using System;
using System.Text.Json;

[Serializable]
public class LevelData
{
    public int _LevelNumber { get; set; }
    public int _ItemsCollected { get; set; }
    public bool _IsDoorOpen { get; set; }
    public CollectibleData[] _Collectibles { get; set; }

    public LevelData(int levelNumber, int itemsCollected, bool isDoorOpen, Collectible[] collectibles)
    {
        this._LevelNumber = levelNumber;
        this._ItemsCollected = itemsCollected;
        this._IsDoorOpen = isDoorOpen;
        this.SetCollectibles(collectibles);
    }

    public LevelData()
    {
        this._LevelNumber = 0;
        this._ItemsCollected = 0;
        this._IsDoorOpen = false;
        this._Collectibles = new CollectibleData[0];
    }

    private void SetCollectibles(Collectible[] collectibles)
    {
        this._Collectibles = new CollectibleData[collectibles.Length];
        for (int i = 0; i < collectibles.Length; i++)
            this._Collectibles[i] = new CollectibleData(collectibles[i]);
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
