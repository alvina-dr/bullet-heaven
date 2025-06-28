using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerShootUpDown : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _frequency;
    private float _timer;
    private bool _shootUp = false;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _frequency)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        _timer = 0;
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.Setup(_shootUp ? Vector3.forward : -Vector3.forward);
        _shootUp = !_shootUp;
    }
}
