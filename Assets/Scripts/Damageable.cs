using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Damageable : MonoBehaviour
{
    public int Health;
    public UnityEvent OnDamage;
    public UnityEvent OnDie;
    public Transform MeshTransform;

    public void Damage(int damage)
    {
        OnDamage?.Invoke();
        Health -= damage;

        GameManager.Instance.UIManager.TextPopperManager.PopText(damage.ToString(), Camera.main.WorldToScreenPoint(transform.position));

        Sequence damageSequence = DOTween.Sequence();
        damageSequence.Append(MeshTransform.DOScale(1.4f, .1f));
        damageSequence.Append(MeshTransform.DOScale(1f, .04f));
        damageSequence.AppendCallback(() =>
        {
            if (Health <= 0)
            {
                Die();
            }
        });
        damageSequence.Play();
    }

    public void Die()
    {
        OnDie?.Invoke();
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
