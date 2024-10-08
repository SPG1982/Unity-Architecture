using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IMoveInput
{

    event Action<Vector3> OnMove;
    void Move(Vector3 direction);

}
