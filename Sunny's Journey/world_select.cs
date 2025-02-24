using Godot;
using System;
using System.Collections.Generic;

public partial class world_select : Control
{
	private List<Node> worlds;
	private TextureRect _PlayerIcon;
	public int current_world = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Creates a list of all world icons
		worlds = new List<Node>();
		_PlayerIcon = GetNode<TextureRect>("PlayerIcon");
		
		// Ensures all nodes added to the list are the required type
		foreach (Node child in GetChildren()) {
			if (!(child is TextureRect) && !(child is TileMap)) {
				worlds.Add(child);
				
			}
		}
		
		// Assigns the Player icons position to the current world chosen
		_PlayerIcon.GlobalPosition = ((Control)worlds[current_world]).GlobalPosition;
		
	}
	
	public void _input(InputEvent @event) {
		// Shifts the player icon depending on user input
		if (Input.IsActionPressed("ui_left") && current_world > 0) {
			current_world -= 1;
			_PlayerIcon.GlobalPosition = ((Control)worlds[current_world]).GlobalPosition;
		}
		
		if (Input.IsActionPressed("ui_right") && current_world < worlds.Count - 1) {
			current_world += 1;
			_PlayerIcon.GlobalPosition = ((Control)worlds[current_world]).GlobalPosition;
		}
		
		// Enters the scene selected
		if (Input.IsActionPressed("ui_enter")) {
			
			if (current_world == 0) {
				
				GetTree().ChangeSceneToFile("res://scene/level_select/level_select.tscn");
				
			}
			if (current_world == 1) {
				
				GetTree().ChangeSceneToFile("res://scene/levels/place_holder.tscn");
				
			}
			if (current_world == 2) {
				
				GetTree().ChangeSceneToFile("res://scene/levels/place_holder.tscn");
				
			}
			
		}
	}
}
