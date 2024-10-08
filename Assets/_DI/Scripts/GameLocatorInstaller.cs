using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameLocatorInstaller : MonoBehaviour
{
    [SerializeField]
    private GameLocator gameLocator;

    [SerializeField]
    private MonoBehaviour[] gameServices;

    private void Awake()
    {
        foreach (var service in gameServices)
        {
            gameLocator.AddService(service);
        }
    }
}
