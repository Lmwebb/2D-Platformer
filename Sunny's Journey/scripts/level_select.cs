using Godot;
using System;
using System.Collections.Generic;

public partial class level_select : Control
{
	private TextureRect _PlayerIcon;
	public level_icon _CurrentLevel;
	public int current_world = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_PlayerIcon = GetNode<TextureRect>("PlayerIcon");
		_CurrentLevel = GetNode<level_icon>(level_name);
		_PlayerIcon.GlobalPosition = _CurrentLevel.GlobalPosition;
		
	}
	
	public void _input(InputEvent @event) {
		if (Input.IsActionPressed("ui_left") && _CurrentLevel._NextLevelLeft != null) {
			_CurrentLevel = _CurrentLevel._NextLevelLeft as level_icon;
			_PlayerIcon.GlobalPosition = _CurrentLevel.GlobalPosition;
		}
		
		if (Input.IsActionPressed("ui_right") && _CurrentLevel._NextLevelRight != null) {
			_CurrentLevel =  _CurrentLevel._NextLevelRight as level_icon;
			_PlayerIcon.GlobalPosition = _CurrentLevel.GlobalPosition;
		}
		
		if (Input.IsActionPressed("ui_up") && _CurrentLevel._NextLevelUp != null) {
			_CurrentLevel = _CurrentLevel._NextLevelUp as level_icon;
			_PlayerIcon.GlobalPosition = _CurrentLevel.GlobalPosition;
		}
		
		if (Input.IsActionPressed("ui_down") && _CurrentLevel._NextLevelDown != null) {
			_CurrentLevel = _CurrentLevel._NextLevelDown as level_icon;
			_PlayerIcon.GlobalPosition = _CurrentLevel.GlobalPosition;
		}
	}
		
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
