
using System;

[Serializable]
public class HighscoreElement 
{   //OBSOLETE NOT IN USE 
    public string playerName;
    public int points;

    public HighscoreElement(string name, int points)
    {
        playerName = name;
        this.points = points;
    }
}
