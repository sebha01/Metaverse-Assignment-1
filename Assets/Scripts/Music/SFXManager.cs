using UnityEngine;

public class SFXManager : MonoBehaviour
{
    //Character
    public AudioSource characterHurt;
    public AudioSource characterDeath;
    public AudioSource characterAtk;
    public AudioSource characterWalk;
    public AudioSource useHealthPotion;

    //Dialogues and NPC
    public AudioSource dialogueSwitch;
    public AudioSource dialogueEnd;

    //Orcs
    public AudioSource orcAtk;
    public AudioSource orcDead;
    public AudioSource orcHurt;

    //Slimes
    public AudioSource slimeAtk;
    public AudioSource slimeDeath;
    public AudioSource slimeHurt;

    private static bool sfxManExists;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!sfxManExists)
        {
            sfxManExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
