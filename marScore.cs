using Godot;
using System;

public class marScore : Node
{
    [Export]
    sideScore side = 0;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
    public void _area_entered(Area2D area)
    {
        if(area.GetParent() is ballMove)
        {
            ballMove bm = (ballMove)area.GetParent();

            if(side == sideScore.left)
                Score.instance.addLeft();
            if(side == sideScore.right)
                Score.instance.addRight();


            bm.reset();
            rumbleManager.r_data.Invoke(new rumbleData(5f, 0.2f));

        }

    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
