using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasteEffect : MonoBehaviour
{
    public Potion potion;
    [SerializeField] int what;

        void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Pot")
        {
            if(what == 2)
            {
                potion.spice++;
                SfxManager.SFXInstance.Audio.PlayOneShot(SfxManager.SFXInstance.drag);
            } 

            if(what == 4)
            {
                potion.net++;
                SfxManager.SFXInstance.Audio.PlayOneShot(SfxManager.SFXInstance.drag);
            }
        }
    }
    
}
