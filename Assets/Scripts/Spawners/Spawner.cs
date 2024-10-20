using UnityEngine;

public class Spawner<T> : MonoBehaviour where T :MonoBehaviour, IDestroyableObject<T>
{
    [SerializeField] private T _objectPrefab;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private Pool<T> _pool;

    public int TotalSpawned { get; private set; } = 0;   
    public int TotalCreated { get; private set; } = 0;
    public int ActiveCount { get; private set; } = 0;

    protected virtual void Awake()
    {
        _pool = new Pool<T>(
            CreateObject);
    }

    public void Spawn(Vector3 position)
    {
        T @object = _pool.GetObject();
        @object.transform.position = position;
        @object.Destroyed += OnObjectDestroyed;
        TotalSpawned++;
        ActiveCount++;
        @object.gameObject.SetActive(true);
    }

    protected virtual T CreateObject()
    {
        T newObj = Instantiate(_objectPrefab);
        TotalCreated++;

        return newObj;
    }

    protected virtual void OnObjectDestroyed(T obj)
    {
        obj.Destroyed -= OnObjectDestroyed;
        _pool.Release(obj);
        ActiveCount--;
        obj.gameObject.SetActive(false);
    }
}