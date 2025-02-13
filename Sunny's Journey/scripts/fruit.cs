using Godot;
using System;

public partial class fruit : Area2D
{
	
	[Signal]
	public delegate void FruitCollectedEventHandler();
	
	private void _on_body_entered(Node2D body)
	{
		GD.Print("+1 Fruit");
		EmitSignal(nameof(FruitCollected));
		QueueFree();
		
	}
	
}
