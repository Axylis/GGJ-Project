using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float horizontalMovement = 0f;
    private SpriteRenderer sprite;
    public Animation spriteanim;
    public Animator animcontrol;
    // Update is called once per frame
    private void Start()
    {
        DontDestroyOnLoad(this);
        sprite = GetComponent<SpriteRenderer>();
        if(sprite == null)
        {
            Debug.LogError("Sprite Missing");
        }
    }
    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(horizontalMovement, 0, 0) * Time.deltaTime * moveSpeed;
        Debug.Log("(" + transform.position.x + "," + transform.position.y + ")");
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            sprite.flipX = false;
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            sprite.flipX = true;
        }


        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            spriteanim.Stop();
        }
    }
}
