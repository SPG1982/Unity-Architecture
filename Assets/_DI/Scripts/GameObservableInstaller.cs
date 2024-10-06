using Assets._DI.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameObservableInstaller : MonoBehaviour
{
    [SerializeField]
    private GameMachine gameMachine;

    [SerializeField]
    private MonoBehaviour[] gameListeners;

    private void Awake()
    {
        foreach (var listener in gameListeners)
        {
            gameMachine.AddListener(listener);
        }
    }
}
