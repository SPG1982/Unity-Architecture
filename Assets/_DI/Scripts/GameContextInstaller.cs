using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public sealed class GameContextInstaller : MonoBehaviour
{
    [SerializeField]
    private GameContext gameContext;

    [SerializeField]
    private MonoBehaviour[] installers;

    public void RegisterComponents()
    {
        foreach (var installer in this.installers)
        {
            if (installer is IGameServiceProvider serviceProvider)
            {
                this.gameContext.AddServices(serviceProvider.GetServices());
            }

            if (installer is IGameListenerProvider listenerProvider)
            {
                this.gameContext.AddListeners(listenerProvider.GetListeners());
            }

        }
    }

    public void ConstructGame()
    {
        foreach (var installer in this.installers)
        {
            if (installer is IGameConstructor constructor)
            {
                constructor.ConstructGame(this.gameContext);
            }


            var keyboardInput = gameContext.GetService<IMoveInput>();
            gameContext.AddUpdateListener((IUpdateGameListener)keyboardInput);


        }
    }
}
