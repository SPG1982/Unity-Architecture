using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class InputInstaller : MonoBehaviour,
        IGameServiceProvider,
        IGameListenerProvider
{
    [SerializeField]
    private KeyboardInput keyboardInput;

    //TODO: подключить ввод с мыши
    //[SerializeField]
    //private MouseInput mouseInput;

    IEnumerable<object> IGameServiceProvider.GetServices()
    {
        yield return this.keyboardInput;
        //yield return this.mouseInput;
    }

    IEnumerable<object> IGameListenerProvider.GetListeners()
    {
        yield return this.keyboardInput;
        //yield return this.mouseInput;
    }

    IEnumerable<object> IGameServiceProvider.Test()
    {
        yield break;
    }


}
