using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public Transform trackedObject;
    public float updateSpeed = 3.0f;
    public Vector3 trackingOffset;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start() {
        offset = trackingOffset;
        // 获取Tracker和目标之间位移
        offset.z = transform.position.z - trackedObject.position.z;
    }

    // LateUpdate保证Tracker的移动在Player移动完成之后
    void LateUpdate() {
        Vector3 target = trackedObject.position + offset;
        float maxDistanceDelta = updateSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, maxDistanceDelta);
    }
}
