using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _door;
    [SerializeField] private Collectible[] collectibles;
    private bool isDoorOpen;
    private Player player;

    void Start()
    {
        LevelData levelData = SaveFile.Instance.GetLevelData();
        PlayerData playerData = SaveFile.Instance.GetPlayer();
        player = Instantiate(_player, new Vector3(playerData._Position.x, playerData._Position.y, 0), Quaternion.identity);
        isDoorOpen = levelData._IsDoorOpen;
        _door.SetActive(isDoorOpen);
        GameManager.Instance.onGameStateChange.AddListener(HandleGameStateChange);

        for (int i = 0; i < collectibles.Length; i++)
            collectibles[i]._id = i;
    }

    private void HandleGameStateChange(GameManager.GameState current, GameManager.GameState previous)
    {
        if (current == GameManager.GameState.Pause)
            SaveFile.Instance.SetLevelData(0, player.collectedItems, isDoorOpen, collectibles);
    }

    void FixedUpdate()
    {
        if (!isDoorOpen && player.collectedItems == collectibles.Length)
        {
            isDoorOpen = true;
            _door.SetActive(true);
            _door.GetComponent<AudioSource>().Play();
        }

        if (player.transform.position.y < -15)
            Respawn();
    }

    void Respawn()
    {
        player.GetComponent<AudioSource>().Play();
        player.transform.position = new Vector3(0, 0, 0);
    }
}
