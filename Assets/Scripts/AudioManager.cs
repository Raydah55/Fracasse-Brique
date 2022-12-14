using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.speed;
            s.source.loop = s.loop;
        }
    }

    void Start(){
        Play("music");
    }

    public void Play (string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null && !s.source.isPlaying){
            s.source.Play();
        }
    }

    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying){
            s.source.Stop();
        }
    }
}
