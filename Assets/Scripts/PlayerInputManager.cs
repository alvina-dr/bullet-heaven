using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public Vector3 Direction;
    public CharacterController CharacterController;
    [SerializeField]
    private float _moveSpeed;

    public void OnMove(InputValue callbackContext)
    {
        Direction = new Vector3(callbackContext.Get<Vector2>().normalized.x, 0, callbackContext.Get<Vector2>().normalized.y);
    }

    private void FixedUpdate()
    {
        CharacterController.Move(Direction * _moveSpeed);
    }
}
