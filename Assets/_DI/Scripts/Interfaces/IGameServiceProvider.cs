using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameServiceProvider
{
    IEnumerable<object> GetServices();
    IEnumerable<object> Test();
}
