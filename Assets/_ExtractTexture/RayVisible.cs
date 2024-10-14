using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RayVisible : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] private PolygonCollider2D _collider_polygon;
    [SerializeField] private BoxCollider2D _collider2d;
    RaycastHit2D[] hits = new RaycastHit2D[3];

    [SerializeField] Transform pointer;
    [SerializeField] GameObject cube;
    
    RaycastHit hit;
    RaycastHit hit_cube;

    void Start()
    {

    }

    public void Update()
    {
        //Hits();
    }

    void Hits()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.yellow);

        if (Physics.Raycast(ray, out hit)) {
            //Debug.Log("Попал 3D");
            //Debug.Log(hit.point);
            pointer.position = hit.point;
        }


        if (cube.GetComponent<BoxCollider>().Raycast(ray, out hit_cube, 100f)) {
            //Debug.Log("Коллайдер на кубе 3D");
        }

        if (Physics2D.Raycast(transform.position, Vector2.zero))
        {
            //Debug.Log("Попал 2D");
        }

        int x = _collider_polygon.Raycast(Vector2.down, hits);

        //Debug.Log("Коллайдер  2D" + hits);
        Debug.Log(x);

        foreach (RaycastHit2D hit in hits)
        {
            //print(hit.collider);
        }

    }
}
