using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    [Header("Player")]
    public GameObject playerPrefab;
    public CameraFollow follow;

    [Header("Generator")]
    public LevelGenerator generator;

    [Header("UI")]
    public GameObject respawn;

    void Awake()
    {
        current = this;
    }

    // =====================================
    void Start()
    {
        this.respawn.SetActive(false);
        this.generator.Generate();

        this.MocoStart(this.generator.playerStart);
    }

    // =====================================
    private void MocoStart(Transform start)
    {
        this.respawn.SetActive(false);
        var go = Instantiate(this.playerPrefab, start.position, Quaternion.identity);

        this.follow.target = go.transform;
    }

    // =====================================
    public void OnPlayerDeath()
    {
        this.respawn.SetActive(true);
    }

    // =====================================
    public void PlayerRespawn()
    {
        this.MocoStart(this.generator.playerStart);
    }

    public void ExitGame()
    {
        Debug.LogError("LOAD MENU!");
    }
}