using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 5.0f;

    private float mouseX, mouseY;

    void Update()
    {
        // Move the camera based on WASD input
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float y = Input.GetAxis("Jump") * speed * Time.deltaTime; // Jump key moves the camera up
        float c = Input.GetAxis("Crouch") * speed * Time.deltaTime; // Crouch key moves the camera down
        transform.Translate(x, y + c, z);

        // Rotate the camera based on mouse input
        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity;
        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}
