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
        Debug.Log(CreateCat.i);
        spriterenderer.color = new Color(GlobalSaveManager.instance.saveManager.catList[CreateCat.i].r / 255f, GlobalSaveManager.instance.saveManager.catList[CreateCat.i].g / 255f, GlobalSaveManager.instance.saveManager.catList[CreateCat.i].b / 255f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * speed) % Sprites.Length;
        spriterenderer.sprite = Sprites[index];
    }
}
