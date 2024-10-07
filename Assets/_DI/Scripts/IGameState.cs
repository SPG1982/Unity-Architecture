using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    START = 1,
    FINISH = 2,
}

public interface IGameState
{
    void OnStartGame();
    void OnFinishGame();
}
