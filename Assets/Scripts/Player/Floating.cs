using UnityEngine;
using DG.Tweening;

public class Floating : MonoBehaviour
{
    void Start()
    {
        transform.DOLocalMoveY(transform.localPosition.y + .4f, .7f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
