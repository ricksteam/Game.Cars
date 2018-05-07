namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Custom_InteractableGrab : VRTK_InteractableObject
    {
        new AudioSource audio;
        AudioClip grab;
        AudioClip unGrab;

        // Use this for initialization
        void Start()
        {
            audio = gameObject.AddComponent<AudioSource>();
            audio.playOnAwake = false;
            grab = Resources.Load("Audio/Grab") as AudioClip;
            unGrab = Resources.Load("Audio/UnGrab") as AudioClip;
            this.InteractableObjectGrabbed += Custom_InteractableGrab_InteractableObjectGrabbed;
            this.InteractableObjectUngrabbed += Custom_InteractableGrab_InteractableObjectUngrabbed;
        }

        private void Custom_InteractableGrab_InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
        {
            audio.clip = grab;
            audio.Play();
        }

        private void Custom_InteractableGrab_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
        {
            audio.clip = unGrab;
            audio.Play();
        }
    }
}    
    
