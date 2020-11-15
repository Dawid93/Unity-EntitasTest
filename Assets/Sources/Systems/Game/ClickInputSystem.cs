using System.Linq;
using Entitas;
using UnityEngine;

namespace Sources.Systems.Game
{
    public class ClickInputSystem : IExecuteSystem
    {
        private Contexts _contexts;
        private IGroup<GameEntity> _hexagonGroup;
        
        public ClickInputSystem(Contexts contexts)
        {
            _contexts = contexts;
            _hexagonGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Hexagon, GameMatcher.View));
        }
        
        public void Execute()
        {
            for (int i = 0; i < 2; i++)
            {
                if (Input.GetMouseButtonDown(i))
                {
                    var hexes = _hexagonGroup.GetEntities();
                    var mousePos = Input.mousePosition;

                    var clicked = hexes.OrderBy(x => (x.view.value.transform.position - mousePos).sqrMagnitude)
                        .FirstOrDefault(x =>
                            (x.view.value.transform.position - mousePos).magnitude <
                            _contexts.game.globals.value.clickRadius);

                    if (clicked != null)
                    {
                        var entity = _contexts.game.CreateEntity();
                        entity.isClickInput = true;
                        entity.AddPosition(clicked.position.value);
                        entity.AddButtonNumber(i);
                    }
                }
            }
        }
    }
}