using Godot;
using System;

public partial class slime : Node2D
{
	public const float Speed = 20;
	public int Direction = 1;
	
	private RayCast2D _RayRight;
	private RayCast2D _RayLeft;
	private AnimatedSprite2D _AnimatedSprite;
	
	public override void _Ready() {
		
		_RayRight = GetNode<RayCast2D>("RayCastRight");
		_RayLeft = GetNode<RayCast2D>("RayCastLeft");
		_AnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Checks RayCast for desired direction
		if (_RayRight.IsColliding()) {
			Direction = -1;
			_AnimatedSprite.FlipH = true;
		} 
		
		if (_RayLeft.IsColliding()) {
			Direction = 1;
			_AnimatedSprite.FlipH = false;
		}
	
		// Moves the Slime based on RayCast
		Position += new Vector2((float)(Direction * Speed * delta), 0);
		
	}
}
