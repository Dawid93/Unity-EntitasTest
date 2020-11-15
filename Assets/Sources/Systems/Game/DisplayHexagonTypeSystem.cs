using System.Collections.Generic;
using Entitas;

namespace Sources.Systems.Game
{
    public class DisplayHexagonTypeSystem : ReactiveSystem<GameEntity>
    {
        public DisplayHexagonTypeSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.HexagonType);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && entity.hasHexagonType;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.view.value.GetComponent<HexagonTypeIndicator>().SetType(entity.hexagonType.value);
            }
        }
    }
}