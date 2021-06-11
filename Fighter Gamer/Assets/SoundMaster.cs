using UnityEngine;

public class SoundMaster : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips = new AudioClip[8];
    public void PlaySound(byte soundID, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(clips[soundID], position);
    }
}
