using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 startPosition;

    private new Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            float positionX = camera.ScreenToWorldPoint(Input.mousePosition).x - startPosition.x;
            float positionY = camera.ScreenToWorldPoint(Input.mousePosition).y - startPosition.y;
            transform.position = new Vector3(transform.position.x - positionX, 
                transform.position.y - positionY, transform.position.z);
        }
    }
}
