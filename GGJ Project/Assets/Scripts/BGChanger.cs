using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BGChanger : MonoBehaviour
{
    public SpriteRenderer bgRenderer;
    public Sprite[] bg;
    public SpriteRenderer playerRenderer;
    private int i;

    public void OnMouseDown()
    {
        BGChange();
    }

    private void BGChange()
    {
        if(i == 0)
        {
            bgRenderer.sprite = bg[i+1];
            i++;
        }
        else
        {
            bgRenderer.sprite = bg[0];
            i--;
        }
    }

}
