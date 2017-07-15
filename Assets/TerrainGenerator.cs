using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {
    private Thread worker;
    private bool isWorkerAlive = true;
    private Queue<string> messages = new Queue<string>();

    void Start() {
        messages.Enqueue("initializing");
        worker = new Thread(GenerateTerrain);
        worker.Start();
    }

    void Update() {
        // if (isWorkerAlive != worker.IsAlive) {
        //     Debug.Log("Worker status: " + worker.IsAlive);
        //     isWorkerAlive = worker.IsAlive;
        // }
        if (messages.Count > 0) {
            Debug.Log("Message from worker: " + messages.Dequeue());
        }
    }

    void GenerateTerrain() {
        for (int i = 0; i < 3; i++) {
            Thread.Sleep(300);
            messages.Enqueue(i.ToString());
        }
        messages.Enqueue("done");
    }
}
