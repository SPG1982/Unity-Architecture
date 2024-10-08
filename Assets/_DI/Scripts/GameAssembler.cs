using DI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameAssembler : MonoBehaviour
{
    [SerializeField]
    private GameLocator gameLocator;

    [Space]
    [SerializeField]
    private MoveController moveController;

    private void Start()
    {
        ConstructMoveController();
    }

    private void ConstructMoveController()
    {
        var keyboardInput = this.gameLocator.GetService<IMoveInput>();
        var player = this.gameLocator.GetService<IPlayer>();
        moveController.Construct(keyboardInput, player);
    }
}
