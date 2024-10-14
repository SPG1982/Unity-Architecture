using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    [SerializeField] ColliderRenderer _colliderRenderer;
    [SerializeField] int _sides;
    [SerializeField] PolygonCollider2D _collider;

    private void OnValidate()
    {
        CreateCircle();
    }

    void CreateCircle()
    {
        _collider.CreatePrimitive(_sides, Vector2.one);
        _colliderRenderer.CreateMesh();
    }
}
