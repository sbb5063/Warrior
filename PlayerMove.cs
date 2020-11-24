using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController charctrl;
    private CharacterAnimations playerAnimations;

    public float moveSpeed;
    public float gravity;
    public float rotSpeed;
    public float rotDegperesec;
    // Start is called before the first frame update
    void Awake()
    {
        charctrl = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        WalkAnime();
    }

    void Move()
   {
        if(Input.GetAxis("Vertical") > 0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;
            charctrl.Move(moveDirection * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            Vector3 moveDirection = - transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;
            charctrl.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

       else
        {
            charctrl.Move(Vector3.zero);
        }
    }    

    void Rotate()
    {
        Vector3 rotdir = Vector3.zero;

        if(Input.GetAxis("Horizontal") < 0)
        {
            rotdir = transform.TransformDirection(Vector3.left);
        }

        
        if(Input.GetAxis("Horizontal") > 0)
        {
            rotdir = transform.TransformDirection(Vector3.right);
        }

        if(rotdir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotdir), 
            rotDegperesec * Time.deltaTime);
        }
    }   
        
    void WalkAnime()
    {
        if(charctrl.velocity.sqrMagnitude != 0f)
        {
            playerAnimations.Walk(true);
        }

        else
        {
            playerAnimations.Walk(false);
        }
    }    
}
