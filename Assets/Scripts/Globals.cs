using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, CreateAssetMenu(fileName = "globalAsset", menuName = "Global Asset")]
public class Globals : ScriptableObject
{
    public GameObject hexagonObject;

    public float heightSpacing;
    public float widthSpacing;
    public float heightOffset;

    public float clickRadius;

    public Color evenColor;
    public Color oddColor;
}
