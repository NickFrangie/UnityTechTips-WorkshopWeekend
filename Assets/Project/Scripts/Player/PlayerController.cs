using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Player
{
    /// <summary>
    /// A controller for the player character.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        // Inspector
        [SerializeField] private float moveSpeed = 5f;
        
        // References
        private Rigidbody2D rigidbody2D;
        private Animator animator;

        
        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            bool isWalking = input != Vector2.zero;
            
            // Movement
            rigidbody2D.velocity = input * moveSpeed;
            
            // Graphics
            if (isWalking)
            {
                transform.right = input;
            }
            animator.SetBool("isWalking", isWalking);
        }
    }
}
