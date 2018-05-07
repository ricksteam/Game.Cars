namespace VRTK.Examples
{
    using UnityEngine;

    public class CustomDropZone : VRTK_SnapDropZone
    {
        new public event SnapDropZoneEventHandler ObjectEnteredSnapDropZone;
        missingParts missingParts;
        new AudioSource audio;

        [Header("New Tag on SNAP")]
        public string newTag;

        void Start()
        {
            missingParts = GetComponentInParent<missingParts>();
            this.ObjectSnappedToDropZone += CustomDropZone_ObjectSnappedToDropZone;
            audio = GetComponent<AudioSource>();
            if(audio == null)
            {
                audio = gameObject.AddComponent<AudioSource>();
                audio.playOnAwake = false;
                audio.clip = Resources.Load("Audio/SnapSound") as AudioClip;
            }         
        }

        private void CustomDropZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            e.snappedObject.transform.tag = "objects";
            missingParts.addParts(e.snappedObject.transform);
            Destroy(gameObject, 1.5f);
        }
    }
}

