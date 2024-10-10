using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameContext : MonoBehaviour, IGameLocator, IGameMachine
{
    public GameState GameState
    {
        get { return this.gameMachine.GameState; }
    }

    private readonly List<IUpdateGameListener> updateListeners = new();

    private readonly GameMachine gameMachine = new();

    private readonly GameLocator serviceLocator = new();

    private void Awake()
    {

       // this.enabled = false;
    }

    //Вызывается только, если игра запущена
    private void Update()
    {
        var deltaTime = Time.deltaTime;
        for (int i = 0, count = this.updateListeners.Count; i < count; i++)
        {
            var listener = this.updateListeners[i];
            listener.OnUpdate(deltaTime);
        }
    }
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

    public void AddUpdateListener(IUpdateGameListener listener)
    {
        updateListeners.Add(listener);
    }

    public void AddListeners(IEnumerable listeners)
    {
        foreach (object listener in listeners)
        {
            this.gameMachine.AddListener(listener);
        }
    }

    public void RemoveListener(object listener)
    {
        this.gameMachine.RemoveListener(listener);
    }

    public void AddService(object service)
    {
        this.serviceLocator.AddService(service);
    }

    public void AddServices(IEnumerable services)
    {
        foreach (object service in services) {
            this.serviceLocator.AddService(service);
        }
        
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
