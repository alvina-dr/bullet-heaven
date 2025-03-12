using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public CharacterController CharacterController;
    public EnemyData Data;
    private Vector3 _wanderDirection;
    public Damageable Damageable;

    public void Move()
    {
        if (Vector3.Distance(GameManager.Instance.Player.transform.position, transform.position) <= Data.SightDistance)
        {
            Vector3 _moveDirection = (GameManager.Instance.Player.transform.position - transform.position).normalized;
            CharacterController.Move(new Vector3(_moveDirection.x, CharacterController.velocity.y, _moveDirection.z) * Data.WalkSpeed);
        }
        else
        {
            Wander();
        }
    }

    public void Wander()
    {
        CharacterController.Move(new Vector3(_wanderDirection.x, CharacterController.velocity.y, _wanderDirection.z) * Data.WalkSpeed);
    }

    private void Start()
    {
        StartCoroutine(ChooseDirection());
    }

    private void FixedUpdate()
    {
        Move();
    }

    IEnumerator ChooseDirection()
    {
        _wanderDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
        yield return new WaitForSeconds(Random.Range(0.5f, 5));
        StartCoroutine(ChooseDirection());
    }

    public void Die()
    {
        Drop drop = Instantiate(GameManager.Instance.DropPrefab);
        drop.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        drop.Score = Data.PointsGained;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
