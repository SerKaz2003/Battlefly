using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Earth")
        {
            Destroy(collision.gameObject);
            Destroy(transform.gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().hp--;
            Destroy(transform.gameObject);
        }
        Destroy(transform.gameObject);
    }
}
