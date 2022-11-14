using Godot;
using System;

public class Score 
{
    int left = 0;
    int right = 0;

    public System.Action<int> changeLeft;
    public System.Action<int> changeRight;

    public void addLeft()
    {
        left ++;
        changeLeft.Invoke(left);
    }
    public void addRight()
    {
        right ++;
        changeRight.Invoke(right);
    }

    public static Score instance = new Score();

}

public enum sideScore
{
    left,right
}
