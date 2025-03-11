using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void OnMove(InputValue callbackContext)
    {
        _player.PlayerMovement.Direction = new Vector3(callbackContext.Get<Vector2>().normalized.x, 0, callbackContext.Get<Vector2>().normalized.y);
    }
}
