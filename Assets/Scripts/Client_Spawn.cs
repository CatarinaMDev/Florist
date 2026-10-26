using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Client_Spawn : MonoBehaviour
{
    [Header("Prefabs & Data")]
    [SerializeField] private Client baseClientPrefab;
    [SerializeField] private List<Data_Character> clients_available = new List<Data_Character>();

    [Header("Scene Waypoints")]
    [SerializeField] private Transform counterSpot;
    [SerializeField] private Transform waitingSpot;
    [SerializeField] private Transform leftSpot;
    [SerializeField] private Transform startSpot;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.cKey.wasPressedThisFrame)
        {
            SpawnClient(clients_available[Random.Range(0, clients_available.Count)], startSpot.position);
        }
    }

    public void SpawnClient(Data_Character clientData, Vector3 position)
    {
        if (clientData == null) return;

        Client newClient = Instantiate(baseClientPrefab, position, Quaternion.identity);

        newClient.InitializeClient(clientData, counterSpot, waitingSpot, leftSpot);

        Debug.Log("O cliente gerado chama-se: " + clientData.nameOfCharacter);
    }
}