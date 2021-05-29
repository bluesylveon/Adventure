using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private PauseMenu pauseMenu;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GameManager.Instance.onGameStateChange.AddListener(HandleGameStateChange);
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void HandleGameStateChange(GameManager.GameState current, GameManager.GameState previous)
    {
        pauseMenu.gameObject.SetActive(current == GameManager.GameState.Pause);
    }
}
