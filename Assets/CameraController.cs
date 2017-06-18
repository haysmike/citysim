using UnityEngine;

public class CameraController : MonoBehaviour {
    public float speed;
    public float scrollSensitivity;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveForward = Input.GetAxis("Mouse ScrollWheel");
        Vector3 movement = new Vector3(moveX, 0.0f, moveZ) + scrollSensitivity * transform.forward * moveForward;
        rb.AddForce(speed * movement);
    }
}
