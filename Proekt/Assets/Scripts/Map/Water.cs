using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        rb.AddForce(new Vector2(0,1f));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bul")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMove>().hp -= 1000;
        }
    }
}
