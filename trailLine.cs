using Godot;
using System;

public class trailLine : Line2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    [Export]
    NodePath nodeTarget;

    Node2D target;

    public override void _Ready()
    {
        AddPoint(new Vector2(0,0));

        target = (Node2D)GetNode(nodeTarget);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        AddPoint(target.Position);


        if(Points.Length > 50)
            RemovePoint(0);

    }
}
