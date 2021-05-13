using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer playa = null;

    void Awake()
    {
        if (playa != null)
        {
            Destroy(gameObject);
        }
        else
        {
            playa = this;
        }

        GameObject.DontDestroyOnLoad(gameObject);
    }
}
