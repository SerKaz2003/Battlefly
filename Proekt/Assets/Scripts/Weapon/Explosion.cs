using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Explosion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Earth")
        {
            //collision.gameObject.GetComponent<Ground>().MakeAHole(gameObject.GetComponent<CircleCollider2D>());
            PhotonNetwork.Destroy(collision.gameObject);
        }
        if(collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position) * 5f, ForceMode2D.Impulse);
            collision.transform.GetComponent<PlayerMove>().hp--;
            PhotonNetwork.Destroy(gameObject);
        }
        PhotonNetwork.Destroy(gameObject);
    }
}
