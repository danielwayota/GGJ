using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    [Header("Player")]
    public GameObject playerPrefab;
    public CameraFollow follow;

    [Header("Generator")]
    public LevelGenerator generator;

    [Header("UI")]
    public GameObject respawnUI;

    public UICounter deathsCounters;
    public UICounter photosCounters;

    private int deaths;
    private int photos;

    // =====================================
    void Awake()
    {
        current = this;

        this.deaths = 0;
        this.photos = 0;

        this.deathsCounters.Write(this.deaths);
        this.photosCounters.Write(this.photos);
    }

    // =====================================
    void Start()
    {
        this.respawnUI.SetActive(false);
        this.generator.Generate();

        this.MocoStart(this.generator.playerStart);
    }

    // =====================================
    private void MocoStart(Transform start)
    {
        this.respawnUI.SetActive(false);
        var go = Instantiate(this.playerPrefab, start.position, Quaternion.identity);

        this.follow.target = go.transform;
    }

    // =====================================
    public void OnPhoto()
    {
        this.photos++;
        this.photosCounters.Write(this.photos);
    }

    // =====================================
    public void OnPlayerDeath()
    {
        this.deaths++;
        this.deathsCounters.Write(this.deaths);

        this.respawnUI.SetActive(true);
    }

    // =====================================
    public void PlayerRespawn()
    {
        this.MocoStart(this.generator.playerStart);
    }

    // =====================================
    public void ExitGame()
    {
        Loading.LoadScene(SceneNames.MENU);
    }
}