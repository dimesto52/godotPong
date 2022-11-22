using Godot;
using System;

[Tool]
public class camAdapt : Camera2D
{
    
        Vector2 basesizeScreen = Vector2.Zero;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        if(Zoom == Vector2.One)
            basesizeScreen = GetViewportRect().Size;
        size_changed();

        GetTree().GetRoot().Connect("size_changed",this,"size_changed");
    }

    public void size_changed()
    {
        
        Vector2 sizeScreen = GetViewportRect().Size;


        Position = Vector2.Zero;

        Zoom = new Vector2(sizeScreen.x/basesizeScreen.x, sizeScreen.y/basesizeScreen.y);

        //GD.Print(Zoom);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
