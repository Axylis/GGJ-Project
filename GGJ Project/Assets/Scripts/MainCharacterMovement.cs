using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class MainCharacterMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public List<Vector2> depthLevel;
    public Vector2 horizontalLimit;
    private float horizontalMovement = 0f;
    private SpriteRenderer sprite;
    private Animator spriteanim;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        spriteanim = GetComponent<Animator>();
    }
    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        Move();
        Animate();
    }

    private void Move(){
        float horizontalPos = transform.position.x + horizontalMovement * Time.deltaTime * moveSpeed;
        if(horizontalPos < horizontalLimit[0]){
            horizontalPos = horizontalLimit[0];
        }else if(horizontalPos > horizontalLimit[1]){
            horizontalPos = horizontalLimit[1];
        }

        float verticalPos = transform.position.y;
        if(depthLevel.Count > 1){
            for (int i = 0; i < depthLevel.Count; i++){
                if(depthLevel[i].x < transform.position.x){
                    verticalPos = depthLevel[i].y;
                }
            }
        }
        
        transform.position = new Vector3(horizontalPos, verticalPos, transform.position.z);
    }

    private void Animate(){
        if(horizontalMovement != 0){
            sprite.flipX = horizontalMovement > 0;
            spriteanim.Play("Walk");
        }else{
            spriteanim.Play("Idle");
        }
    }
}
