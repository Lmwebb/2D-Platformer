using Godot;
using System;

public partial class game_manager : Node
{
	
	public int score = 0;
	private Label _ScoreLabel;
	
	public override void _Ready()
	{
		_ScoreLabel = GetNode<Label>("ScoreLabel");
		
	}
	
	public void add_point() {
		score += 1;
		_ScoreLabel.Text = "You collected " + score + " coins.";
	}
}

