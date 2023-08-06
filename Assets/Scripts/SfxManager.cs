using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip click;

    public AudioClip drag;

    public static SfxManager SFXInstance;
   
   
   void Awake()
   {
    if(SFXInstance != null && SFXInstance != this)
    {
        Destroy(this.gameObject);
        return;
    }


    SFXInstance = this;
    DontDestroyOnLoad(this);
   }

   public void playButton()
   {
        SfxManager.SFXInstance.Audio.PlayOneShot(SfxManager.SFXInstance.click);

   }
}
