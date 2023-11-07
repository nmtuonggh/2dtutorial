using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] protected AudioSource checkPointSound;

    private void Start()
    {
        checkPointSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (checkPointSound.time > 0.988f)
        {
            checkPointSound.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            checkPointSound.Play();
            Invoke("CompleteLV", 1.5f);
            
        }
    }
    


    private void CompleteLV()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
