using UnityEngine;
using System.Collections;

public class SoundForObstacles : MonoBehaviour {

    // Use this for initialization

    public AudioClip[] ObSounds;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (ObstacleMove.barrelRoll == true || ObstacleMove4.Barrel2Roll == true)
        {
            PlaySoundBarrel(1);
        }

        if (ObstacleMove2.Log2Drop == true || ObstacleMove3.Log3Drop == true || Obstacle1L2.Log1Drop == true)
        {
            PlaySoundLog(0);
        }

        if (Obstacle2L2.cageDrop == true)
        {
            PlaySoundcage(2);
        }

        if (Obstacle3L2.speared == true || Obstacle4L2.speared2 == true)
        {
            PlaySoundSpear(3);
        }
	
	}

    void PlaySoundLog(int clip)
    {
        AudioSource au = GetComponent<AudioSource>();
        if (!au.isPlaying)
        {
            au.clip = ObSounds[clip];

            if (Obstacle1L2.Log1Drop == true)
            au.PlayDelayed(2f);

            if (ObstacleMove2.Log2Drop == true)
                au.PlayDelayed(1.2f);

            if (ObstacleMove3.Log3Drop == true)
                au.PlayDelayed(1.5f);

            //au.Play();
        }
    }

    void PlaySoundSpear(int clip)
    {
        AudioSource au = GetComponent<AudioSource>();
        if (!au.isPlaying)
        {
            au.clip = ObSounds[clip];
            au.PlayDelayed(0.1f);
            au.volume = 0.5f;
            //au.Play();
        }
    }

    void PlaySoundcage(int clip)
    {
        AudioSource au = GetComponent<AudioSource>();
        if (!au.isPlaying)
        {
            au.clip = ObSounds[clip];
            au.PlayDelayed(0.2f);
            //au.Play();
        }
    }


    void PlaySoundBarrel(int clip)
    {
        AudioSource au = GetComponent<AudioSource>();
        if (!au.isPlaying)
        {
            au.clip = ObSounds[clip];
            au.PlayDelayed(0.0f);
            //au.Play();
        }
    }
}
