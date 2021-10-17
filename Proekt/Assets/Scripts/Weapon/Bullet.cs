using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Earth")
        {
            PhotonNetwork.Instantiate(explosion.name,transform.position,Quaternion.identity);
        }
        if(collision.gameObject.tag == "Player")
        {
            PhotonNetwork.Instantiate(explosion.name, transform.position, Quaternion.identity);
        }
        PhotonNetwork.Destroy(transform.gameObject);
    }
}
