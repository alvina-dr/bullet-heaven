using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;
    public EnemyData Data;
    private Vector3 _wanderDirection;

    public void Move()
    {
        if (Vector3.Distance(GameManager.Instance.Player.transform.position, transform.position) <= Data.SightDistance)
        {
            Vector3 _moveDirection = (GameManager.Instance.Player.transform.position - transform.position).normalized;
            _characterController.Move(new Vector3(_moveDirection.x, _characterController.velocity.y, _moveDirection.z) * Data.WalkSpeed);
        }
        else
        {
            Wander();
        }
    }

    public void Wander()
    {
        _characterController.Move(new Vector3(_wanderDirection.x, _characterController.velocity.y, _wanderDirection.z) * Data.WalkSpeed);
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
}
