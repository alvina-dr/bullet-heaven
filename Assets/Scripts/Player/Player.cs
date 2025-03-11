using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Custom Components")]
    public PlayerMovement PlayerMovement;
    public PlayerInputManager PlayerInputManager;


    [Header("Components")]
    public CharacterController CharacterController;
}
