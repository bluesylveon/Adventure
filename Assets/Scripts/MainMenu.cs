using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button NewFileButton;
    [SerializeField] private Button LoadButton;
    [SerializeField] private Button QuitButton;
    void Start()
    {
        NewFileButton.onClick.AddListener(HandleNewFileClicked);
        LoadButton.onClick.AddListener(HandleLoadClicked);
        QuitButton.onClick.AddListener(HandleQuitClicked);
    }

    private void HandleNewFileClicked()
    {
        SaveFile.Instance.NewSaveFile();
        GameManager.Instance.LoadLevel("Level0");
        gameObject.SetActive(false);
    }

    private void HandleLoadClicked()
    {
        GameManager.Instance.LoadLevel("Level" + SaveFile.Instance.GetLevelData()._LevelNumber);
        gameObject.SetActive(false);
    }

    private void HandleQuitClicked()
    {
        GameManager.Instance.Quit();
    }
}
