using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform inside;
    [SerializeField] private Transform outside;
    private bool onInside;

    //[Header("Video")]
    //[SerializeField] private VideoClip clip;
    //[SerializeField] private Animation anim;

    private void Start()
    {
        inside.gameObject.SetActive(false);
        outside.gameObject.SetActive(false);
    }

    private void Update()
    {
        //if (VideoManager.Instance.Ended)
        //{
        //    anim.Play();
        //}
    }

    public void Open(Transform player)
    {
        Transform aux = (onInside) ? inside : outside;

        player.position = aux.position;
        player.rotation = aux.rotation;

        onInside = !onInside;

        //VideoManager.Instance.Play(clip);
    }
}