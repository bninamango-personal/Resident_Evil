using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float backwardSpeed;
    private Vector2 velocity;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed;

    [Header("Direction")]
    [SerializeField] private Transform head;
    private Vector3 direction;

    [Header("Animator")]
    private Animator animator;

    [Header("Interaction")]
    [SerializeField] private LayerMask doorLayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        direction = head.forward;

        Rotation();

        Interaction();
    }

    private void Movement()
    {
        float vertical = velocity.x = Input.GetAxis("Vertical");

        float speed = vertical * ((vertical > 0) ? forwardSpeed : backwardSpeed);

        transform.position += direction * speed * Time.deltaTime;

        animator.SetFloat("SpeedMovement", vertical);
    }

    private void Rotation()
    {
        float horizontal = velocity.y = Input.GetAxis("Horizontal");

        float speed = horizontal * rotationSpeed;

        transform.Rotate(Vector3.up * speed);

        animator.SetBool("IsRotated", (horizontal != 0 && velocity.x == 0));

        animator.SetFloat("SpeedRotation", horizontal);
    }

    private void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hitInfo;

            Ray ray = new Ray(head.position, head.forward);

            if (Physics.Raycast(ray, out hitInfo, 1f, doorLayer))
            {
                Door door = hitInfo.collider.GetComponent<Door>();

                door.Open(transform);
            }
        }
    }

    #region Gizmos
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(head.position, direction);
    }
    #endregion
}