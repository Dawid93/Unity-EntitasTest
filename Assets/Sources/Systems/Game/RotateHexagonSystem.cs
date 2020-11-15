using System.Collections.Generic;
using Entitas;

namespace Sources.Systems.Game
{
    public class RotateHexagonSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        
        public RotateHexagonSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.ClickInput, GameMatcher.Position,
                GameMatcher.ButtonNumber));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasButtonNumber && entity.buttonNumber.value == 1;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var hexagons = _contexts.game.GetEntitiesWithPosition(entity.position.value);

                foreach (var hexagon in hexagons)
                {
                    if (hexagon.hasHexagonRotation)
                    {
                        int newValue = hexagon.hexagonRotation.value + 1;
                        newValue %= 6;
                        hexagon.ReplaceHexagonRotation(newValue);
                    }
                }
                entity.Destroy();
            }
        }
    }
}