using Godot;
using System;

public class rumbleManager : Node
{
    static public System.Action<rumbleData>  r_data = null;
    static public System.Action<bumpData>  b_data = null;

    rumbleData lr_data = null;
    bumpData lb_data = null;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        r_data += updateRData;
        b_data += updateBData;
    }

    // Update is called once per frame
    void updateRData(rumbleData d)
    {
        lr_data = d; 
    }
    void updateBData(bumpData d)
    {
        lb_data?.kill((Node2D)GetParent());
        lb_data = d; 
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (lr_data != null)
        {
            lr_data.Update((Node2D)GetParent());
            lr_data.time -= delta;
            if(lr_data.time<= 0) lr_data = null;
        }
        else if (lb_data != null)
        {
            lb_data.Update((Node2D)GetParent(),delta);
            if (lb_data.direction.Length() <= 0.01f) lr_data = null;
        }
    }

}
public class rumbleData
{
    public float strengh;
    public float time;

    public rumbleData(float strengh,float time)
    {
        this.strengh = strengh;
        this.time = time;

    }

    public void Update(Node2D transform)
    {
        transform.Position = insideUnitCircle() * strengh;
    }
    public  Vector2 insideUnitCircle()
    {
        RandomNumberGenerator rnd = new RandomNumberGenerator();
        rnd.Randomize();
        float theta = rnd.Randf() * 2 * Mathf.Pi;

        return new Vector2(Mathf.Cos(theta),Mathf.Sin(theta));
    }

}
public class bumpData
{
    public Vector2 direction;
    public float speed;
    public float bounce;

    float time;

    public bumpData(Vector2 direction, float speed, float bounce)
    {
        this.direction = direction;
        this.speed = speed;
        this.bounce = bounce;

    }

    public void Update(Node2D transform, float deltaTime)
    {
        if (time >= 0)
        {
            time += deltaTime * speed;

            transform.Position = direction * time;

            if (time >= 1) direction *= bounce;
        }
        else
        {
            time -= deltaTime * speed;

            transform.Position = direction * time;

            if (time <= -1) direction *= bounce;
        }

        if (direction.Length() <= 0.01f) kill(transform);
    }
    public void kill(Node2D transform)
    {
        transform.Position = Vector2.Zero;
    }
}