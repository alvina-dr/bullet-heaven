using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Custom Components")]
    public PlayerMovement PlayerMovement;
    public PlayerInputManager PlayerInputManager;
    public Damageable Damageable;
    public PlayerScore PlayerScore;

    [Header("Components")]
    public CharacterController CharacterController;
    public Material OriginalMaterial;
    public MeshRenderer MeshRenderer;

    public void DamageFeedback()
    {
        MeshRenderer.material = GameManager.Instance.DamageMaterial;
        DOVirtual.DelayedCall(.1f, () =>
        {
            MeshRenderer.material = OriginalMaterial;
        });

        GameManager.Instance.CinemachineShake.ShakeCamera(2, .1f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            Damageable.Damage(enemy.Data.Damage);
        }
    }
}
