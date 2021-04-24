using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour {
    public Transform trackedObject;
    public float maxDistance = 10.0f;
    public float moveSpeed = 20.0f;
    public float updateSpeed = 10.0f;

    [Range(0, 10)]
    public float currentDistance = 5.0f;
    private string moveAxis = "Mouse ScrollWheel";
    public GameObject ahead;
    private MeshRenderer meshRenderer;
    public float hideDistance = 1.5f;
    // Start is called before the first frame update
    void Start() {
        // ahead = new GameObject("ahead");
        meshRenderer = trackedObject.gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void LateUpdate() {
        // adhead的位置在Player前面
        ahead.transform.position = trackedObject.position + trackedObject.forward * (maxDistance * 0.25f);

        // 通过鼠标滚轮来控制摄像机的跟随距离，并限制最大距离为maxDistance
        currentDistance += Input.GetAxisRaw(moveAxis) * moveSpeed * Time.deltaTime;
        currentDistance = Mathf.Clamp(currentDistance, 0, maxDistance);

        // 计算下次移动的目标点，移动包括z轴和y轴两个方向，
        // 可以形成距离Player越近，摄像机机位越低的效果
        Vector3 target = trackedObject.position - trackedObject.forward * (currentDistance + maxDistance * 0.5f) + Vector3.up * currentDistance;

        // transform.position = current + maxDistanceDelta
        float maxDistanceDelta = updateSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, maxDistanceDelta);

        // 将摄像机朝向ahead的位置
        transform.LookAt(ahead.transform);

        // 当摄像机和Player的距离小于hideDistance
        // 时隐藏Player的Mesh转换为第一人称视角
        meshRenderer.enabled = (currentDistance > hideDistance);
    }
}
