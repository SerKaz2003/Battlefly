using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTwo : MonoBehaviour
{
    public GameObject pixel;
    void Start()
    {
        for (float x = 0.015f; x<1;x+=0.015f)
        {
            for(float y = 0.015f;y<1;y+=0.015f)
            {
                Instantiate(pixel, new Vector3(x, y, 0), Quaternion.identity, transform);
            }
        }
    }

  
}
