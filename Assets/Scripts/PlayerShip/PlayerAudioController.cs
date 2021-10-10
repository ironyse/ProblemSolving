using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public AudioClip shieldUp;
    public AudioClip shootProjectile;

    AudioSource audioPlayer;

    #region Singleton
    private static PlayerAudioController _instance;
    public static PlayerAudioController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerAudioController>();
            }
            return _instance;
        }
    }
    #endregion

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void PlayShootAudio()
    {
        audioPlayer.PlayOneShot(shootProjectile);
    }

    public void PlayShieldUp()
    {
        audioPlayer.PlayOneShot(shieldUp);
    }
}
