using UnityEngine;

public class MarkerController : MonoBehaviour {
    public Collider coll;

    private Renderer rend;
    private bool canBuild;

    void Start() {
        rend = GetComponent<Renderer>();
    }

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (coll.Raycast(ray, out hit, 2000)) {
            Vector3 pos = ray.GetPoint(hit.distance);
            transform.position = pos;
            canBuild = pos.y > 0;
            if (canBuild) {
                rend.material.color = Color.white;
            } else {
                rend.material.color = Color.red;
            }
        }

        if (Input.GetMouseButtonDown(0) && canBuild) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = transform.position;
            cube.transform.rotation = transform.rotation;
            cube.transform.localScale = transform.localScale;
            Renderer cubeRend = cube.GetComponent<Renderer>();
            cubeRend.material.CopyPropertiesFromMaterial(rend.material);
        }
    }
}
