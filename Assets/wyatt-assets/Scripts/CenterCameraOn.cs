using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCameraOn : MonoBehaviour
{
    // Start is called before the first frame update
    public float zoom = -10; //
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, zoom);
    }
}
