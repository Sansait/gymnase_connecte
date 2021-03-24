using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrack : MonoBehaviour
{
    public AudioClip[] musicNotes;

    private AudioSource source;

    private int trackStep;
    // Start is called before the first frame update
    void Start()
    {
        trackStep = 0;
        source = this.GetComponent<AudioSource>();
    }

    public void PlayNextNote()
    {
        source.clip = musicNotes[trackStep%musicNotes.Length];
        source.Play();
        Debug.Log(trackStep);
        trackStep++;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(trackStep);
        if (other.CompareTag("Player"))
        {
            PlayNextNote();
        }
    }
}
