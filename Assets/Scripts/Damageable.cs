using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Damageable : MonoBehaviour
{
    public int Health;
    public UnityEvent OnDamage;
    public UnityEvent OnDie;

    public void Damage(int damage)
    {
        OnDamage?.Invoke();
        Health -= damage;

        Sequence damageSequence = DOTween.Sequence();
        damageSequence.Append(transform.DOScale(1.4f, .1f));
        damageSequence.Append(transform.DOScale(1f, .04f));
        damageSequence.Play();

        GameManager.Instance.UIManager.TextPopperManager.PopText(damage.ToString(), Camera.main.WorldToScreenPoint(transform.position));

        if (Health <= 0)
        {
            Die();
        }
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
