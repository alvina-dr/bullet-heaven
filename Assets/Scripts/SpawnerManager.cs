using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public List<EnemyData> EnemyDataList = new();
    [SerializeField] private float _spawnRadius;

    private void Awake()
    {
        EnemyDataList.Clear();
        EnemyDataList = Resources.LoadAll<EnemyData>("Enemies/").ToList();

        for (int i = 0; i < EnemyDataList.Count; i++)
        {
            StartCoroutine(SpawnTimer(EnemyDataList[i]));
        }
    }

    public IEnumerator SpawnTimer(EnemyData data)
    {
        yield return new WaitForSeconds(data.SpawnFrequency);
        SpawnEnemy(data.EnemyPrefab);
        StartCoroutine(SpawnTimer(data));
    }

    public void SpawnEnemy(Enemy _enemyPrefab)
    {
        Enemy _enemy = Instantiate(_enemyPrefab);
        float _angle = Random.Range(0f, 2.0f * Mathf.PI);
        Vector3 pos = new Vector3((_spawnRadius) * Mathf.Cos(_angle), 1, (_spawnRadius) * Mathf.Sin(_angle)) + new Vector3(GameManager.Instance.Player.transform.position.x, 0, GameManager.Instance.Player.transform.position.z);
        _enemy.transform.position = pos;
        //_enemy.Rigidbody.enabled = true;
    }
}
