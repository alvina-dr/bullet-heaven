using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowingZones : MonoBehaviour
{
    public float Frequency;
    private float _timer;
    [SerializeField] private AttackZone _attackZonePrefab;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > Frequency)
        {
            SpawnAttackZone();
            _timer = 0;
        }
    }

    public void SpawnAttackZone()
    {
        AttackZone zone = Instantiate(_attackZonePrefab);
        zone.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        zone.Setup();
    }
}
