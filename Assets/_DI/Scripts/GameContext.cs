using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameContext : MonoBehaviour, IGameLocator, IGameMachine
{
    public GameState GameState
    {
        get { return this.gameMachine.GameState; }
    }

    private readonly GameMachine gameMachine = new();

    private readonly GameLocator serviceLocator = new();
    public GameContext()
    {
        this.serviceLocator.AddService(this.gameMachine);
    }

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        this.gameMachine.StartGame();
    }

    [ContextMenu("Pause Game")]
    public void PauseGame()
    {
        this.gameMachine.PauseGame();
    }

    [ContextMenu("Resume Game")]
    public void ResumeGame()
    {
        this.gameMachine.ResumeGame();
    }

    [ContextMenu("Finish Game")]
    public void FinishGame()
    {
        this.gameMachine.FinishGame();
    }

    public void AddListener(object listener)
    {
        this.gameMachine.AddListener(listener);
    }

    public void RemoveListener(object listener)
    {
        this.gameMachine.RemoveListener(listener);
    }

    public void AddService(object service)
    {
        this.serviceLocator.AddService(service);
    }

    public void RemoveService(object service)
    {
        this.serviceLocator.RemoveService(service);
    }

    public T GetService<T>()
    {
        return this.serviceLocator.GetService<T>();
    }
}
