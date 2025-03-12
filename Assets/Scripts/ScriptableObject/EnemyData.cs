using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public Enemy EnemyPrefab;
    public float WalkSpeed;
    public float SightDistance;
    public int Damage;
    public float SpawnFrequency;
    public int PointsGained;
}
