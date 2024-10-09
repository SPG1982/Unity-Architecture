using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameLocator
{
    private readonly List<object> services = new();

    public void AddService(object service)
    {
        this.services.Add(service);
    }

    public void RemoveService(object service)
    {
        this.services.Remove(service);
    }

    public T GetService<T>()
    {
        foreach (var service in this.services)
        {
            if (service is T result)
            {
                return result;
            }
        }

        throw new Exception($"Service of type {typeof(T)} is not found!");
    }
}
