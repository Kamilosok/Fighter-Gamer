using UnityEngine;

public class SoundMaker : MonoBehaviour
{
    [SerializeField]
    private AudioClip sound;

    public void playSound()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        //Soundmaster / w każdym obiekcie dźwięk
    }
}
