using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class loadScenes : MonoBehaviour
{
   [SerializeField] private string loadLevel;

  void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene("BossFight");
    }
}
