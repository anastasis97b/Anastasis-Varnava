using System.Collections;
using UnityEngine;

namespace SojaExiles
{
    public class opencloseDoor : MonoBehaviour
    {
        public Animator openandclose; // Animator για την πόρτα
        public bool open;            // Κατάσταση αν είναι ανοιχτή ή κλειστή
        public bool isLocked = false; // Κατάσταση αν η πόρτα είναι κλειδωμένη
        public Transform Player;     // Αναφορά στον παίκτη
        public AudioClip openSound;  // Ήχος για άνοιγμα
        public AudioClip closeSound; // Ήχος για κλείσιμο
        public AudioClip lockedSound; // Ήχος για κλειδωμένη πόρτα
        private AudioSource audioSource; // AudioSource για αναπαραγωγή ήχων
      
        void Start()
        {
            open = false;
            audioSource = GetComponent<AudioSource>(); // Βεβαιώσου ότι υπάρχει AudioSource
        }

        void OnMouseOver()
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 15)
                {
                    if (isLocked) // Έλεγχος αν η πόρτα είναι κλειδωμένη
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            PlaySound(lockedSound); // Παίζει τον ήχο για κλειδωμένη πόρτα
                            Debug.Log("Η πόρτα είναι κλειδωμένη!");
                        }
                    }
                    else
                    {
                        if (!open)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                StartCoroutine(opening());
                            }
                        }
                        else
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                StartCoroutine(closing());
                            }
                        }
                    }
                }
            }
        }

        IEnumerator opening()
        {
            Debug.Log("Ανοίγει η πόρτα.");
            PlaySound(openSound); // Παίζει τον ήχο ανοίγματος
            openandclose.Play("Opening");
            open = true;
            yield return new WaitForSeconds(0.5f);
        }

        IEnumerator closing()
        {
            Debug.Log("Κλείνει η πόρτα.");
            PlaySound(closeSound); // Παίζει τον ήχο κλεισίματος
            openandclose.Play("Closing");
            open = false;
            yield return new WaitForSeconds(0.5f);
        }

        public void UnlockDoor()
        {
            isLocked = false; // Ξεκλείδωμα της πόρτας
            Debug.Log("Η πόρτα ξεκλείδωσε.");
        }

        private void PlaySound(AudioClip clip)
        {
            if (audioSource != null && clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
