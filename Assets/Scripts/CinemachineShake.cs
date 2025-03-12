using UnityEngine;
using Unity.Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    [SerializeField, Tooltip("Cinemachine perlin noise")]
    private CinemachineBasicMultiChannelPerlin _perlin;
    private float _timer;

    private void Start()
    {
        StopShake();
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.unscaledDeltaTime;

            if (_timer <= 0) StopShake();
        }
    }

    public void ShakeCamera(float intensity, float time)
    {
        _perlin.AmplitudeGain = intensity;
        _timer = time;
    }

    public void StopShake()
    {
        _perlin.AmplitudeGain = 0;
        _timer = 0;
    }
}