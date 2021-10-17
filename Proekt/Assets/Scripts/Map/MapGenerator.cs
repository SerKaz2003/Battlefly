using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MapGenerator : MonoBehaviour
{
    public GameObject Earth;
    public GameObject Water;
    public GameObject player;

    void Start()
    {
        PhotonNetwork.Instantiate(player.name, new Vector2(Random.Range(-5,5), 11), Quaternion.identity);

        for (int i = 0; i > -10; i--)
        {
            for (int x = -10; x < 20; x+=10)
            {
                PhotonNetwork.Instantiate(Water.name, new Vector2(x, i), Quaternion.identity);
            }
        }
        for (float y = 0;y<10;y+=0.5f)
        {
 
            for(float x = -7;x<7;x+=0.5f)
            {
                int a =Random.Range(0, 2);
                if (a == 1)
                {
                    PhotonNetwork.Instantiate(Earth.name, new Vector2(x, y), Quaternion.identity);
                }
            }
        }
    }
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene(0);
        }
    }
}
