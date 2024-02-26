using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private Audio[] audioClips;
    
    [System.Serializable]
    private struct Audio {
        public SoundType type;
        public AudioClip audioClip;
    }
    
    private Dictionary<SoundType, AudioSource> sounds = new Dictionary<SoundType, AudioSource>();

    public bool isMuted = false;

    public bool IsMuted {
        get => isMuted;
        set => isMuted = value;
    }
    
    protected override void Awake() {
        base.Awake();
        
        GetSounds();
    }
    
    private void GetSounds() {
        foreach (Audio it in audioClips)
        {
            sounds.Add(it.type, GetAudioSource(it.audioClip));
        }
    }
    
    private AudioSource GetAudioSource(AudioClip clip) {
        GameObject tmp = new GameObject("AudioObject");
        tmp.transform.SetParent(transform);
        AudioSource source = tmp.AddComponent<AudioSource>();
        source.clip = clip;
        source.playOnAwake = false;
        return source;
    }

    public void Play(SoundType type) {
        if (isMuted)
        {
            return;
        }
        
        sounds[type].Play();
    }

    public void Mute(SoundType type) {
        sounds[type].Stop();
    }

    public void MuteAll() {
        isMuted = true;
        foreach (var item in sounds) {
            item.Value.Stop();
        }
    }
}