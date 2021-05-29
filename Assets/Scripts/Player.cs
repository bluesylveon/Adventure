using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _jumpForce;

    private Animator _anim;
    private Rigidbody2D rb;
    private Camera _camera;

    private Vector3 _offset;
    public int collectedItems = 0;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        _offset = _camera.transform.position;
        _anim = GetComponent<Animator>();
        _anim.updateMode = AnimatorUpdateMode.AnimatePhysics;
        GameManager.Instance.onGameStateChange.AddListener(HandleGameStateChange);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);
        if (Time.timeScale != 0.0f)
            Move();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.velocity = Vector2.up * _jumpForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            ++collectedItems;
        }
        else if (collision.CompareTag("Door"))
        {
            int currentLevel = SaveFile.Instance.GetLevelData()._LevelNumber;
            if (currentLevel == 2)
            {
                GameManager.Instance.Quit();
                return;
            }

            int nextLevel = currentLevel + 1;
            SaveFile.Instance.SetNextLevel(nextLevel);
            GameManager.Instance.LoadLevel("Level" + nextLevel);
        }
    }

    private void HandleGameStateChange(GameManager.GameState current, GameManager.GameState previous)
    {
        if (current == GameManager.GameState.Pause)
            SaveFile.Instance.SetPlayer(this);
    }

    void Move()
    {
        moveInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(moveInput, 0) * Time.deltaTime * 10);

        if (moveInput > 0)
            _anim.Play(isGrounded ? "Right" : "IdleRight");
        else if (moveInput < 0)
            _anim.Play(isGrounded ? "Left" : "IdleLeft");
        else
            _anim.Play("IdleDown");
        _camera.transform.position = transform.position + _offset;
    }
}
