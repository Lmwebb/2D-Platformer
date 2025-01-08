using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 200.0f;
	public const float JumpVelocity = -300.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	
	private AnimatedSprite2D animatedSprite;
	
	public override void _Ready()
	{
		// Get the AnimatedSprite2D node
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handles Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Reads the input of the user 
		Vector2 direction = Input.GetVector("move_left", "move_right", "ui_up", "ui_down");
		
		// Moves character according to movement
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		
		// Plays animations
		if (IsOnFloor()) {
			if (direction.X == 0) {
				animatedSprite.Play("idle");
			} else {
				animatedSprite.Play("run");
			}
		} else {
			animatedSprite.Play("jump");
		}
		
		// Changes sprite direction 
		if (direction.X > 0) {
			animatedSprite.FlipH = false;
		} else if (direction.X < 0) {
			animatedSprite.FlipH = true;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
