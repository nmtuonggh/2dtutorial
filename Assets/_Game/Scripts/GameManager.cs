using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;
    void Start()
    {
       // LoadChar();
    }

    private void LoadChar()
    {
        int charIndex = PlayerPrefs.GetInt("ChooseChar");
        Instantiate(characterPrefabs[charIndex]);
    }
}
