using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringNote : MonoBehaviour
{
    
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sound.Play();
        }
    }
}
