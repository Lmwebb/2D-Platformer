using Godot;
using System;

public partial class game_manager : Node
{
	
	public int score = 0;
	
	public void add_point() {
		score += 1;
		GD.Print(score);
	}
}

