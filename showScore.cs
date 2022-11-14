using Godot;
using System;

public class showScore : RichTextLabel
{
    [Export]
    sideScore side = 0;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        if(side == sideScore.left)
            {
                Score.instance.changeLeft += change;
                Score.instance.changeRight -= change;
            }
            else
            {
                
                Score.instance.changeLeft -= change;
                Score.instance.changeRight += change;
            }
    }
    public void change(int i)
    {
        Text = i.ToString();
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
