using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerInstaller : MonoBehaviour, IGameServiceProvider, IGameListenerProvider, IGameConstructor
{
    [SerializeField]
    private Player player;

    private readonly MoveController moveController = new();

    //TODO: Подключить контроллер камеры:
    //[SerializeField]
    //private CameraController cameraController;


    IEnumerable<object> IGameServiceProvider.GetServices()
    {
        yield return this.player;
    }

    IEnumerable<object> IGameListenerProvider.GetListeners()
    {
        yield return this.moveController;
        //yield return this.cameraController;
    }

    void IGameConstructor.ConstructGame(GameContext serviceLocator)
    {
        var keyboardInput = serviceLocator.GetService<IMoveInput>();
        this.moveController.Construct(keyboardInput, this.player);

        //var camera = serviceLocator.GetService<WorldCamera>();
        //this.cameraController.Construct(camera, this.player)
    }
}
