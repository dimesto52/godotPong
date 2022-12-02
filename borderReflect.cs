using Godot;
using System;

public class borderReflect : Area2D
{
    [Export]
    Vector2 normal = Vector2.Up;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void _on_area_entered(Area2D area)
    {

        if(area.GetParent() is ballMove)
        {
            ballMove bm = ((ballMove)area.GetParent());

            bm.direction=bm.direction.Bounce(normal);

            rumbleManager.b_data.Invoke(new bumpData((Vector2)(-normal)*2.0f, 25.0f, 0.5f));
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
