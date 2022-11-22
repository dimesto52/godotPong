using Godot;
using System;

[Tool]
public class borderAdapt : CollisionShape2D
{
    [Export]
    borderSide side = 0;
    Camera2D cam;
    Vector2 prevZoom = Vector2.Zero;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    void refreshPos()
    {
        Vector2 sizeScreen = GetViewportRect().Size;
        cam = get_CurrentCamera2D();
        Vector2 factor = cam.Zoom;

        prevZoom = cam.Zoom;

        switch(this.side)
        {
            case borderSide.top:
            if(GetParent() is Area2D)
                ((Area2D)GetParent()).Position = new Vector2(0, -sizeScreen.y/2.0f*factor.y-20.0f); 
            ((RectangleShape2D)Shape).Extents = new Vector2(sizeScreen.x /2.0f*factor.x, 20);
            break;
            case borderSide.bot:
            if(GetParent() is Area2D)
                ((Area2D)GetParent()).Position = new Vector2(0, sizeScreen.y/2.0f*factor.y+20.0f); 
            ((RectangleShape2D)Shape).Extents = new Vector2(sizeScreen.x /2.0f*factor.x, 20);
            break;
            case borderSide.left:
            if(GetParent() is Area2D)
                ((Area2D)GetParent()).Position = new Vector2(-sizeScreen.x/2.0f*factor.x-20.0f, 0); 
            ((RectangleShape2D)Shape).Extents = new Vector2(20, sizeScreen.y/2.0f*factor.y);
            break;
            case borderSide.right:
            if(GetParent() is Area2D)
                ((Area2D)GetParent()).Position = new Vector2(sizeScreen.x/2.0f*factor.x+20.0f, 0); 
            ((RectangleShape2D)Shape).Extents = new Vector2(20, sizeScreen.y/2.0f*factor.y);
            break;
        }
    }


    public override void _Ready()
    {
        refreshPos();
    }

    public override void _Process(float delta)
    {
        if(cam.Zoom != prevZoom)
            refreshPos();
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


public enum borderSide
{
    top,bot,left,right
}
