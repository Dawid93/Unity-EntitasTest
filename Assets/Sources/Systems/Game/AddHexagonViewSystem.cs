using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

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
            var globals = _contexts.game.globals;
            var hexagonPrefab = _contexts.game.globals.value.hexagonObject;
            var uiRoot = _contexts.game.uiRoot.value;

            foreach (var elem in entities)
            {
                var hexagon = GameObject.Instantiate(hexagonPrefab, uiRoot);
                var rectTransform = hexagon.transform as RectTransform;
                var image = hexagon.GetComponent<Image>();
                elem.AddView(hexagon);
                
                var position = new Vector2(elem.position.value.x * globals.value.widthSpacing, elem.position.value.y * globals.value.heightSpacing);
                bool isEven = elem.position.value.x % 2 == 0;

                if (isEven)
                    image.color = globals.value.evenColor;
                else
                {
                    position.y += globals.value.heightOffset;
                    image.color = globals.value.oddColor;
                }

                rectTransform.anchoredPosition = position;
            }
        }
    }
}