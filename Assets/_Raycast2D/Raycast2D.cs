using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2D : MonoBehaviour
{
    RaycastHit2D hit;
    GameObject selectedGameObject = null;


    void Start()
    {

    }

   void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");
        if (mw > 0.1)
        {
            transform.position += transform.forward * Time.deltaTime * 100;
        }
        if (mw < -0.1)
        {
            transform.position -= transform.forward * Time.deltaTime * 100;
        }


        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //Debug.DrawRay(transform.position, -Camera.main.ScreenToWorldPoint(Input.mousePosition) * 100, Color.yellow);

            if (hit.collider != null)
            {
                selectedGameObject = hit.collider.gameObject;
                selectedGameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);
                //Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
                Debug.Log(selectedGameObject.name);
            }
            else
            {
                if (selectedGameObject != null)
                {
                    //Debug.Log("11111111111");
                    selectedGameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
                    selectedGameObject = null;
                }

            }

        }


    }
}
