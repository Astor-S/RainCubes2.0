using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour, IDestroyableObject<Cube>
{
    [SerializeField] private float _minDuration = 2f;
    [SerializeField]  private float _maxDuration = 6f;

    private Renderer _renderer;
    private Color _initialColor;
    private bool _hasTouchedPlatform = false;
    private float _lifeTimeAfterTouch;

    public event Action<Cube> Destroyed;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        _initialColor = _renderer.material.color;
    }

    private void OnEnable()
    {
            _renderer.material.color = _initialColor;
            _hasTouchedPlatform = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_hasTouchedPlatform == false && collision.gameObject.GetComponent<Platform>() != null)
        {
            _hasTouchedPlatform = true;
            ChangeColor();
            _lifeTimeAfterTouch = UnityEngine.Random.Range(_minDuration, _maxDuration);
            Invoke(nameof(Destroy), _lifeTimeAfterTouch);
        }
    }

    private void ChangeColor()
    {
        _renderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    private void Destroy()
    {
        Destroyed?.Invoke(this);
    }
}