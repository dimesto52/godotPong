using Godot;
using System;


public class padMove : Node2D
{
	
	[Export]
	public sidePad side = 0;
	[Export]
	public float speed = 20;

	    Camera2D cam;
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        Vector2 sizeScreen = GetViewportRect().Size;
        cam = get_CurrentCamera2D();
        Vector2 factor = cam.Zoom;

		if(side == sidePad.left)
			Position =  Vector2.Left * sizeScreen.x/2.0f*factor.x * 0.9f;
		else 
			Position =  Vector2.Right * sizeScreen.x/2.0f*factor.x * 0.9f;


	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	 public override void _Process(float delta)
	 {

		
        Vector2 sizeScreen = GetViewportRect().Size;
        Vector2 factor = cam.Zoom;
        Vector2 d = Vector2.Zero;
		
		if(side == sidePad.left)
			d =  Vector2.Left;
		else 
			d =  Vector2.Right;
		
		Position = new Vector2(0, Position.y);

		if(side == sidePad.left)
			Position +=  Vector2.Left * sizeScreen.x/2.0f*factor.x * 0.9f;
		else 
			Position +=  Vector2.Right * sizeScreen.x/2.0f*factor.x * 0.9f;

		//if(!Engine.EditorHint)
		if(
			(side == sidePad.left && Input.GetActionStrength("j1Up") > 0) ||
			(side == sidePad.right && Input.GetActionStrength("j2Up") > 0) )
		{
			if(Position.y < sizeScreen.y/2.0f*factor.y)
			Position += new Vector2(0, -delta*speed);
		}
		if(
			(side == sidePad.left && Input.GetActionStrength("j1Down") > 0) ||
			(side == sidePad.right && Input.GetActionStrength("j2Down") > 0) )
		{
			if(Position.y > -sizeScreen.y/2.0f*factor.y)
			Position += new Vector2(0, delta*speed);
		}
	 }
    Camera2D get_CurrentCamera2D()
    {
            Viewport view = GetViewport();
            if (view == null) return null;

            string camerasGroupName = "__cameras_" + view.GetViewportRid().GetId();

            var cameras = this.GetTree().GetNodesInGroup(camerasGroupName);
            foreach( Node camera in cameras)
                if( camera is Camera2D)
                if( ((Camera2D)camera).Current) 
                    return ((Camera2D)camera);

            return null;
    }
}

public enum sidePad
{
	left,right
}
