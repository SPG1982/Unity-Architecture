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
                this.gameContext.AddServices(serviceProvider.GetServices());
            }

            if (installer is IGameListenerProvider listenerProvider)
            {
                this.gameContext.AddListener(listenerProvider.GetListeners());
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
