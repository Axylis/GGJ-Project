using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] bg;
    public Sprite[] player;
    private int i;

    public void changeSprite()
    {
        if(i == 0)
        {
            spriteRenderer.sprite = bg[i+1];
            i++;
        }
        else
        {
            spriteRenderer.sprite = bg[0];
            i--;
        }
    }

}
