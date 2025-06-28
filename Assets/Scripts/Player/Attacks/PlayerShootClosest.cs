using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerShootClosest : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _frequency;
    private float _timer;

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
        List<Enemy> enemyList = FindObjectsOfType<Enemy>().ToList();

        if (enemyList.Count == 0) return;

        //To find closest
        float minDistance = Vector3.Distance(enemyList[0].transform.position, transform.position);
        Enemy enemy = enemyList[0];
        for (int i = 1; i < enemyList.Count; i++)
        {
            float newDistance = Vector3.Distance(enemyList[i].transform.position, transform.position);
            if (newDistance < minDistance)
            {
                minDistance = newDistance;
                enemy = enemyList[i];
            }
        }

        //Shoot at closest
        _timer = 0;
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.Setup((enemy.transform.position - transform.position).normalized);
    }
}
