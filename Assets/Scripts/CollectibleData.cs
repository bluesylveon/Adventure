using System;
using System.Text.Json;

[Serializable]
public class CollectibleData
{
    public bool _IsCollected { get; set; }

    public int _Id { get; set; }

    public CollectibleData(Collectible collectible)
    {
        _IsCollected = collectible._isCollected;
        _Id = collectible._id;
    }

    public CollectibleData()
    {
        _IsCollected = false;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
