using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameManager gameManager;
    public GameObject player;
    private Vector3 offset;
    private Camera cam;
    private float targetZoom;
    private float zoomFactor = 1500;
    private float zoomLerpSpeed = 10;
    
    void Start() {
        offset = transform.position - player.transform.position;
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    void Update() {

        if (gameManager.isScenePaused == false) {
            float scrollData = Input.GetAxisRaw("Scroll");

            targetZoom -= scrollData / zoomFactor;
            targetZoom = Mathf.Clamp(targetZoom, 6f, 18f);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
        }
    }
    
    void LateUpdate() {
        transform.position = player.transform.position + offset;
    }
}
