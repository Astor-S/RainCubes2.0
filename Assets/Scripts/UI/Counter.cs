using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private SpawnerCube _cubeSpawner;
    [SerializeField] private SpawnerBomb _bombSpawner;

    [SerializeField] private TextMeshProUGUI _cubeStatsText;
    [SerializeField] private TextMeshProUGUI _bombStatsText;

    private void Update()
    {
        _cubeStatsText.text = $"Кубы\n" +
                              $"Заспавнено: {_cubeSpawner.TotalSpawned}\n" +
                              $"Создано: {_cubeSpawner.TotalCreated}\n" +
                              $"Активно: {_cubeSpawner.ActiveCount}";

        _bombStatsText.text = $"Бомбы\n" +
                              $"Заспавнено: {_bombSpawner.TotalSpawned}\n" +
                              $"Создано: {_bombSpawner.TotalCreated}\n" +
                              $"Активно: {_bombSpawner.ActiveCount}";
    }
}