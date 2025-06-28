using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    [SerializeField] private Rigidbody _rigibody;
    private Vector3 _direction;
    [SerializeField] private float _speed;

    public void Setup(Vector3 direction)
    {
        StartCoroutine(DestroyBullet());
        _direction = direction;
        transform.forward = direction;
    }

    private void FixedUpdate()
    {
        _rigibody.linearVelocity = _direction * _speed;
    }

    public IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.Damageable.Damage(Damage);
            Destroy(gameObject);
        }
    }
}
