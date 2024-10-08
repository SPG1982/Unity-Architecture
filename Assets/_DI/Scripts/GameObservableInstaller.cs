using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObservableInstaller : MonoBehaviour
{

    [SerializeField]
    private GameMachine gameMachine;

    [SerializeField]
    private MonoBehaviour[] gameListeners;

    private void Awake()
    {
        foreach (var listener in this.gameListeners)
        {
            this.gameMachine.AddListener(listener);
        }
    }



}
