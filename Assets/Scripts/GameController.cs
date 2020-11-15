using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Sources.Systems.Game;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Globals globals;
    [SerializeField] private RectTransform uiRoot;
    
    private Systems _systems;
    void Start()
    {
        var contexts = Contexts.sharedInstance;
        contexts.game.SetGlobals(globals);
        contexts.game.SetUiRoot(uiRoot);
        
        _systems = CreateSystems(contexts);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            // Init
            .Add(new HexagonGridInitializeSystem(contexts))
            .Add(new AddHexagonViewSystem(contexts))
            // Input
            .Add(new ClickInputSystem(contexts))
            .Add(new ChangeHexagonTypeSystem(contexts))
            .Add(new RotateHexagonSystem(contexts))
            // View
            .Add(new DisplayHexagonTypeSystem(contexts))
            .Add(new RotateHexagonViewSystem(contexts));    
    }
}
