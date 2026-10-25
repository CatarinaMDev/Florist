
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    [SerializeField] private Data_Flowers data_flower;
    public Data_Flowers DataFlower { get => data_flower; set => data_flower = value; }

    private Dictionary<string, float> my_characteristics = new Dictionary<string, float>();
    public int BuyPrice => data_flower != null ? data_flower.BuyPrice : 0;
    public int SellPrice => data_flower != null ? data_flower.SellPrice : 0;

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InitializeCharacteristics();
    }

    public void InitializeCharacteristics()
    {
        my_characteristics.Clear();

        if (data_flower == null) return;

        foreach (var item in data_flower.characteristics)
        {
            my_characteristics[item.name] = item.value;
        }
        if (spriteRenderer != null && data_flower.flowerSprite != null)
        {
            spriteRenderer.sprite = data_flower.flowerSprite;
        }
    }

    public float GetCharacteristic(string name)
    {
        if (my_characteristics.TryGetValue(name, out float value))
        {
            return value;
        }
        return 0f;
    }

    // Permite alterar uma característica só desta flor (ex: aplicação de fertilizante)
    public void SetCharacteristic(string name, float newValue)
    {
        my_characteristics[name] = newValue;
    }
}


