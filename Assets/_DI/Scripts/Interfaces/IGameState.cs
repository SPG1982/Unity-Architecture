using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    OFF = 0,
    PLAY = 1,
    PAUSE = 2,
    FINISH = 3,
}

public interface IStartGameListener
{
    void OnStartGame();
}

public interface IPauseGameListener
{
    void OnPauseGame();
}

public interface IResumeGameListener
{
    void OnResumeGame();
}

public interface IFinishGameListener
{
    void OnFinishGame();
}
