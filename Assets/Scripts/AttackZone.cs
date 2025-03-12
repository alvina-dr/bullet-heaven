using System.Collections;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public float Duration;

    public void Setup()
    {
        StartCoroutine(DestroyZone());
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
            enemy.Damageable.Damage(1);
        }
    }
}
