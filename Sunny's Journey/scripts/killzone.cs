using Godot;
using System;


public partial class killzone : Area2D
{
	
	private Timer _timer;
	
	public override void _Ready()
	{
		_timer = GetNode<Timer>("Timer");
	}
	
	private void _on_body_entered(Node2D body)
	{
		GD.Print("You died");
		Engine.TimeScale = 0.5;
		body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
		_timer.Start();
	}
	
	private void _on_timer_timeout()
	{
		Engine.TimeScale = 1;
		GetTree().ReloadCurrentScene();
	}
}



