using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player _player;
    public Vector3 Direction;
    [SerializeField] private float _moveSpeed;

    private void FixedUpdate()
    {
        _player.CharacterController.Move(Direction * _moveSpeed);
    }
}
