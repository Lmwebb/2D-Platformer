using Godot;
using System;
using System.Collections.Generic;

public partial class level_select : Control
{
	private List<Node> levels;
	private TextureRect _PlayerIcon;
	public int current_level = 0;
	public Node _ParentWorldSelect;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		levels = new List<Node>();
		_PlayerIcon = GetNode<TextureRect>("PlayerIcon");
		
		foreach (Node child in GetChildren()) {
			if (!(child is TextureRect)) {
				levels.Add(child);
				
			}
		}
		
		_PlayerIcon.GlobalPosition = ((Control)levels[current_level]).GlobalPosition;
		
		GD.Print("Total LevelIcons added: " + levels.Count);
		foreach (Node level in levels)
		{
			GD.Print("LevelIcon: " + level.Name); // Print the name of each LevelIcon
		}
	}
	
	public void _input(InputEvent @event) {
		if (Input.IsActionPressed("ui_left") && current_level > 0) {
			current_level -= 1;
			_PlayerIcon.GlobalPosition = ((Control)levels[current_level]).GlobalPosition;
		}
		
		if (Input.IsActionPressed("ui_right") && current_level < levels.Count - 1) {
			current_level += 1;
			_PlayerIcon.GlobalPosition = ((Control)levels[current_level]).GlobalPosition;
		}
		
		if (Input.IsActionPressed("ui_cancel")) {
			GetTree().Root.AddChild(_ParentWorldSelect);
			GetTree().Root.RemoveChild(this);
		}
		
		if (Input.IsActionPressed("ui_accept")) {
			if (current_level == 0) {
				GetTree().ChangeSceneToFile("res://scene/game.tscn");
			}
		}
	}
		
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
