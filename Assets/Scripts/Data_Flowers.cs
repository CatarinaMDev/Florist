using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Flower", menuName = "ScriptableObjects/Flower_Information")]
public class Data_Flowers : ScriptableObject
{
    [Header("Visuals")]
    public Flower flowerPrefab;
    public Sprite flowerSprite;

    [Header("Identity")]
    [field: SerializeField] public string nameOfFlower { get; private set; }
    [field: SerializeField] public float growthTime { get; private set; }


    [Header("Economy")]
    [field: SerializeField, Min(0)] public int BuyPrice { get; private set; }
    [field: SerializeField, Min(0)] public int SellPrice { get; private set; }

    [Header("Characteristics of Flower")]
    [SerializeField] public List<Characteristics_Info> characteristics = new List<Characteristics_Info>();

    public float GetBaseCharacteristic(string name)
    {
        foreach (var charac in characteristics)
        {
            if (charac.name == name) return charac.value;
        }
        return 0f;
    }
}

[System.Serializable]
public struct Characteristics_Info
{
    public string name;
    public float value;
}