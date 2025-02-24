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
	
	// Tracks the coins collected
	public void add_point() {
		score += 1;
		_ScoreLabel.Text = "You collected " + score + " coins.";
		end_game();
	}
	
	// Returns to level select once the level is completed
	public void end_game() {
		if (score == 7) {
			GetTree().ChangeSceneToFile("res://scene/level_select/level_select.tscn");
		}
	}
}

