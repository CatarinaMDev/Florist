using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Character", menuName = "ScriptableObjects/Character_Information")]
public class Data_Character : ScriptableObject
{
    [Header("Visuals")]
    public Character characterPrefab;
    public Sprite characterSprite;

    [Header("Identity")]
    [field: SerializeField] public string nameOfCharacter { get; private set; }
    [field: SerializeField] public float movementSpeed { get; private set; }

}