using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public float damage;
    private void Start()
    {        
        Cursor.visible = false;
    }
    void Update()
    {
        UpdatePos();
    }

    void UpdatePos()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);        
        float distance;
        Plane plane = new Plane(new Vector3(-50, 0, 50), new Vector3(50, 0, 50), new Vector3(-50, 0, -50));
        Plane plane2 = new Plane(new Vector3(50, 0, 50), new Vector3(50, 0, -50), new Vector3(-50, 0, -50));
        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            transform.position = target;
        }
        else
        {
            if (plane2.Raycast(ray, out distance))
            {
                Vector3 target = ray.GetPoint(distance);
                transform.position = target;
            }
        }


    }

    
}
