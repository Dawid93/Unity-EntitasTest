using Entitas;
using UnityEngine;

namespace Sources.Components
{
    [Game]
    public class PositionComponent : IComponent
    {
        public Vector2Int value;
    }
}