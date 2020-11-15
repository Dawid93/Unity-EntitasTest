using System.Collections;
using System.Collections.Generic;
using Entitas;
using Sources.Systems.Game;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Systems _systems;
    void Start()
    {
        var contexts = Contexts.sharedInstance;
        _systems = CreateSystems(contexts);
        _systems.Initialize();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new HexagonGridInitializeSystem(contexts));    
    }
}
