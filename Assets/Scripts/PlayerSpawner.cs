using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Unity.VisualScripting;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] private GameObject _playerPrefab; 
    [SerializeField] public List<Transform> spawnPoints;
    [SerializeField] private GameObject  prefabBall;
    [SerializeField] public int numberOfPowerUps;
    public int minDistanceBetweenPowerUps;

    [SerializeField] private GameObject[] _prefabPowerUp;
    //Se ejecuta CADA VEZ que se conecta un cliente

   
    public void PlayerJoined(PlayerRef player)
    {
        //Si el player que entro es el jugador local, entonces "Instanciamos" en red a su player
        if (player == Runner.LocalPlayer)
        {
            int currentPlayer = -1;
            foreach (var item in Runner.ActivePlayers)
            {
                currentPlayer++;
            }

            Vector3 spawnPosition = spawnPoints.Count - 1 <= currentPlayer ? Vector3.zero : spawnPoints[currentPlayer].position;

            Runner.Spawn(_playerPrefab, spawnPosition, Quaternion.identity);
           SpawnerObjects();
        }

        
    }

    public void SpawnerObjects()
    {
        ObjectsSpawner _objects = ObjectsSpawner.instance;
        Vector3 _vector;
        Vector3 pos = new Vector3(0f, 0f, 1.5f);
        
        Runner.Spawn(prefabBall, Vector3.up, Quaternion.identity);

        for (int i = 0; i < numberOfPowerUps; i++)
        {
            _vector = _objects.GetRandomSpawnPoint(minDistanceBetweenPowerUps, pos);
            foreach (var prefab in _prefabPowerUp)
            {
                Runner.Spawn(prefab, _vector, Quaternion.identity);
            }
        }
    }


}
