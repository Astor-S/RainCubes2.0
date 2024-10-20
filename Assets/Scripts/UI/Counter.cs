using UnityEngine;
using TMPro;

public class Counter<T> : MonoBehaviour where T : MonoBehaviour, IDestroyableObject<T>
{
    [SerializeField] private Spawner<T> _spawner;
    [SerializeField] private TextMeshProUGUI _statsText;

    private void Update()
    {
        _statsText.text = $"{typeof(T).Name}\n" +
                          $"����������: {_spawner.TotalSpawned}\n" +
                          $"�������: {_spawner.TotalCreated}\n" +
                          $"�������: {_spawner.ActiveCount}";
    }
}