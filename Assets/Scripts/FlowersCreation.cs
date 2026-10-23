using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class FlowersCreation : MonoBehaviour
{
    [SerializeField] private Flower prefabFlowerBase;
    [Header("ExistingFlowers")]
    [SerializeField] private List<Data_Flowers> flowerBucket = new List<Data_Flowers>();

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.cKey.wasPressedThisFrame)
        {
            Debug.Log("Pressed C");
            SpawnFlower(flowerBucket[Random.Range(0, flowerBucket.Count)], Vector3.zero);
        }
    }

    public void SpawnFlower(Data_Flowers flowerData, Vector3 position)
    {
        if (flowerData == null) return;

        // 1. Instancia o prefab na posição escolhida
        Flower newFlower = Instantiate(flowerData.flowerPrefab, position, Quaternion.identity);

        // 2. Atribui o ScriptableObject à nova flor
        newFlower.DataFlower = flowerData;

        // 3. Força a inicialização das características para esta instância específica
        newFlower.InitializeCharacteristics();

        Debug.Log("I my name is" + newFlower.DataFlower.name);
    }
}