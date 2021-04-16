using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button SaveButton;
    [SerializeField] private Button QuitButton;
    
    void Start()
    {
        ResumeButton.onClick.AddListener(HandleResumeClicked);
        SaveButton.onClick.AddListener(HandleSaveClicked);
        QuitButton.onClick.AddListener(HandleQuitClicked);
    }

    private void HandleQuitClicked()
    {
        GameManager.Instance.Quit();
    }

    private void HandleSaveClicked()
    {
        SaveButton.interactable = false;
        //GameManager.Instance.Save();
        SaveFile.Instance.Save();
        Thread.Sleep(1000);
        SaveButton.interactable = true;
    }

    private void HandleResumeClicked()
    {
        GameManager.Instance.TogglePause();
    }
}
