using UnityEngine;

public class MarkerController : MonoBehaviour {
    public Collider coll;

    private Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
    }

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (coll.Raycast(ray, out hit, 2000)) {
            Vector3 pos = ray.GetPoint(hit.distance);
            transform.position = pos;
            if (pos.y > 0) {
                rend.material.color = Color.white;
            } else {
                rend.material.color = Color.red;
            }
        }
    }
}
