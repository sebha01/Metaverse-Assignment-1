using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    private MusicController theMC;

    [SerializeField] public int newTrack = 0;

    public bool switchOnStart = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theMC = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicController>();

        if (switchOnStart)
        {
            theMC.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Character")
        {
            theMC.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }
}
