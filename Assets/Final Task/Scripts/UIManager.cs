using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PlayButton;


    public void Play() //Game Start
    {
        PlayButton.SetActive(false);

        PlayerController.m_start = true;
    }

}//CLASS
