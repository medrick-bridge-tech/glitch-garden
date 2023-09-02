using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _differentLevelsAudioClips;
    
    private AudioSource _audioSource;
    
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = PlayerPrefs.GetFloat("Volume");
    }

    void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = _differentLevelsAudioClips[level - 1];
        if (thisLevelMusic)
        {
            _audioSource.clip = thisLevelMusic;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }
}
