using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] music;

    public AudioSource musicSource;

    private void Start()
    {
        int index = Random.Range(0, this.music.Length);

        this.musicSource.clip = this.music[index];
        this.musicSource.Play();
    }
}