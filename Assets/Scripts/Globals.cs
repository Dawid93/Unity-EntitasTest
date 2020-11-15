using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, CreateAssetMenu(fileName = "globalAsset", menuName = "Global Asset")]
public class Globals : ScriptableObject
{
    public GameObject hexagonObject;
}
