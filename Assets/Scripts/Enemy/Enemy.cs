using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public EnemyData Data;
    private Vector3 _wanderDirection;
    public Damageable Damageable;
    [SerializeField] private ParticleSystem _deathParticles;
    [SerializeField] private List<MeshRenderer> _meshRendererList = new();
    [SerializeField] private Material _originalMaterial;

    public void Move()
    {
        if (Vector3.Distance(GameManager.Instance.Player.transform.position, transform.position) <= Data.SightDistance)
        {
            Vector3 _moveDirection = (GameManager.Instance.Player.transform.position - transform.position).normalized;
            Rigidbody.linearVelocity = (new Vector3(_moveDirection.x, Rigidbody.linearVelocity.y, _moveDirection.z) * Data.WalkSpeed * Time.deltaTime);
        }
        else
        {
            Rigidbody.linearVelocity = (new Vector3(_wanderDirection.x, Rigidbody.linearVelocity.y, _wanderDirection.z) * Data.WalkSpeed * Time.deltaTime);
        }
    }

    private void Start()
    {
        Damageable.Health = Data.Health;
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

    public void DamageFeedback()
    {
        for (int i = 0; i < _meshRendererList.Count; i++)
        {
            _meshRendererList[i].material = GameManager.Instance.DamageMaterial;
        }
        DOVirtual.DelayedCall(.1f, () =>
        {
            for (int i = 0; i < _meshRendererList.Count; i++)
            {
                _meshRendererList[i].material = _originalMaterial;
            }
        });
    }

    public void Die()
    {
        Drop drop = Instantiate(GameManager.Instance.DropPrefab);
        drop.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        drop.Score = Data.PointsGained;
        _deathParticles.transform.parent = null;
        _deathParticles.gameObject.SetActive(true);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
