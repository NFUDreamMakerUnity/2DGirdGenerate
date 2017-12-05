using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirdWallBuilder : MonoBehaviour
{

    public static GirdWallBuilder instence;
    [SerializeField] int lineAmount;
    [SerializeField] int wallLenth;
    [SerializeField] GameObject gird;
    [SerializeField] Vector2 startPoint;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject heighLight;


    void Awake()
    {
        if (instence == null)
        {
            instence = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void BuildWall()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction, 1000, layerMask, 0);
        /*HeightLight*/
        if(hit2D)
        {
            heighLight.SetActive(true);
            heighLight.transform.position = hit2D.transform.position;
        }
        else
        {
            heighLight.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (hit2D)
            {
                foreach (var item in hit2D.collider.gameObject.GetComponentsInChildren<SpriteRenderer>())
                {
                    item.enabled = true;
                }
            }
        }
    }

    public void GenerateGird()
    {
        for (int i = 0; i < lineAmount; i++)
        {
            for (int j = 0; j < wallLenth; j++)
            {
                GameObject clone = Instantiate(gird);
                clone.transform.position = new Vector2(i, j) + startPoint;
                if (i == 0)
                {
                    foreach (var item in clone.GetComponentsInChildren<SpriteRenderer>())
                    {
                        item.enabled = true;
                    }
                }
            }
        }
    }
}
