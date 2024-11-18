using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class CharacterInput : MonoBehaviour
{
    [SerializeField] public Vector2 MoveInput;
    public bool Dodge = false;
    public bool AttackStance = false;
    public bool Jump = false;
    public bool Guard = false;

    private void OnMove(InputValue value)
    {
        MoveInput = value.Get<Vector2>();
    }

    private void OnDodge(InputValue value)
    {
        Dodge = true;
    }

    private void OnAttackStance(InputValue value)
    {
        AttackStance = true;
    }

    private void OnJumpAndGuard(InputValue value)
    {
        if (AttackStance == true)
        {
            Guard = true;
        }
        else if (AttackStance == false)
        {
            Jump = true;
        }
    }
}
