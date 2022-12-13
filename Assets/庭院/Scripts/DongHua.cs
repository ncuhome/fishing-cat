using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongHua : MonoBehaviour
{
    public Sprite[] Sprites;
    public float speed;
    private SpriteRenderer spriterenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
       // spriterenderer.color = new Color32(85, 145, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * speed) % Sprites.Length;
        spriterenderer.sprite = Sprites[index];
    }
}
