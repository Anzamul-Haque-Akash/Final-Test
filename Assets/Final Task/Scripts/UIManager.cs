using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PlayButton; //Play utton


    public void Play() //Game Start
    {
        PlayButton.SetActive(false);

       PlayerController.m_start = true;
    }

    public void Retry() //Game restart
    {
        SceneManager.LoadScene("GameScene");
    }

}//CLASS
