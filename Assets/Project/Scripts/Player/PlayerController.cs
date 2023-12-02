using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Project.Character;

namespace Project.Player
{
    /// <summary>
    /// A controller for the player character.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        // Inspector
        public CharacterData data;
        [SerializeField] private float moveSpeed = 5f;
        
        // References
        private Rigidbody2D rigidbody2D;
        private Animator animator;
        private SpriteRenderer spriteRenderer;

        
        public void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Start()
        {
            SetData(data);
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

        // private void OnValidate()
        // {
        //     if (data != null)
        //     {
        //         Awake();
        //         SetData(data);
        //     }
        // }

        #region Character Data
        public void SetData(CharacterData data)
        {
            this.data = data;
            this.moveSpeed = data.moveSpeed;
            animator.runtimeAnimatorController = data.animatorController;
            spriteRenderer.sprite = data.image;
        }
        #endregion
    }
}
