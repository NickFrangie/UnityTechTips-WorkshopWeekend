using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Character
{
    /// <summary>
    /// A data object for a character.
    /// </summary>
    [CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
    public class CharacterData : ScriptableObject
    {
        public string characterName;
        public RuntimeAnimatorController animatorController;
        public Sprite image;
        public float moveSpeed;   
    }
}
