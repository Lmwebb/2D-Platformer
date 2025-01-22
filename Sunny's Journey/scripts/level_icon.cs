using Godot;
using System;

[Tool]
public partial class level_icon : Control
{
	[Export]
	public string level_name = "1";
	
	[Export]
	public Control _NextLevelUp;
	
	[Export]
	public Control _NextLevelDown;
	
	[Export]
	public Control _NextLevelLeft;
	
	[Export]
	public Control _NextLevelRight;
	
	private Label _LevelLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_NextLevelUp = GetNode<Control>("LevelIcon");
		_NextLevelDown = GetNode<Control>("LevelIcon");
		_NextLevelLeft = GetNode<Control>("LevelIcon");
		_NextLevelRight = GetNode<Control>("LevelIcon");
		_LevelLabel = GetNode<Label>("Label");
		_LevelLabel.Text = "Level " + level_name;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Engine.IsEditorHint()) {
			_LevelLabel.Text = "Level " + level_name;
		}
	}
}
