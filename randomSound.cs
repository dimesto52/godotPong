using Godot;
using System;

public class randomSound : Resource
{
    [Export]
    public AudioStream[] audios;

    AudioStream getrandom()
    {
        RandomNumberGenerator rnd = new RandomNumberGenerator();
        rnd.Randomize();
        
        return audios[rnd.RandiRange(0, audios.Length-1)];
    }

    public void playSound( Node  node)
    {
        AudioStreamPlayer2D audioplayer = new AudioStreamPlayer2D();
        audioplayer.Stream = getrandom();
        audioplayer.Play();

        node.GetTree().Root.AddChild(audioplayer);

    }
}
