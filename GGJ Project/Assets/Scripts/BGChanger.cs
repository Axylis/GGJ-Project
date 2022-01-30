using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(Collider2D))]
public class BGChanger : MonoBehaviour
{
    public SpriteRenderer bgRenderer;
    public SpriteRenderer propRender1;
    public SpriteRenderer propRender2;
    public SpriteRenderer propRender3;
    public Sprite[] bg;
    public Animator playerRenderer;
    private int i = 0;
    public Sprite[] prop1;
    public Sprite[] prop2;
    public Sprite[] prop3;
    public RuntimeAnimatorController[] playerAnim;
    public AudioSource dayBGM;
    public AudioSource nightBGM;

    private void Awake()
    {
        playerRenderer.runtimeAnimatorController = playerAnim[0];
        dayBGM.Play();
    }

    public void OnMouseDown()
    {
        playerChange();
        BGChange();
        BGMChanger();
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
    private void BGMChanger()
    {
        if(dayBGM.isPlaying)
        {
            dayBGM.Stop();
            nightBGM.Play();
        }
        else if(nightBGM.isPlaying)
        {
            nightBGM.Stop();
            dayBGM.Play();
        }
    }
}
