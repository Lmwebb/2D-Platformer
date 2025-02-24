using Godot;
using System;

public partial class level_3 : Node2D
{
	// Returns the user to the world select scene
	public void _input(InputEvent @event) {
		if (Input.IsActionPressed("ui_cancel")) {
			GetTree().ChangeSceneToFile("res://scene/level_select/level_select.tscn");
		}
	}
}
