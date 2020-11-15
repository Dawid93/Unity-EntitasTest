using System.Collections.Generic;
using Entitas;

namespace Sources.Systems.Game
{
    public class ChangeHexagonTypeSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        private int _hexagonTypesCount = 5;
        
        public ChangeHexagonTypeSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.ClickInput, GameMatcher.Position, GameMatcher.ButtonNumber));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isClickInput && entity.hasPosition && entity.hasButtonNumber && entity.buttonNumber.value == 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var hexagons = _contexts.game.GetEntitiesWithPosition(entity.position.value);

                foreach (var hexagon in hexagons)
                {
                    if (hexagon.hasHexagonType)
                    {
                        var newType = (int) hexagon.hexagonType.value + 1;
                        newType %= _hexagonTypesCount;
                        hexagon.ReplaceHexagonType((HexagonType) newType);
                    }
                }
                entity.Destroy();
            }
        }
    }
}