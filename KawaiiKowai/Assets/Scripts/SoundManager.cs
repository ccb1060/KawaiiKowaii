using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] List<AudioClip> clips;

    [SerializeField] List<AudioSource> sources = new List<AudioSource>();

    [SerializeField] int scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < clips.Count; i++)
        {
            sources.Add(gameObject.AddComponent<AudioSource>());
            sources[i].clip = clips[i];
        }
        switch (scene)
        {
            //Title Screen
            case 0:
                sources[13].Play();
                sources[13].loop = true;
                sources[4].PlayDelayed(2.0f);
                break;

            //Main Screen
            case 1:
                sources[14].Play();
                sources[14].volume = .5f;
                sources[14].loop = true;

                break;
            
            //Result Screen
            case 2:
                sources[15].Play();
                sources[15].loop = true;
                break;
        }
    }

    public void SoundButton()
    {
        sources[2].Play();
    }

    public void SoundOutOfTime()
    {
        sources[7].Play();
    }

    public void Eating()
    {
        sources[3].Play();
    }

    public void Kawaii()
    {
        sources[8].Play();
    }

    public void Excellent()
    {
        sources[9].Play();

    }

    public void Good()
    {
        sources[10].Play();

    }

    public void Normal()
    {
        sources[11].Play();

    }

    public void Kowai()
    {
        sources[12].Play();

    }
}
