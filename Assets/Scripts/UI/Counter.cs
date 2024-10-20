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
        _cubeStatsText.text = $"����\n" +
                              $"����������: {_cubeSpawner.TotalSpawned}\n" +
                              $"�������: {_cubeSpawner.TotalCreated}\n" +
                              $"�������: {_cubeSpawner.ActiveCount}";

        _bombStatsText.text = $"�����\n" +
                              $"����������: {_bombSpawner.TotalSpawned}\n" +
                              $"�������: {_bombSpawner.TotalCreated}\n" +
                              $"�������: {_bombSpawner.ActiveCount}";
    }
}