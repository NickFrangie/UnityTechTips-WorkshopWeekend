using System.Collections;
using System.Collections.Generic;
using Project.Player;
using UnityEngine;
using UnityEditor;

namespace Project.Editor
{
    /// <summary>
    /// An editor for the player controller.
    /// </summary>
    [CustomEditor(typeof(PlayerController))]
    public class PlayerControllerEditor : UnityEditor.Editor
    {   
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            PlayerController playerController = (PlayerController) target;
            if (GUILayout.Button("Set Data"))
            {
                playerController.Awake();
                playerController.SetData();
            }
        }
    }
}
