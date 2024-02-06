using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float zoomSpeed = 20f;
    public float mouse2Speed = 200f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;
    public Vector2 zoomLimit;

    public bool usePan = true;
    public bool useZoom = true;
    public bool useMouse2 = true;

    void Update()
    {
        Vector3 pos = transform.position;

        if (useMouse2 && Input.GetMouseButton(2)) // Middle Mouse Button
        {
            pos.x -= Input.GetAxis("Mouse X") * mouse2Speed * Time.deltaTime;
            pos.z -= Input.GetAxis("Mouse Y") * mouse2Speed * Time.deltaTime;
        }
        else if (usePan)
        {
            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                pos.z += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            {
                pos.z -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            {
                pos.x -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey("r"))
            {
                pos.x = 0;
                pos.z = 0;
            }
        }

        if (useZoom)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                pos.y -= zoomSpeed * Time.deltaTime;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                pos.y += zoomSpeed * Time.deltaTime;
            }
        }

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, zoomLimit.x, zoomLimit.y);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
}
