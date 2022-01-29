using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class MainCharacterMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float horizontalMovement = 0f;
    private SpriteRenderer sprite;
    // Update is called once per frame
    private void Start()
    {
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
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            sprite.flipX = true;
        }
    }
}
