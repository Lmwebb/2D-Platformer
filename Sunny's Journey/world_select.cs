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
		worlds = new List<Node>();
		_PlayerIcon = GetNode<TextureRect>("PlayerIcon");
		
		foreach (Node child in GetChildren()) {
			if (!(child is TextureRect)) {
				worlds.Add(child);
				
			}
		}
		
		_PlayerIcon.GlobalPosition = ((Control)worlds[current_world]).GlobalPosition;
		
		GD.Print("Total WorldIcons added: " + worlds.Count);
		foreach (Node world in worlds)
		{
			GD.Print("WorldIcon: " + world.Name); // Print the name of each WorldIcon
		}
	}
	
	public void _input(InputEvent @event) {
		if (Input.IsActionPressed("ui_left") && current_world > 0) {
			current_world -= 1;
			_PlayerIcon.GlobalPosition = ((Control)worlds[current_world]).GlobalPosition;
		}
		
		if (Input.IsActionPressed("ui_right") && current_world < worlds.Count - 1) {
			current_world += 1;
			_PlayerIcon.GlobalPosition = ((Control)worlds[current_world]).GlobalPosition;
		}
	}
		
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	
}
