using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Spawn : MonoBehaviour
{
    [Header("Prefabs & Data")]
    [SerializeField] private Player basePlayerPrefab;
    [SerializeField] private Data_Character playerData;

    [SerializeField] private Transform startSpot;

    void Start()
    {
        Player newPlayer = Instantiate(basePlayerPrefab, startSpot.position, Quaternion.identity);

        newPlayer.InitializePlayer(playerData);
    }
}