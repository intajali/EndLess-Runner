using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    private Camera mainCanmera;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        mainCanmera = Camera.main;
        offset = mainCanmera.transform.position - target.position;

    }
    // Update is called once per frame
    void LateUpdate()
    {
       mainCanmera.transform.position = Vector3.Lerp(mainCanmera.transform.position, new Vector3(target.position.x, 0, target.position.z) + offset, Time.deltaTime * 2);
    }
}
