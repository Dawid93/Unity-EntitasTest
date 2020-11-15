using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems.Game
{
    public class AddHexagonViewSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        
        public AddHexagonViewSystem(Contexts context) : base(context.game)
        {
            _contexts = context; 
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Hexagon, GameMatcher.Position));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isHexagon && entity.hasPosition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var hexagonPrefab = _contexts.game.globals.value.hexagonObject;
            var uiRoot = _contexts.game.uiRoot.value;

            foreach (var elem in entities)
            {
                var hexagon = GameObject.Instantiate(hexagonPrefab, uiRoot);
                var rectTransform = hexagon.transform as RectTransform;
                rectTransform.anchoredPosition = new Vector2(elem.position.value.x, elem.position.value.y);
            }
        }
    }
}