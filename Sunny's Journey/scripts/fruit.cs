using Godot;
using System;

public partial class fruit : Area2D
{
	
	[Signal]
	public delegate void FruitCollectedEventHandler();
	
	public CollisionShape2D collision;
	private Timer respawnTimer;
	
	public override void _Ready() {
		respawnTimer = GetNode<Timer>("Timer");
		collision = GetNode<CollisionShape2D>("CollisionShape2D");
		respawnTimer.Timeout += on_respawn_timeout;
	}
	
	// Check if the fruit has been pick up
	private void _on_body_entered(Node2D body)
	{
		
		GD.Print("+1 Fruit");
		EmitSignal(nameof(FruitCollected));
		Hide();
		respawnTimer.Start();
	}
	
	// Respawns fruit
	private void on_respawn_timeout(){
		Show();
	}
	
}
