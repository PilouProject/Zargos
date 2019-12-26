using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float rotateSpeed = 2f;
    public float panSpeed = 100f;
    public float scrollSpeed = 10f;

    private float panBorder = 20f;
    private Vector3 pos;
    private Vector3 posBonderies;
    private float mouseX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        posBonderies = transform.position;
        pos = Vector3.zero;

        if (Input.GetKey("z") || Input.mousePosition.y >= Screen.height - panBorder)
        {
            pos += Vector3.forward * panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorder)
        {
            pos -= Vector3.forward * panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorder)
        {
            pos += Vector3.right * panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("q") || Input.mousePosition.x <= panBorder)
        {
            pos -= Vector3.right * panSpeed * Time.deltaTime;
        }

        if (Input.GetMouseButton(1))
        {
            if (Input.mousePosition.x != mouseX)
            {
                var cameraRotationY = (Input.mousePosition.x - mouseX) * rotateSpeed * Time.deltaTime;
                transform.Rotate(0, cameraRotationY, 0, Space.World);
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100 * Time.deltaTime;

        posBonderies.x = Mathf.Clamp(posBonderies.x, -700, 700);
        posBonderies.y = Mathf.Clamp(posBonderies.y, 30, 500);
        posBonderies.z = Mathf.Clamp(posBonderies.z, -700, 700);


        transform.position = posBonderies;
        transform.Translate(pos, Space.Self);

        //transform.localPosition = pos;
        mouseX = Input.mousePosition.x;
    }
}
