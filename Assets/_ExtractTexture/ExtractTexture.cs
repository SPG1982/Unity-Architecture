using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExtractTexture : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PolygonCollider2D _collider_polygon;
    [SerializeField] GameObject circle;
    [SerializeField] GameObject map;
    Texture2D texture_original;
    Texture2D texture_clone;
    SpriteRenderer spriteRenderer;
    //float radius = 0.5f;
    Vector2 localPoint;


    //[SerializeField] private Texture2D _texture;
    //[SerializeField] private Sprite _sprite;

    //Texture2D texture;


    RaycastHit2D hit;

    void Start()
    {
        //_collider = GetComponent<PolygonCollider2D>();
        //circle.SetActive(true);

        //var sr = _sprite.GetComponent<SpriteRenderer>();
        //var texture = Instantiate(sr.sprite.texture);
        //_texture = GetComponent<Texture2D>();

        spriteRenderer = map.GetComponent<SpriteRenderer>();
        texture_original = map.GetComponent<SpriteRenderer>().sprite.texture;
        texture_clone = Instantiate(texture_original);
        //Debug.Log("Выполнено");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                //Debug.Log(hit.point);
            }

            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //GameObject circle_x = Instantiate(circle, new Vector3(mouse.x, mouse.y, 0f), Quaternion.identity);
            //circle_x.SetActive(true);




            //for (int x = 0; x < texture_clone.width / 2; ++x)
            //{
            //    for (int y = 0; y < texture_clone.height / 2; ++y)
            //    {
            //        texture_clone.SetPixel(x, y, Color.clear);
            //    }
            //}

            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider)
            {
                //Debug.Log(hit.collider.gameObject.transform.position);
                //Debug.Log(hit.point);
                GameObject map = hit.collider.GameObject();
                Vector2 mapCenterPoint = hit.collider.transform.InverseTransformPoint(hit.point);
                //Debug.Log("Локальные координаты: " + localPoint);

                Texture2D texture = spriteRenderer.sprite.texture;
                Rect textureRect = spriteRenderer.sprite.textureRect;

                // Получаем размеры спрайта в пикселях
                Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
                Vector2 pixelsPerUnit = new Vector2(spriteRenderer.sprite.pixelsPerUnit, spriteRenderer.sprite.pixelsPerUnit);

                // Преобразуем локальную позицию в пиксели
                Vector2 pixelPosition = new Vector2(
                    (mapCenterPoint.x + (spriteSize.x / 2)) * pixelsPerUnit.x,
                    (mapCenterPoint.y + (spriteSize.y / 2)) * pixelsPerUnit.y
                );

                Debug.Log("Координаты клика в пикселях: " + pixelPosition);


                //Debug.Log(transform.InverseTransformPoint(mouse));
                //Debug.Log(hit.point);

                for (int x = (int)pixelPosition.x; x < pixelPosition.x + 100; ++x)
                {
                    for (int y = (int)pixelPosition.y; y < pixelPosition.y + 100; ++y)
                    {
                        texture_clone.SetPixel(x, y, Color.clear);
                    }
                }

            }



            texture_clone.Apply();

            var pivot = new Vector2(0.5f, 0.5f);

            var rect = new Rect(0, 0, texture_clone.width, texture_clone.height);

            //_texture.sprite = Sprite.Create(texture, rect, pivot, sr.sprite.pixelsPerUnit);
            spriteRenderer.sprite = Sprite.Create(texture_clone, rect, pivot, spriteRenderer.sprite.pixelsPerUnit);


        }
    }




}
