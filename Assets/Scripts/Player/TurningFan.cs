using UnityEngine;
using DG.Tweening;

public class TurningFan : MonoBehaviour
{
    void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), .5f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }


}
