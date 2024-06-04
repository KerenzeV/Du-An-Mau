using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    // Singleton instance
    public static AudioManager Instance { get; private set; }

    // Dictionary to hold audio clips
    private Dictionary<string, AudioClip> audioClips;

    // Audio source component
    private AudioSource audioSource;

    // Initialize the singleton and audio source
    private void Awake()
    {
        // Ensure only one instance of the AudioManager exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        LoadAudioClips();
    }

    // Load audio clips into the dictionary
    private void LoadAudioClips()
    {
        audioClips = new Dictionary<string, AudioClip>();

        // Load your audio clips here
        // Example:
        audioClips["BackgroundMusic"] = Resources.Load<AudioClip>("Audio/BackgroundMusic");
        audioClips["JumpSound"] = Resources.Load<AudioClip>("Audio/JumpSound");
        // Add more audio clips as needed
    }

    // Play an audio clip by name
    public void PlayAudio(string clipName)
    {
        if (audioClips.ContainsKey(clipName))
        {
            audioSource.clip = audioClips[clipName];
            audioSource.Play();
        }
        else
        {
            Debug.LogError($"Audio clip '{clipName}' not found!");
        }
    }

    // Stop the currently playing audio
    public void StopAudio()
    {
        audioSource.Stop();
    }

    // Play an audio clip at a specific point in the world
    public void PlayAudioAtPoint(string clipName, Vector3 position)
    {
        if (audioClips.ContainsKey(clipName))
        {
            AudioSource.PlayClipAtPoint(audioClips[clipName], position);
        }
        else
        {
            Debug.LogError($"Audio clip '{clipName}' not found!");
        }
    }
}