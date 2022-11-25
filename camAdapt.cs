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

        //GD.Print(sizeScreen);
        //GD.Print(basesizeScreen);

        Position = Vector2.Zero;

        float X = basesizeScreen.x/sizeScreen.x;
        float Y = basesizeScreen.y/sizeScreen.y;
        //GD.Print(X);
        //GD.Print(Y);
        
        Zoom = new Vector2(X, Y);

        //GD.Print(Zoom);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
