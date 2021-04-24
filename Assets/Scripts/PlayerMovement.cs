using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Transform target;
    // m/s
    [Rename("Move Speed (m/s)")]
    public float moveSpeed = 20.0f;
    private Vector3 motion;

    // Start is called before the first frame update
    void Start() {
        // var navMeshAgent = GetComponent<NavMeshAgent>();
        // navMeshAgent.destination = target.position;
    }

    // Update is called once per frame
    void Update() {
        motion = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        Debug.Log(motion);
        GetComponent<Rigidbody>().velocity = motion * moveSpeed;
        // transform.Translate(motion);
    }
}
