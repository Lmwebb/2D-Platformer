using Godot;
using System;

[Tool]
public partial class level_icon : Control
{
	[Export]
	public int level_index = 1;
	
	private Label _LevelLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_LevelLabel = GetNode<Label>("Label");
		_LevelLabel.Text = "Level " + level_index;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Engine.IsEditorHint()) {
			_LevelLabel.Text = "Level " + level_index;
		}
	}
}
