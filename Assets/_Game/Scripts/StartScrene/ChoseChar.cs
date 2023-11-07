using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseChar : MonoBehaviour
{
    [SerializeField] private GameObject[] character;
    private int charIndex;

    public void ChooseChar(int index)
    {
        /*for (int i = 0; i < character.Length; i++)
        {
            character[i].SetActive(false);
        }*/
        charIndex = index;
        
        //character[index].SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("ChooseChar", charIndex);
    }
}
