using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameMachine : MonoBehaviour
{
    public GameState GameState
    {
        get { return this.gameState; }
    }

    private readonly List<object> listeners = new();

    private GameState gameState = GameState.OFF;

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        if (this.gameState != GameState.OFF)
        {
            Debug.LogWarning($"You can start game only from {GameState.OFF} state!");
            return;
        }

        this.gameState = GameState.PLAY;

        foreach (var listener in this.listeners)
        {
            if (listener is IStartGameListener startListener)
            {
                startListener.OnStartGame();
            }
        }
    }

    [ContextMenu("Pause Game")]
    public void PauseGame()
    {
        if (this.gameState != GameState.PLAY)
        {
            Debug.LogWarning($"You can pause game only from {GameState.PLAY} state!");
            return;
        }

        this.gameState = GameState.PAUSE;

        foreach (var listener in this.listeners)
        {
            if (listener is IPauseGameListener pauseListener)
            {
                pauseListener.OnPauseGame();
            }
        }
    }

    [ContextMenu("Resume Game")]
    public void ResumeGame()
    {
        if (this.gameState != GameState.PAUSE)
        {
            Debug.LogWarning($"You can resume game only from {GameState.PAUSE} state!");
            return;
        }

        this.gameState = GameState.PLAY;

        foreach (var listener in this.listeners)
        {
            if (listener is IResumeGameListener resumeListener)
            {
                resumeListener.OnResumeGame();
            }
        }
    }

    [ContextMenu("Finish Game")]
    public void FinishGame()
    {
        if (this.gameState != GameState.PLAY)
        {
            Debug.LogWarning($"You can finish game only from {GameState.PLAY} state!");
            return;
        }

        this.gameState = GameState.FINISH;

        foreach (var listener in this.listeners)
        {
            if (listener is IFinishGameListener finishListener)
            {
                finishListener.OnFinishGame();
            }
        }
    }

    public void AddListener(object listener)
    {
        this.listeners.Add(listener);
    }

    public void RemoveListener(object listener)
    {
        this.listeners.Remove(listener);
    }
}
