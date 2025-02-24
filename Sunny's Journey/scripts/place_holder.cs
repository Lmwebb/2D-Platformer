using Godot;
using System;

public partial class place_holder : Node2D
{
	
	// Returns the user to the world select scene
	public void _input(InputEvent @event) {
		if (Input.IsActionPressed("ui_cancel")) {
			GetTree().ChangeSceneToFile("res://scene/world_select/world_select.tscn");
		}
	}
}
