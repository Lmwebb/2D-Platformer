using Godot;
using System;
using System.Collections.Generic;

public partial class level_select : Control
{
	private List<Node> levels;
	private TextureRect _PlayerIcon;
	
	public int current_level = 1;
	public Node _ParentWorldSelect;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		levels = new List<Node>();
		_PlayerIcon = GetNode<TextureRect>("PlayerIcon");
		
		// Ensures the required node type is assigned
		foreach (Node child in GetChildren()) {
			if (!(child is TextureRect)) {
				levels.Add(child);
				
			}
		}
		
		// Places the player icon at the current level selected
		_PlayerIcon.GlobalPosition = ((Control)levels[current_level]).GlobalPosition;
	}
	
	public void _input(InputEvent @event) {
		
		// Moves the player between levels
		if (Input.IsActionPressed("ui_left") && current_level > 0) {
			current_level -= 1;
			_PlayerIcon.GlobalPosition = ((Control)levels[current_level]).GlobalPosition;
		}
		
		if (Input.IsActionPressed("ui_right") && current_level < levels.Count - 1) {
			current_level += 1;
			_PlayerIcon.GlobalPosition = ((Control)levels[current_level]).GlobalPosition;
		}
		
		// Returns to world select scene
		if (Input.IsActionPressed("ui_cancel")) {
			GetTree().ChangeSceneToFile("res://scene/world_select/world_select.tscn");
		}
		
		// Access the chosen level
		if (Input.IsActionPressed("ui_enter")) {
			if (current_level == 1) {
				GetTree().ChangeSceneToFile("res://scene/game.tscn");
			}
			if (current_level == 2) {
				GetTree().ChangeSceneToFile("res://scene/levels/level_2.tscn");
			}
			
			if (current_level == 3) {
				GetTree().ChangeSceneToFile("res://scene/levels/level_3.tscn");
			}
		}
		
	}
	
}
