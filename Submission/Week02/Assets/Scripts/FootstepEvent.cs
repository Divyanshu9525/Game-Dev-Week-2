using UnityEngine;

public class FootstepEvent : MonoBehaviour
{
    public AudioSource footstepAudio;
    public AudioClip[] footstepClips;       //array of audio
    public void Footstep()
    {
        int index = Random.Range(0, footstepClips.Length);      //makes random footstep noise
        footstepAudio.PlayOneShot(footstepClips[index]);
    }
}