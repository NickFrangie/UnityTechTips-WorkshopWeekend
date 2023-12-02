using System.Collections;
using System.Collections.Generic;
using Project.Player;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        PlayerController playerController = (PlayerController) target;
        if (GUILayout.Button("Update Data"))
        {
            playerController.Awake();
            playerController.SetData(playerController.data);
        }
    }
}
