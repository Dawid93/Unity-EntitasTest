using Entitas;
using UnityEngine;

namespace Sources.Systems.Game
{
    public class HexagonGridInitializeSystem : IInitializeSystem
    {
        private Contexts _contexts;
        public HexagonGridInitializeSystem(Contexts contexts)
        {
            _contexts = contexts;
            
        }
        public void Initialize()
        {
            // Debug.Log("Hello World Entitas");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    var gameEntity = _contexts.game.CreateEntity();
                    gameEntity.AddPosition(new Vector2Int(j, i));
                    gameEntity.isHexagon = true;
                    gameEntity.AddHexagonType(HexagonType.Empty);
                }
            }
        }
    }
}