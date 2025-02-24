using Godot;
using System;

[Tool]
public partial class world_icon : Control
{
	[Export]
	public int world_index = 1;
	
	private Label _WorldLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_WorldLabel = GetNode<Label>("Label");
		_WorldLabel.Text = "World " + world_index;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Assigns the appropriate index to worlds
		if (Engine.IsEditorHint()) {
			_WorldLabel.Text = "World " + world_index;
		}
	}
}
