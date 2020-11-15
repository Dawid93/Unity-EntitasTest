using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems.Game
{
    public class RotateHexagonViewSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        
        public RotateHexagonViewSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.HexagonRotation));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasHexagonRotation;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var angle = entity.hexagonRotation.value * -60f;
                entity.view.value.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }
}