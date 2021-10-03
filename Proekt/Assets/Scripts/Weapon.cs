using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool veterYes;
    public static int veter = 0;
    public int damage;
    public int destruction;
    public Sprite weaponimage;
    public GameObject player;
    public GameObject Bullet;
    public Transform pricel;

    private void Update()
    {

        if (player.GetComponent<PlayerMove>().PlayerOne)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Shoot();
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
        }
    }

    public void Shoot()
    {
        GameObject bul = Instantiate(Bullet, pricel.transform.position, Quaternion.identity);
        bul.GetComponent<Rigidbody2D>().AddForce(pricel.right * -10f, ForceMode2D.Impulse);

    }
}
