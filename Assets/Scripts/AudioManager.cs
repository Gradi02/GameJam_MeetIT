using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public sounds[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);

        foreach (sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.playOnAwake = s.playonawake;
            s.source.loop = s.loop;
        }
    }

    public void ChangeVolume(float change)
    {
        foreach (sounds s in sounds)
        {
            s.source.volume = change;
        }
    }

    public void Play(string name)
    {
        sounds s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " wasn't found!");
            return;
        }

        s.source.Play();
    }
}