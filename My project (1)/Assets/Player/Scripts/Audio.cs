using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioClip footStep;
    [SerializeField] AudioClip slash;
    void Start()
    {
        _audio.volume = GameManager.volume;
        _audio.mute = !GameManager.muteBool;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSoundSlash()
    {
        _audio.loop = false;
        _audio.clip = slash;
        _audio.Play();
    }
    public void playSoundFootStep()
    {
        _audio.loop = true;
        _audio.clip = footStep;
        _audio.Play();
    }

}
