using System;
using UnityEngine;
using System.Text.Json;

[Serializable]
public class PlayerData
{
    [Serializable]
    public class PlayerPosition
    {
        public float x { get; set; }
        public float y { get; set; }

        public PlayerPosition(Vector3 position)
        {
            this.x = position.x;
            this.y = position.y;
        }

        public PlayerPosition()
        {
            this.x = 0;
            this.y = 0;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public PlayerPosition _Position { get; set; }

    public PlayerData(Vector3 position)
    {
        this._Position = new PlayerPosition(position);
    }

    public PlayerData()
    {
        this._Position = new PlayerPosition();
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
