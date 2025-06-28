using DG.Tweening;
using System.Collections;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public float Duration;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _blinkMaterial;
    [SerializeField] private Material _normalMaterial;

    public void Setup()
    {
        StartCoroutine(DestroyZone());
        Sequence blinkSequence = DOTween.Sequence();
        blinkSequence.AppendCallback(() =>
        {
            _meshRenderer.material = _blinkMaterial;
            Debug.Log("change material 1");
        });
        blinkSequence.AppendInterval(.5f);
        blinkSequence.AppendCallback(() =>
        {
            _meshRenderer.material = _normalMaterial;
            Debug.Log("change material 2");
        });
        blinkSequence.AppendInterval(.5f);

        blinkSequence.SetLoops(-1, LoopType.Incremental);
        blinkSequence.Play();
    }

    public IEnumerator DestroyZone()
    {
        yield return new WaitForSeconds(Duration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.Damageable.Damage(10);
        }
    }
}
