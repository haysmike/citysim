using UnityEngine;

public class CameraController : MonoBehaviour {
    public float speed;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView -= 20 * scroll;
    }
}
