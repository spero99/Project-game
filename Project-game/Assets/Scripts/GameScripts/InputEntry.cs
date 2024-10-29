using System;

[Serializable]
public class InputEntry
{//OBSOLETE NOT IN USE
    public string playerName;
    public int points;

    public InputEntry(string name, int points)
    {
        playerName = name;
        this.points = points;
    }
}