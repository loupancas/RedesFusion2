using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] private GameObject _playerPrefab;
    
    //Se ejecuta CADA VEZ que se conecta un cliente
    public void PlayerJoined(PlayerRef player)
    {
        //Si el player que entro es el jugador local, entonces "Instanciamos" en red a su player
        if (player == Runner.LocalPlayer)
        {
            Runner.Spawn(_playerPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
