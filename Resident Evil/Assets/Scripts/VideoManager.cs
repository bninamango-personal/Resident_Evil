using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer video;

    public static VideoManager Instance { get; private set; }

    public bool Ended
    {
        get => (video.playbackSpeed == video.playbackSpeed / 10.0f);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        video = GetComponent<VideoPlayer>();
    }

    public void Play(VideoClip clip)
    {
        video.clip = clip;

        video.Play();
    }

    public void Stop(VideoClip clip)
    {
        video.clip = clip;

        video.Stop();
    }
}