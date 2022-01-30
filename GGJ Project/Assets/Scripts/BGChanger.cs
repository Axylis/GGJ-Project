using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
=======
using UnityEngine.U2D.Animation;
>>>>>>> Stashed changes

[RequireComponent(typeof(Collider2D))]
public class BGChanger : MonoBehaviour
{
    public SpriteRenderer bgRenderer;
    public SpriteRenderer propRender1;
    public SpriteRenderer propRender2;
    public SpriteRenderer propRender3;
    public Sprite[] bg;
<<<<<<< Updated upstream
    public SpriteRenderer playerRenderer;
    private int i;
=======
    public Animator playerRenderer;
    private int i = 0;
    public Sprite[] prop1;
    public Sprite[] prop2;
    public Sprite[] prop3;
    public RuntimeAnimatorController[] playerAnim;

    private void Awake()
    {
        //_resolvers = GetComponentsInChildren<SpriteResolver>().ToList();
    }
>>>>>>> Stashed changes

    public void OnMouseDown()
    {
        BGChange();
        playerChange();
    }

    private void BGChange()
    {
        if(i == 0)
        {
            bgRenderer.sprite = bg[i+1];
            if(prop1[1] != null)
            {
               propRender1.sprite = prop1[i+1]; 
            }
            if(prop2[1] != null)
            {
                propRender2.sprite = prop2[i+1];
            }
            if(prop3[1] != null)
            {
                propRender3.sprite = prop3[i+1];
            }
            i++;
        }
        else
        {
            //back to default state
            bgRenderer.sprite = bg[0];
            propRender1.sprite = prop1[0];
            propRender2.sprite = prop2[0];
            propRender3.sprite = prop3[0];
            i--;
        }
    }

    private void playerChange()
    {
        if(i==0)
        {
            playerRenderer.runtimeAnimatorController = playerAnim[i+1];
        }
        else
        {
            //back to default state
            playerRenderer.runtimeAnimatorController = playerAnim[0];
        }
    }
}
