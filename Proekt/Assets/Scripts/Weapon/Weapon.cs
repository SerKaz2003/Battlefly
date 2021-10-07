using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Weapon : MonoBehaviour
{
    public GameObject Bullet;
    public Transform pricel;
    public GameObject Player;
    PhotonView view;

    private void Start()
    {
        view = Player.GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }
        }
    }

    public void Shoot()
    {
        GameObject bul = PhotonNetwork.Instantiate(Bullet.name, pricel.transform.position, Quaternion.identity);
        bul.GetComponent<Rigidbody2D>().AddForce(pricel.right * -10f, ForceMode2D.Impulse);

    }
}
