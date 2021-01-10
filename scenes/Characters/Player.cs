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

        UpdateMovement();

        motion.x = Mathf.Lerp(motion.x, 0, FRICTION);
        motion.y = Mathf.Lerp(motion.y, 0, FRICTION);

        MoveAndCollide(motion.Normalized() * SPEED * delta);
    }

    void UpdateMovement()
    {
        LookAt(GetGlobalMousePosition());
        motion.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        motion.y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
    }
}
