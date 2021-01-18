using Godot;
using System;

public class Player : TemplateCharacter
{
    Vector2 motion = new Vector2();
    Light2D Torch;

    public override void _Ready()
    {
        base._Ready();
        Torch = GetNode<Light2D>("Torch");
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);

        UpdateMovement(delta);
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        ToggleTorch();
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

    void ToggleTorch()
    {
        if (Input.IsActionJustReleased("torch"))
        {
            Torch.Enabled = !Torch.Enabled;
        }
    }
}
