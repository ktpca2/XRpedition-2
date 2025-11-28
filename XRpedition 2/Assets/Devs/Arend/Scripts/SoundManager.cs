using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> IjsbeerSounds;
    [SerializeField] private List<AudioClip> MammoetSounds;
    [SerializeField] private List<AudioClip> NeushoornSounds;
    [SerializeField] private List<AudioClip> OrangOetanSounds;
    [SerializeField] private List<AudioClip> TijgerSounds;

    // Tijdens de voiceover word er gevraagd of je die growl ook hoord en daarna komt de Run sound
    [SerializeField] private AudioSource IjsbeerSource;

    
    [SerializeField] private AudioSource MammoetSource;
    [SerializeField] private AudioSource NeushoornSource;

    // Na de voiceover word de orangutan sound afgespeeld en nadat je het geraden hebt word de chainsaw sound afgespeeld waarna je doorgaat naar de volgende ronde
    [SerializeField] private AudioSource OrangOetanSource;

    // howl howl growl
    [SerializeField] private AudioSource TijgerSource;


    [SerializeField] private AudioSource AmbienceSource;

    [SerializeField] private AudioResource PolarAmbience;
    [SerializeField] private AudioResource JungleAmbience;
    [SerializeField] private AudioResource AfricaAmbience;
    [SerializeField] private AudioResource WindAmbience;
    [SerializeField] private AudioResource ChainsawAmbience;



    //logica sounds

    // if State ijsbeer :
    // Ambience = PlayPolarAmbience()
    // PlayIjsbeerSound()
    // hint
    // growl
    // hint
    // run


    // if State Mammoet -->
    // Ambience = PlayWindAmbience()
    // "Ik heb een audiofragment gemaakt om je op weg te helpen, dus luister goed"
    // PlayMammoetSound()
    //


    // if State Neushoorn -->
    //  Ambience = PlayAfricaAmbience()
    // "De grootste bedreigingen voor dit dier zijn stroperij voor de hoorn, verlies van leefgebied en de illegale handel"
    // PlayNeushoornSound() 


    // if State OeranOetan -->
    // Ambience = PlayJungleAmbience()
    // "Weet jij welk dier dit is? Kijk en luister goed!"
    // PlayOeranOetanSound() 
    // Gelukkig is het tegenwoordig verboden om te jagen op orang-oetans. Dit gebeurd alleen nog illegaal en noemen we stroperij.
    // PlayChainsawSound()


    // if State Tijger -->
    // Ambience = PlayJungleAmbience()

    // Dit dier wordt bedreigd door stroperij en verlies van leefgebieden. Ook de afname van prooidieren en klimaatverandering vormen een bedreiging. 
    // howl
    // Volgensmij hoorde ik hem al, blijf goed luisteren!
    // howl
    // spawn 
    // growl




    public void PlayIjsbeerGrowl()
    {
        IjsbeerSource.PlayOneShot(IjsbeerSounds[0]);
    }

    public void PlayIjsbeerRun()
    {

    }

    public void PlayMammoetToetoet()
    { 
        MammoetSource.PlayOneShot(MammoetSounds[0]);
    }

    public void PlayNeushoornSound()
    {
        NeushoornSource.PlayOneShot(NeushoornSounds[0]);
    }

    public void PlayOeranOetanSound()
    {
        OrangOetanSource.PlayOneShot(OrangOetanSounds[0]);
    }

    public void PlayTijgerHowl()
    {
        TijgerSource.PlayOneShot(TijgerSounds[0]);
    }

    public void PlayTijgerGrowl()
    {
        TijgerSource.PlayOneShot(TijgerSounds[1]);
    }

    public void PlayChainsawSound()
    {
        AmbienceSource.resource = ChainsawAmbience;
        AmbienceSource.Play();
    }



    private void PlayPolarAmbience()
    {
        AmbienceSource.resource = PolarAmbience;
        AmbienceSource.Play();
    }

    private void PlayJungleAmbience()
    {
        AmbienceSource.resource = JungleAmbience;
        AmbienceSource.Play();
    }

    private void PlayAfricaAmbience()
    {
        AmbienceSource.resource = AfricaAmbience;
        AmbienceSource.Play();
    }

    private void PlayWindAmbience()
    {
        AmbienceSource.resource = WindAmbience;
        AmbienceSource.Play();
    }

    

    









}
