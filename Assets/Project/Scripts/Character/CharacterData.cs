using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Character
{
    /// <summary>
    /// A data object for a character.
    /// </summary>
    [CreateAssetMenu(fileName = "New Character", menuName = "Character/Character Data")]
    public class CharacterData : ScriptableObject
    {
        [Header("General")]
        public string characterName;
        
        [Header("Graphics")]
        public RuntimeAnimatorController animatorController;
        
        [Header("Gameplay")]
        public float moveSpeed = 5f;
    }
}