using System;
using System.Collections;
using System.Collections.Generic;
using Project.Character;
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
        [SerializeField] private CharacterData characterData;
        
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
            SetData();
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
        //     if (characterData) SetData(characterData);
        // }

        #region Character Data
        /// <summary>
        /// Sets the player's data, updating the controller's corresponding properties.
        /// </summary>
        public void SetData()
        {
            SetData(characterData);
        }
        
        /// <summary>
        /// Sets the player's data, updating the controller's corresponding properties.
        /// </summary>
        /// <param name="data">The character data to set.</param>
        public void SetData(CharacterData data)
        {
            characterData = data;
            moveSpeed = data.moveSpeed;
            animator.runtimeAnimatorController = data.animatorController;
            spriteRenderer.sprite = data.image;
        }
        #endregion
    }
}
