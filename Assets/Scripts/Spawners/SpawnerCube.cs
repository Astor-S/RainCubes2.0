using System.Collections;
using UnityEngine;

public class SpawnerCube : Spawner<Cube>
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private SpawnerBomb _spawnerBomb;
    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private float _startDelay = 0.0f;
    [SerializeField] private float _spawnHeight = 20f;

    private int _zeroPlatform = 0;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    protected override void OnObjectDestroyed(Cube cube)
    {
        base.OnObjectDestroyed(cube);
        _spawnerBomb.Spawn(cube.transform.position);
    }

    private Vector3 GetRandomPositionOverPlatform()
    {
        if (_platforms.Length == 0)
            return _startPoint.transform.position;

        Platform randomPlatform = _platforms[Random.Range(_zeroPlatform, _platforms.Length)];
        Bounds platformBounds = randomPlatform.GetComponent<Collider>().bounds;

        Vector3 randomPosition = new Vector3(
            Random.Range(platformBounds.min.x, platformBounds.max.x),
            _spawnHeight,
            Random.Range(platformBounds.min.z, platformBounds.max.z)
        );

        return randomPosition;
    }

    private IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(_startDelay);

        while (enabled)
        {
            Spawn(GetRandomPositionOverPlatform());
            yield return new WaitForSeconds(_repeatRate);
        }
    }
}