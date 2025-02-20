using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static bool mcExists;

    public AudioSource[] musicTracks;

    public int currentTrack  = 0;

    public bool musicCanPlay = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (musicCanPlay)
        {
            if (!musicTracks[currentTrack].isPlaying)
            {
                musicTracks[currentTrack].Play();
            }
        }
        else
        {
            musicTracks[currentTrack].Stop();   
        }
    }

    public void SwitchTrack(int newTrack)
    {
        musicTracks[currentTrack].Stop();

        currentTrack = newTrack;

        musicTracks[currentTrack].Play();
    }
}
