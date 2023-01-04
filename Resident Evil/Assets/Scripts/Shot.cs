using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    private Vector3 FocalPoint
    {
        get => transform.position + offset;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, FocalPoint);
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
            CutToShot();
    }

    public void CutToShot()
    {
        transform.LookAt(FocalPoint);

        Camera.main.transform.localPosition = transform.position;
        Camera.main.transform.localRotation = transform.rotation;
    }
}