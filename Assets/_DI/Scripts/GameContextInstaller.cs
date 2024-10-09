using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class GameContextInstaller : MonoBehaviour
{
    [SerializeField]
    private GameContext gameContext;

    [SerializeField]
    private MonoBehaviour[] installers;

    private void Awake()
    {
        foreach (var installer in this.installers)
        {
            if (installer is IGameServiceProvider serviceProvider)
            {
                this.gameContext.AddService(serviceProvider.GetServices().ElementAt(0));

                //serviceProvider.GetServices();
                //Debug.Log(installer);
                //Debug.Log(serviceProvider.Test().GetEnumerator().GetType());
                //Debug.Log(serviceProvider.GetServices().ElementAt(0).GetType());
            }

            if (installer is IGameListenerProvider listenerProvider)
            {
                this.gameContext.AddListener(listenerProvider.GetListeners().ElementAt(0));
            }
        }
    }

    private void Start()
    {
        foreach (var installer in this.installers)
        {
            if (installer is IGameConstructor constructor)
            {
                constructor.ConstructGame(this.gameContext);
            }
        }
    }
}
