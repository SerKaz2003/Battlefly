using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapGenerator : MonoBehaviour
{
    public GameObject Earth;
    public GameObject Water;

    void Start()
    {
        for (int i = 0; i > -10; i--)
        {
            for (int x = -10; x < 20; x+=10)
            {
                Instantiate(Water, new Vector2(x, i), Quaternion.identity);
            }
        }
        for (int y = 0;y<10;y++)
        {
 
            for(int x = -7;x<7;x++)
            {
                int a = Random.Range(0,2);
                if (a == 1)
                {
                    Instantiate(Earth, new Vector2(x, y), Quaternion.identity);
                }
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Yes");
            Application.Quit();
        }
    }
}
