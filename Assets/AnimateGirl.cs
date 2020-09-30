using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(SpriteRenderer))]
public class AnimateGirl : MonoBehaviour {

    Animator animator;
    SpriteRenderer spriteRenderer;

    
    private void Start() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.RightArrow)){
            animator.SetFloat("Speed", 2f);
            this.transform.position = this.transform.position + ;
            spriteRenderer.flipX = false;
        } else if(Input.GetKey(KeyCode.LeftArrow)) {
                animator.SetFloat("Speed", 2f);
                spriteRenderer.flipX = true;
            }   else {
                    animator.SetFloat("Speed", 0f);
                }
        
        if(Input.GetKey(KeyCode.UpArrow)) {
            animator.SetFloat("Speed", 2f);
            animator.SetInteger("Direction", 1);
        } else {
            animator.SetInteger("Direction", 0);
        }

        if(Input.GetKey(KeyCode.DownArrow)) {
            animator.SetFloat("Speed", 2f);
            animator.SetInteger("Direction", 2);
        } else {
            animator.SetInteger("Direction", 0);
        }
    }
}