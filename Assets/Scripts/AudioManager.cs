using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public Slider volumeSlider;

    private bool isSoundPaused = false;
    private bool muted = false;
    // Start is called before the first frame update


    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        // Set the slider value based on the saved volume value
        float savedVolume = PlayerPrefs.GetFloat("volume", 0.5f);
        volumeSlider.value = savedVolume;

        FindObjectOfType<AudioManager>().PlaySound("MainTheme");
        AudioListener.pause = muted;
    }

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
        PlaySound("MainTheme");
        float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        SetVolume(savedVolume);
    }

    public bool IsAudioPlaying()
    {
        foreach(Sound s in sounds)
        {
            if(s.source.isPlaying)
                return true;
        }

        return false;
    }


    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                if (isSoundPaused)
                {
                    s.source.UnPause();
                    isSoundPaused = false;
                }
                else
                {
                    s.source.Play();
                }
            }
        }

    }

    public void StopSound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.source.Stop();
        }
    }

    public void PauseSound()
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying)
            {
                s.source.Pause();
                isSoundPaused = true;
            }

        }
    }

    public void ResumeSound()
    {
        foreach (Sound s in sounds)
        {
            if(isSoundPaused)
            {
                s.source.UnPause();
                isSoundPaused = false;
            }
        }
    }



    public void SetVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = volume;
        }
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void PauseAllSound()
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying)
            {
                s.source.Pause();
            }
        }
    }

    public void ResumeAllSound()
    {
        foreach (Sound s in sounds)
        {
            if (!s.source.isPlaying)
            {
                s.source.UnPause();
            }
        }
    }

        public void ToggleMute()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();

    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted? 1 : 0);
    }



}

