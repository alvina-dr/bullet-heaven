using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player _player;
    public Vector3 Direction;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _mesh;

    private void Update()
    {
        _player.CharacterController.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime);
        _player.CharacterController.Move(Direction * _moveSpeed * Time.deltaTime);

        if (Direction != Vector3.zero)
        {
            _mesh.transform.forward = Vector3.RotateTowards(_mesh.transform.forward, Direction, 10 * Time.deltaTime, 0);
        }
    }
}
