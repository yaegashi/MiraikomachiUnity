using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject cameraObject;
    private GameObject miraiObject;
    private GameObject baseObject;

    public float rotateSpeed = 0.01f;
    public float baseHeight = 1.378f;
    public float baseAngleMin = -90f;
    public float baseAngleMax = +60f;
    public float baseDistanceMin = 1f;
    public float baseDistanceMax = 10f;

    private Vector3 lastMousePosition;
    private Vector3 newAngle = new Vector3(0, 0, 0);
    private Vector3 newDistance = new Vector3(0, 0, 3);
    private Vector3 newPos = new Vector3(0, 0, 0);

    void Start()
    {
        cameraObject = GameObject.Find("Camera");
        miraiObject = GameObject.Find("mirai2019_dance");
        baseObject = GameObject.Find("Camera Base");
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            newAngle = baseObject.transform.localEulerAngles;
            if (newAngle.x > 180f) { newAngle.x -= 360f; }
            newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) * rotateSpeed;
            newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * rotateSpeed;
            newAngle.x = System.Math.Max(newAngle.x, baseAngleMin);
            newAngle.x = System.Math.Min(newAngle.x, baseAngleMax);
            baseObject.transform.localEulerAngles = newAngle;
        }
        lastMousePosition = Input.mousePosition;

        newDistance = cameraObject.transform.localPosition;
        newDistance.z -= Input.mouseScrollDelta.y;
        newDistance.z = System.Math.Max(newDistance.z, baseDistanceMin);
        newDistance.z = System.Math.Min(newDistance.z, baseDistanceMax);
        cameraObject.transform.localPosition = newDistance;

        newPos = miraiObject.transform.position;
        newPos.y = baseHeight;
        baseObject.transform.position = newPos;
    }
}
