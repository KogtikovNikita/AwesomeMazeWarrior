using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

    [SerializeField]
    private AudioSource coindAudioSource;

    void Awake()
    {
        makeInstance();
    }

    void makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void PlayCoinSound()
    {
        coindAudioSource.Play();
    }
}
