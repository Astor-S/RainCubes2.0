using UnityEngine;
using TMPro;

public class Counter<T> : MonoBehaviour where T : MonoBehaviour, IDestroyableObject<T>
{
    [SerializeField] private Spawner<T> _spawner;
    [SerializeField] private TextMeshProUGUI _statsText;

    private void Update()
    {
        _statsText.text = $"{typeof(T).Name}\n" +
                          $"Заспавнено: {_spawner.TotalSpawned}\n" +
                          $"Создано: {_spawner.TotalCreated}\n" +
                          $"Активно: {_spawner.ActiveCount}";
    }
}