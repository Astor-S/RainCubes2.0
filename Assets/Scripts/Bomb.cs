using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Explosion))]
[RequireComponent(typeof(Renderer))]
public class Bomb : MonoBehaviour, IDestroyableObject<Bomb>
{
    [SerializeField] private float _minDelay = 2f;
    [SerializeField] private float _maxDelay = 6f;

    private Explosion _explosion;
    private Coroutine _explosionCoroutine;
    private Renderer _renderer;

    public event Action<Bomb> Destroyed;

    private void Awake()
    {
        _explosion = GetComponent<Explosion>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        Explode();
    }

    private IEnumerator ExplodeAfterDelay()
    {
        float delay = UnityEngine.Random.Range(_minDelay, _maxDelay);
        float timeRemaining = delay;

        while (timeRemaining > 0)
        {
            SetAlpha(timeRemaining / delay);
            yield return null;
            
            timeRemaining -= Time.deltaTime;
        }

        SetAlpha(0f);
        _explosion.Explode();
        Destroy();
    }

    private void Explode()
    {
        if (_explosionCoroutine != null)
            StopCoroutine(_explosionCoroutine);

        _explosionCoroutine = StartCoroutine(ExplodeAfterDelay());
    }

    private void SetAlpha(float alpha)
    {
        Color color = _renderer.material.color;
        color.a = alpha;
        _renderer.material.color = color;
    }

    private void Destroy()
    {
        Destroyed?.Invoke(this);
    }
}