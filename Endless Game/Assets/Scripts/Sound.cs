using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;


    public float volume;

    public bool loop;

    public AudioSource source;

}
