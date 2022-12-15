using Godot;
using System;

public class padReflect : Area2D
{

    [Export]
    public randomSound sound;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void _on_Area2D_entered(Area2D area)
    {
        if(area.GetParent() is ballMove)
        {

            ballMove bm = (ballMove)area.GetParent();

            bm.direction = (bm.Position - GlobalPosition).Normalized();

            sound?.playSound((Node)this);
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
