﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonController : MonoBehaviour {
    public GameObject build;
    public GameObject buildList;
    public GameObject buildbutton;
    public GameObject backbutton;
    public Transform building;
    public GameObject LogIn;
    public Text username;
    bool loginbool=false;
    void Start()
    {
        if (PlayerPrefsX.GetBool("login"))
        {
            LogIn.SetActive(false);
        }
    }
  

    public void appear()
    {
        buildList.SetActive(true);
        build.SetActive(true);
        backbutton.SetActive(true);
        buildbutton.SetActive(false);
        
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(1);
    }


    public void disappear()
    {
        buildList.SetActive(false);
        build.SetActive(false);
        backbutton.SetActive(false);
        buildbutton.SetActive(true);
      
    }
    public void login()
    {
        Destroy(LogIn);
        loginbool = true;
        PlayerPrefsX.SetBool("login", loginbool);
        PlayerPrefs.SetString("UserID", username.text);
    }
}

