using DG.Tweening;
using System.Collections.Generic;
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
    public List<MeshRenderer> MeshRendererList;
    public ParticleSystem LevelUpParticleSystemPrefab;

    public void DamageFeedback()
    {
        for (int i = 0; i < MeshRendererList.Count; i++)
        {
            MeshRendererList[i].material = GameManager.Instance.DamageMaterial;
        }
        DOVirtual.DelayedCall(.1f, () =>
        {
            for (int i = 0; i < MeshRendererList.Count; i++)
            {
                MeshRendererList[i].material = OriginalMaterial;
            }
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
