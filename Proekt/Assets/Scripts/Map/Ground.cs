using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ground : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private Texture2D  cloneTexture;
    public Texture2D baseTexture;
    private float widthWorld, heightWorld, widthPixel, heightPixel;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        cloneTexture = Instantiate(baseTexture);
      

        UpdateTexture();

        gameObject.AddComponent<PolygonCollider2D>();   
    }
    private void Update()
    {
        if (gameObject.GetComponent<PolygonCollider2D>().points[0][0].ToString() == "0")
        {
            Destroy(gameObject);
        }
    }

    public float WidthWorld
    {
        get
        {
            if (widthWorld == 0)
            {
                widthWorld = spriteRenderer.bounds.size.x;
            }
            return widthWorld;
        }
    }
    public float HeigthWorld
    {
        get
        {
            if (heightWorld == 0)
            {
                heightWorld = spriteRenderer.bounds.size.y;
            }
            return heightWorld;
        }
    }
    public float WidthPixel
    {
        get
        {
            if (widthPixel == 0)
            {
                widthPixel = spriteRenderer.sprite.texture.width;
            }
            return widthPixel;
        }
    }
    public float HeightPixel
    {
        get
        {
            if (heightPixel == 0)
            {
                heightPixel = spriteRenderer.sprite.texture.height;
            }
            return heightPixel;
        }
    }

    void UpdateTexture()
    {
        spriteRenderer.sprite = Sprite.Create(cloneTexture, new Rect(0, 0, cloneTexture.width, cloneTexture.height), new Vector2(0.5f, 0.5f), 50f);
    }

    Vector2Int World2Pixel(Vector2 pos)
    {
        Vector2Int v = Vector2Int.zero;

        float dx = (pos.x - transform.position.x);
        float dy = (pos.y - transform.position.y);

        v.x = Mathf.RoundToInt(0.5f * WidthPixel + dx * (WidthPixel / WidthWorld));
        v.y = Mathf.RoundToInt(0.5f * HeightPixel + dy * (HeightPixel / HeigthWorld));

        return v;
    }

    public void MakeAHole(CircleCollider2D col)
    {
        Vector2Int c = World2Pixel(col.bounds.center);

        int r = Mathf.RoundToInt(col.bounds.size.x * WidthPixel / WidthWorld);

        int px, nx, py, ny, d;

        for(int i = 0; i <=r;i++)
        {
            d = Mathf.RoundToInt(Mathf.Sqrt(r * r - i * r));

            for (int j = 0; j <=d; j++)
            {
                px = c.x + i;
                nx = c.x - i;
                py = c.y + j;
                ny = c.y - j;

                cloneTexture.SetPixel(px,py, Color.clear);
                cloneTexture.SetPixel(px, ny, Color.clear);
                cloneTexture.SetPixel(nx, py, Color.clear);
                cloneTexture.SetPixel(nx, ny, Color.clear);
            }
        }
        cloneTexture.Apply();

        UpdateTexture();
        PolygonCollider2D[] pcs = gameObject.GetComponents<PolygonCollider2D>();
        foreach (PolygonCollider2D item in pcs){
            Destroy(item);
        }
        gameObject.AddComponent<PolygonCollider2D>();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ex")
        {
          
            MakeAHole(collision.GetComponent<CircleCollider2D>());
            PhotonNetwork.Destroy(collision.gameObject);
        }
       
    }
}
