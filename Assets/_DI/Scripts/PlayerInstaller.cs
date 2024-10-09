using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerInstaller : MonoBehaviour, IGameServiceProvider, IGameListenerProvider, IGameConstructor
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private MoveController moveController;

    //TODO: Подключить контроллер камеры:
    //[SerializeField]
    //private CameraController cameraController;


    IEnumerable<object> IGameServiceProvider.Test() {
        Debug.Log("ТЕСТ");
        yield return this.player;
    }


    IEnumerable<object> IGameServiceProvider.GetServices()
    {
        Debug.Log("GetServices");
        yield return this.player;
    }

    IEnumerable<object> IGameListenerProvider.GetListeners()
    {
        yield return this.moveController;
        //yield return this.cameraController;
    }

    void IGameConstructor.ConstructGame(IGameLocator serviceLocator)
    {
        var keyboardInput = serviceLocator.GetService<IMoveInput>();
        this.moveController.Construct(keyboardInput, this.player);

        //var camera = serviceLocator.GetService<WorldCamera>();
        //this.cameraController.Construct(camera, this.player)
    }
}
