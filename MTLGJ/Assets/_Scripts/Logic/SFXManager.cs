using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance { get; private set; }
    
    [SerializeField] AudioSource mainSource;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(instance);
        else instance = this;
    }
    public void PlaySFX(AudioClip clip)
    {
        mainSource.clip = clip;
        mainSource.Play();
    }
}
