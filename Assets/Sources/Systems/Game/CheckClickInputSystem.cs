using System.Linq;
using Entitas;
using UnityEngine;

namespace Sources.Systems.Game
{
    public class CheckClickInputSystem : IExecuteSystem
    {
        private Contexts _contexts;
        private IGroup<GameEntity> _hexagonGroup;
        
        public CheckClickInputSystem(Contexts contexts)
        {
            _contexts = contexts;
            _hexagonGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Hexagon, GameMatcher.View));
        }
        
        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var hexes = _hexagonGroup.GetEntities();
                var mousePos = Input.mousePosition;

                var clicked = hexes.OrderBy(x => (x.view.value.transform.position - mousePos).sqrMagnitude)
                    .FirstOrDefault(x => (x.view.value.transform.position - mousePos).magnitude < _contexts.game.globals.value.clickRadius);
                
                Debug.Log($"Clicked Hex {clicked}");
            }
        }
    }
}