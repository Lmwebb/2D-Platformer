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
			if (!(child is TextureRect) && !(child is TileMap)) {
				worlds.Add(child);
				
			}
		}
		
		_PlayerIcon.GlobalPosition = ((Control)worlds[current_world]).GlobalPosition;
		
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
		
		if (Input.IsActionPressed("ui_accept")) {
			
			var _WorldIcon = (world_icon)worlds[current_world];
			var _WorldSelectScene = _WorldIcon._LevelSelectScene as level_select;
			_WorldSelectScene._ParentWorldSelect = this;
			
			if (_WorldIcon._LevelSelectScene != null && current_world == 0) {
				
				GetTree().Root.AddChild(_WorldIcon._LevelSelectScene);
				GetTree().CurrentScene = _WorldIcon._LevelSelectScene;
				GetTree().Root.RemoveChild(this);
			}
		}
	}
		
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
