using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togglepanel : MonoBehaviour
{
    bool ison=false;
    [SerializeField] GameObject informationpanel;
    public void Togglepanel(){
        if(ison){
            informationpanel.SetActive(false);
            ison = false;
        }
        else{
            informationpanel.SetActive(true);
            ison = true;
        }
    }
    public AudioSource audioSource;
    private bool isPlaying = false;
    public void ToggleAudio()
    {
        if (isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
        isPlaying = !isPlaying;
    }
    public void untracked()
    {
        audioSource.Stop();
        isPlaying=false;
    }
}
