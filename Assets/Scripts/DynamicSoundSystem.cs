using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSoundSystem : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips_stoneFloor;
    public List<AudioClip> audioClips_woodenFloor;

    private float currentVelocity = 0;
    private Vector3 lastPosition;

    private bool isPlayingSound = false;
    private string lastCollisionTag = "StoneFloor";

    private IEnumerator currentEnumerator;

    private CharacterController characterController;

   

    private bool waitUntillGrounded = false;

    public void OnJumpStarted()
    {
        if (isPlayingSound == true)
        {
            if (currentEnumerator != null)
                StopCoroutine(currentEnumerator);
            isPlayingSound = false;
        }

        waitUntillGrounded = true;
    }


    private void Start()
    {
        lastPosition = transform.position;
        characterController = FindObjectOfType<CharacterController>();
    }

    private void FixedUpdate()
    {
        currentVelocity = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;

        if (waitUntillGrounded  &  characterController.isGrounded)
        {
            waitUntillGrounded = false;
        }
    }


    private void OnTriggerStay(Collider collider)
    {
        // Остановка
        if (isPlayingSound == true   &   currentVelocity <= 0.0001f)
        {
            if (currentEnumerator != null)
                StopCoroutine(currentEnumerator);
            isPlayingSound = false;
        }

        // Начало движения
        if (isPlayingSound == false   &   currentVelocity > 0.0001f  &  !waitUntillGrounded)
        {
            if (collider.gameObject.tag == "StoneFloor")
            {
                IEnumerator enumerator = ShuffledPlaying(audioClips_stoneFloor);
                StartCoroutine(enumerator);
                currentEnumerator = enumerator;
            }
            if (collider.gameObject.tag == "WoodenFloor")
            {
                IEnumerator enumerator = ShuffledPlaying(audioClips_woodenFloor);
                StartCoroutine(enumerator);
                currentEnumerator = enumerator;
            }

            isPlayingSound = true;
        }

        // Изменилась поверхность пола
        if ((collider.gameObject.tag == "StoneFloor"  | collider.gameObject.tag == "WoodenFloor")   &   lastCollisionTag != collider.gameObject.tag)
        {
            StopCoroutine(currentEnumerator);
            
            if (collider.gameObject.tag == "StoneFloor")
            {
                IEnumerator enumerator = ShuffledPlaying(audioClips_stoneFloor);
                StartCoroutine(enumerator);
                currentEnumerator = enumerator;
            }
            if (collider.gameObject.tag == "WoodenFloor")
            {
                IEnumerator enumerator = ShuffledPlaying(audioClips_woodenFloor);
                StartCoroutine(enumerator);
                currentEnumerator = enumerator;
            }

            lastCollisionTag = collider.gameObject.tag;
            isPlayingSound = true;
        }


    }




    public IEnumerator ShuffledPlaying(List<AudioClip> audioClips)
    {
        while (true)
        {
            int i = Random.Range(0, audioClips.Count);
            AudioClip newAudioClip = audioClips[i];

            audioSource.clip = newAudioClip;
            audioSource.Play();

            yield return new WaitForSeconds(newAudioClip.length);
        }
    }


}
