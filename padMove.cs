using Godot;
using System;

public class padMove : Node2D
{
	
	[Export]
	public sidePad side = 0;
	[Export]
	public float speed = 20;
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	 public override void _Process(float delta)
	 {
		if(
			(side == sidePad.left && Input.GetActionStrength("j1Up") > 0) ||
			(side == sidePad.right && Input.GetActionStrength("j2Up") > 0) )
		{
			if(Position.y > -280)
			Position += new Vector2(0, -delta*speed);
		}
		if(
			(side == sidePad.left && Input.GetActionStrength("j1Down") > 0) ||
			(side == sidePad.right && Input.GetActionStrength("j2Down") > 0) )
		{
			if(Position.y < 280)
			Position += new Vector2(0, delta*speed);
		}
	 }
}

public enum sidePad
{
	left,right
}
