using DG.Tweening;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public int Score;
    private Player _player;

    private void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        transform.DOMoveY(transform.position.y + .2f, 3).SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {
        if (_player == null) return;
        
        transform.position = Vector3.Lerp(transform.position, _player.transform.position, Time.deltaTime * 3);
        if (Vector3.Distance(transform.position, _player.transform.position) < 2)
        {
            _player.PlayerScore.AddScore(Score);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _player = player;
        }
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
