using NUnit.Framework;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class WalkieTalkieRespawn : MonoBehaviour
{
    [SerializeField] private GameObject respawnPoint;
    [SerializeField] private List<AudioResource> throwAudios;

    [SerializeField] private AudioSource aud;

    void Start()
    {
       
    }


    private void OnTriggerEnter(Collider other)
    {
        aud.resource = throwAudios[Random.Range(0, throwAudios.Count)];
        //aud.Play();
        transform.position = respawnPoint.transform.position;
    }
}
