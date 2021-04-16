using System;
using System.Text.Json;

[Serializable]
public class FlowerData 
{
    public bool _IsCollected { get; set; }

    public int _Id { get; set; }

    public FlowerData(Flower flower) {
        _IsCollected = flower._isCollected;
    }

    public FlowerData()
    {
        _IsCollected = false;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

}
