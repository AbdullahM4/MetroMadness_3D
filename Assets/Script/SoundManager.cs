
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource soundFXobject;

    private void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform,float volume)
    {
        AudioSource audioSource = Instantiate(soundFXobject, spawnTransform.position, Quaternion.identity);
        audioSource.clip= audioClip;
        audioSource.volume=volume;
        audioSource.Play();
        float clipLength= audioSource.clip.length;
        Destroy(audioSource.gameObject);
    }
}