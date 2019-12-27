using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float rotateSpeed = 2f;
    public float panSpeed = 100f;
    public float scrollSpeed = 10f;

    private float _panBorder = 20f;
    private Vector3 _pos;
    private Vector3 _posBonderies;
    private float _mouseX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _posBonderies = transform.position;
        _pos = Vector3.zero;

        if (Input.GetKey("z") || Input.mousePosition.y >= Screen.height - _panBorder)
        {
            _pos += Vector3.forward * panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= _panBorder)
        {
            _pos -= Vector3.forward * panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - _panBorder)
        {
            _pos += Vector3.right * panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("q") || Input.mousePosition.x <= _panBorder)
        {
            _pos -= Vector3.right * panSpeed * Time.deltaTime;
        }

        if (Input.GetMouseButton(1))
        {
            if (Input.mousePosition.x != _mouseX)
            {
                var cameraRotationY = (Input.mousePosition.x - _mouseX) * rotateSpeed * Time.deltaTime;
                transform.Rotate(0, cameraRotationY, 0, Space.World);
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        _pos.y -= scroll * scrollSpeed * 100 * Time.deltaTime;

        _posBonderies.x = Mathf.Clamp(_posBonderies.x, -700, 700);
        _posBonderies.y = Mathf.Clamp(_posBonderies.y, 30, 500);
        _posBonderies.z = Mathf.Clamp(_posBonderies.z, -700, 700);


        transform.position = _posBonderies;
        transform.Translate(_pos, Space.Self);

        //transform.localPosition = _pos;
        _mouseX = Input.mousePosition.x;
    }
}
