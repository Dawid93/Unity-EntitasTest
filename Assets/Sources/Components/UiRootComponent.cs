using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Sources.Components
{
    [Game, Unique]
    public class UiRootComponent : IComponent
    {
        public RectTransform value;
    }
}