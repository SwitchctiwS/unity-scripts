using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class DelayedCameraMovement : MonoBehaviour
{
    public GameObject followTarget;
    public float moveSpeed = 1;
    public float cameraScale = 1;

    Camera playerCam;

    private Vector3 targetPos;

    void Start()
    {
        playerCam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        //Set scale of camera so that it always appears the same size regardless of screen size.
        playerCam.orthographicSize = ((Screen.height / 100.0f) / Mathf.Pow(cameraScale, 2));

        //Camera follows player with slight delay.
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, playerCam.transform.position.z);
        playerCam.transform.position = Vector3.Lerp(playerCam.transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
