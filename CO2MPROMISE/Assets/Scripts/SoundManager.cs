using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public static SoundManager Instance;
    
    
    public AudioClip backgroundMusic;
    AudioSource Background;

    public AudioClip farmPlacement;
    public AudioClip CO2Placement;

    public AudioClip hmmSound;
    public AudioClip coughSound;

    
     AudioSource hmmSource;
    
    AudioSource coughSource;

    AudioSource farmPlace;
    AudioSource CO2Place;
    
    void Awake()
    {
        Instance =this;
         hmmSource = GetComponent<AudioSource>();
             coughSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        Background = GetComponent<AudioSource>();
        farmPlace = GetComponent<AudioSource>();
        CO2Place=GetComponent<AudioSource>();
        
        if(backgroundMusic!=null)
        {
            Background.clip = backgroundMusic;

        }

       
    }
    void Update()
    {
        if (GameManager.isWoodChosen==true&& ResourceManager.Instance.CO2!=30 && ResourceManager.Instance.CO2!=35 )
        {
            
          
        
            CO2Place.clip = CO2Placement;
            CO2Place.PlayOneShot(CO2Place.clip);
        }

        if(GameManager.isFarmChosen==true && ResourceManager.Instance.CO2!=70 && ResourceManager.Instance.CO2!=75 )
        {
            farmPlace.clip = farmPlacement;
            farmPlace.PlayOneShot(farmPlace.clip);
        }
        //   if (ResourceManager.Instance.CO2<=30 && GameManager.Instance.playCoughSound==true)
        // {
           
        //     return;
        // }
       

    }
    public void MuteSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
    public void CoughSound()
    {
        if(ResourceManager.Instance.Co2==70)
        {
            coughSource.clip = coughSound;
            coughSource.PlayOneShot(coughSource.clip);  
        }
         if(ResourceManager.Instance.Co2==75)
        {
            coughSource.clip = coughSound;
            coughSource.PlayOneShot(coughSource.clip);  
        }
    }
    public void HmmSound()
    {
        if (ResourceManager.Instance.Co2 == 30)
        {
            hmmSource.clip = hmmSound;
            hmmSource.PlayOneShot(hmmSource.clip);
        }
        if (ResourceManager.Instance.Co2 == 35)
        {
            hmmSource.clip = hmmSound;
            hmmSource.PlayOneShot(hmmSource.clip);
        }
    }
}
