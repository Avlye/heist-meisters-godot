using Godot;
using System;

public class Player : TemplateCharacter
{
    Vector2 motion = new Vector2();

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);

        UpdateMovement(delta);
    }

    void UpdateMovement(float delta)
    {
        LookAt(GetGlobalMousePosition());

        motion = new Vector2(
            Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left"),
            Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up")
        )
        .LinearInterpolate(Vector2.Zero, FRICTION)
        .Normalized();

        MoveAndCollide(motion * SPEED * delta);
    }
}
