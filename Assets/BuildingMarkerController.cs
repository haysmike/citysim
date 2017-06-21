using UnityEngine;

public class BuildingMarkerController : MonoBehaviour {
    public Collider terrainCollider;
    public GameObject buildingPrefab;

    private Renderer rend;
    private int numCollisions;

    void Start() {
        rend = GetComponent<Renderer>();
    }

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!terrainCollider.Raycast(ray, out hit, 2000)) return;

        Vector3 pos = ray.GetPoint(hit.distance);
        transform.position = pos;

        bool canBuild = pos.y > 0 && numCollisions == 0;
        if (canBuild) {
            rend.material.color = Color.white;
        } else {
            rend.material.color = Color.red;
        }

        if (Input.GetMouseButtonDown(0) && canBuild) {
            CreateBuilding();
        }

        if (Input.GetMouseButtonDown(1)) {
            transform.localScale = new Vector3(Random.Range(4, 12), Random.Range(8, 18), Random.Range(4, 12));
            transform.rotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 180.0f), 0.0f);
        }
    }

    void OnTriggerEnter(Collider coll) {
        numCollisions++;
    }

    void OnTriggerExit(Collider coll) {
        numCollisions--;
    }

    void CreateBuilding() {
        GameObject building = Instantiate(buildingPrefab, transform.position, transform.rotation);
        building.transform.localScale = transform.localScale;
        Renderer buildingRenderer = building.GetComponent<Renderer>();
        buildingRenderer.material.color = Random.ColorHSV();
    }
}
