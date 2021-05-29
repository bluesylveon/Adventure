using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button SaveButton;
    [SerializeField] private Button EraseButton;
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
        SaveFile.Instance.Save();
        Thread.Sleep(1000);
        SaveButton.interactable = true;
    }

    private void HandleResumeClicked()
    {
        GameManager.Instance.TogglePause();
    }
}
