using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach it with an empty audio source to main camera.
//add music you like to list
public class MusicPlayer : MonoBehaviour
{
    public List<AudioClip> musicList;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        EventDispatcher.Instance.onIndexedEvent += PlayMusic;
    }
    private void OnDisable()
    {
        EventDispatcher.Instance.onIndexedEvent -= PlayMusic;
    }

    private void PlayMusic(int i)
    {
        if (i < musicList.Count)
        {
            audioSource.PlayOneShot(musicList[i]);
        }
    }
}
