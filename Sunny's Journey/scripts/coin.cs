using Godot;
using System;

public partial class coin : Area2D
{
	private game_manager _GameManager;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_GameManager = GetNode<game_manager>("%GameManager");
	}
	
	
	public void _on_body_entered(Node2D body)
	{
		_GameManager.add_point();
		QueueFree();
	}
	
}

