using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int amountEnemySpawns;
    [SerializeField] private float enemySpawnRate;

    [Header("Debug")]
    [SerializeField] private List<Door> doors;

    /// <summary>
    /// Teleports the player to a random door and starts the room.
    /// </summary>
    public void Initialize()
    {
        if(doors.Count < 1)
        {
            Debug.LogError($"{name}: There is no doors in the room!");
        }
        else
        {
            Debug.Log("Initializing room...");
            MyGameManager.Instance.TeleportPlayer(doors[Random.Range(0, doors.Count - 1)].GetOffsetPosition());
            LevelManager.Instance.SetDoorsLocked(true);
            MyGameManager.Instance.HealPlayer();
            SpawnManager.Instance.SetUpSpawnPoints(gameObject);
            SpawnManager.Instance.StartSpawning(amountEnemySpawns, enemySpawnRate);
        }
    }

    private void OnValidate()
    {
        doors = new List<Door>(GetComponentsInChildren<Door>());
    }
}
