using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input.GetAxisRaw("Horizontal");
        Debug.log('(' + transform.position.x + ',' + transform.position.y + ')');
    }
}
