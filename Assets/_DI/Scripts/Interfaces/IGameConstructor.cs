using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameConstructor
{
    void ConstructGame(GameContext serviceLocator);
}
