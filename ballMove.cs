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
        reset();

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
      Position += direction * delta * speed;
  }

public void reset()
{

        Position = Vector2.Zero;

        RandomNumberGenerator rnd = new RandomNumberGenerator();
        rnd.Randomize();

        direction = new Vector2(rnd.RandfRange(-1.0f,1.0f),rnd.RandfRange(-1.0f,1.0f)).Normalized();
}

}
