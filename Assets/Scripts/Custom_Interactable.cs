namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class Custom_Interactable : VRTK_InteractableObject
    {
        new AudioSource audio;
        public Transform PlayRoom;
        public Text messageTxt;

        public float timer;
       // public Transform playArea;
        public VRTK_BasicTeleport teleport;
        bool teleporting;

        // Use this for initialization
        void Start()
        {
            audio = gameObject.AddComponent<AudioSource>();
            audio.playOnAwake = false;
            audio.clip = Resources.Load("Audio/Press") as AudioClip;

            this.InteractableObjectTouched += Custom_Interactable_InteractableObjectTouched;
        }

        private void Custom_Interactable_InteractableObjectTouched(object sender, InteractableObjectEventArgs e)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            messageTxt.text = "Teleporting to the game room! Please wait!";
            if(teleporting == false)
            {
                StartCoroutine(teleportOverTime());
            }
        }

        IEnumerator teleportOverTime()
        {        
            teleporting = true;
            yield return new WaitForSeconds(timer);
            teleport.ForceTeleport(PlayRoom.position, PlayRoom.rotation);
            messageTxt.text = "Touch to play";
            teleporting = false;
            LineDrawer.ready = true;
        }
    }
}    
    
