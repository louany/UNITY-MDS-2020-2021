using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(SpriteRenderer))]
public class AnimateGirl : MonoBehaviour {

    Animator animator;
    SpriteRenderer spriteRenderer;
    public float maxSpeed = 2;
    private void Start() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        var maxDistancePerFrame = maxSpeed * Time.deltaTime;
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow)){
            animator.SetFloat("Speed", 2f);
            spriteRenderer.flipX = false;
            move += Vector3.right * maxDistancePerFrame;
        }

        else if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            animator.SetFloat("Speed", 2f);
            spriteRenderer.flipX = true;
            move += Vector3.left * maxDistancePerFrame;
        }
        
        else 
        {
            animator.SetFloat("Speed", 0f);
        }
        
        if(Input.GetKey(KeyCode.UpArrow)) 
        {
            move += Vector3.up * maxDistancePerFrame;
        } 

        else if(Input.GetKey(KeyCode.DownArrow)) 
        {
            move += Vector3.down * maxDistancePerFrame;
        } 

        else 
        {
            animator.SetInteger("Direction", 0);
        }

        this.transform.position = this.transform.position + move;
    }
}