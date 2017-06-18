using UnityEngine;

public class LightingController : MonoBehaviour {
    public Light sun;

    void Start() {
        transform.position = sun.transform.position;
        transform.rotation = sun.transform.rotation;
    }
}
