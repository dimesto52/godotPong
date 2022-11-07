using Godot;
using System;

public class ballMove : Node2D
{

    [Export]
    public Vector2 direction;
    [Export]
    private float speed = 20.0f;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Position = Vector2.Zero;

        RandomNumberGenerator rnd = new RandomNumberGenerator();

        direction = new Vector2(rnd.RandfRange(-1.0f,1.0f),0).Normalized();

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
      Position += direction * delta * speed;
  }
}
