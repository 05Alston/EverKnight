using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume){
        audioMixer.SetFloat("volume",volume);
    }
}
