using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryCount : MonoBehaviour

{
    [SerializeField] protected Text cherriText;
    [SerializeField] protected AudioSource takeBerry;
    protected int cherryScore = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherryScore++;
            cherriText.text = "Cherries: " + cherryScore;
            takeBerry.Play();
        }
        Debug.Log("Cherry: " + cherryScore);
    }
}
