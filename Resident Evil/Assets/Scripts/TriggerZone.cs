using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private Shot targetShot;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetShot.CutToShot();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (targetShot.transform.position == Camera.main.transform.position) return;

        if (other.CompareTag("Player"))
        {
            targetShot.CutToShot();
        }
    }
}