using Godot;
using System;

public partial class fruit : Area2D
{
	
	[Signal]
	public delegate void FruitCollectedEventHandler();
	
	private Timer respawnTimer;
	
	public override void _Ready() {
		respawnTimer = GetNode<Timer>("Timer");
		respawnTimer.Timeout += on_respawn_timeout;
	}
	
	private void _on_body_entered(Node2D body)
	{
		GD.Print("+1 Fruit");
		EmitSignal(nameof(FruitCollected));
		Hide();
		respawnTimer.Start();
	}
	
	private void on_respawn_timeout(){
		Show();
	}
	
}
