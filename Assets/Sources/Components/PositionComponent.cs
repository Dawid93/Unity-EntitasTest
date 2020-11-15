using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Sources.Components
{
    [Game]
    public class PositionComponent : IComponent
    {
        [EntityIndex]
        public Vector2Int value;
    }
}