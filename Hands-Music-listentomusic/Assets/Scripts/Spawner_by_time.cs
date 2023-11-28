// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement; // Include the SceneManager namespace

// public class Spawner_by_time : MonoBehaviour
// {
//     public GameObject fingerPrefab;
//     public List<float> spawnTimes = new List<float> {5.1f ,19.1f, 30.8f, 40.1f, 49.1f, 60.17f, 66.05f, 71.2f, 85.1f};
//     private float elapsedTime = 0f;
//     private int nextSpawnIndex = 0;
//     private bool isSimulationSceneActive = false; // Flag to track if the Simulation scene is active

//     void Start()
//     {
//         if (spawnTimes.Count > 0)
//         {
//             spawnTimes.Sort();
//         }

//         SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
//     }

//     void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//     {
//         if (scene.name == "Simulation") // Check if the loaded scene is Simulation
//         {
//             isSimulationSceneActive = true; // Set the flag to true
//         }
//     }

//     void Update()
//     {
//         if (isSimulationSceneActive)
//         {
//             elapsedTime += Time.deltaTime; // Increment elapsed time only if Simulation scene is active

//             // Check if it's time to spawn the next prefab
//             if (nextSpawnIndex < spawnTimes.Count && elapsedTime >= spawnTimes[nextSpawnIndex])
//             {
//                 Instantiate(fingerPrefab, transform.position, Quaternion.identity);
//                 nextSpawnIndex++;

//                 Debug.Log("Spawned prefab at time: " + elapsedTime);
//             }
//         }
//     }

//     void OnDestroy()
//     {
//         SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe when the object is destroyed
//     }
// }






// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class Spawner_by_time : MonoBehaviour
// {
//     public GameObject fingerPrefab;
//     public List<float> spawnTimes = new List<float> {5.1f ,19.1f, 30.8f, 40.1f, 49.1f, 60.17f, 66.05f, 71.2f, 85.1f}; // List to hold the times to spawn
//     private float elapsedTime = 0f; // To keep track of elapsed time
//     private int nextSpawnIndex = 0; // Index to keep track of the next spawn time

//     // Start is called before the first frame update
//     void Start()
//     {
//         if (spawnTimes.Count > 0)
//         {
//             spawnTimes.Sort(); // Make sure the list is sorted in ascending order
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         elapsedTime += Time.deltaTime; // Increment elapsed time

//         // Check if it's time to spawn the next prefab
//         if (nextSpawnIndex < spawnTimes.Count && elapsedTime >= spawnTimes[nextSpawnIndex])
//         {
//             Instantiate(fingerPrefab, transform.position, Quaternion.identity);
//             nextSpawnIndex++; // Move to the next spawn time
//         }
//     }
// }

















// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Spawner_by_time : MonoBehaviour
// {
//     public GameObject fingerPrefab;
//     public List<float> spawnTimes = new List<float> { 5.1f ,19.1f, 30.8f, 40.1f, 49.1f, 60.17f, 66.05f, 71.2f, 85.1f }; // Times at which to spawn the prefab
//     private float elapsedTime = 0f; // To keep track of elapsed time
//     private int nextSpawnIndex = 0; // Index to keep track of the next spawn time

//     // Update is called once per frame
//     void Update()
//     {
//         elapsedTime += Time.deltaTime; // Increment elapsed time

//         // Check if it's time to spawn the next prefab
//         if (nextSpawnIndex < spawnTimes.Count && elapsedTime >= spawnTimes[nextSpawnIndex])
//         {
//             GameObject spawnedObject = Instantiate(fingerPrefab, transform.position, Quaternion.identity);
//             Destroy(spawnedObject, 2.0f); // Destroy the spawned object after 2 seconds
//             nextSpawnIndex++; // Move to the next spawn time
//         }
//     }
// }



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Spawner_by_time : MonoBehaviour
// {
//     public GameObject fingerPrefab;
//     public List<float> spawnTimes = new List<float> { 5.1f ,19.1f, 30.8f, 40.1f, 49.1f, 60.17f, 66.05f, 71.2f, 85.1f }; // Times at which to spawn the prefab
//     private float elapsedTime = 0f; // To keep track of elapsed time
//     private int nextSpawnIndex = 0; // Index to keep track of the next spawn time

//     // Update is called once per frame
//     void Update()
//     {
//         elapsedTime += Time.deltaTime; // Increment elapsed time

//         // Check if it's time to spawn the next prefab
//         if (nextSpawnIndex < spawnTimes.Count && elapsedTime <= spawnTimes[nextSpawnIndex])
//         {
//             GameObject spawnedObject = Instantiate(fingerPrefab, transform.position, Quaternion.identity);
//             Destroy(spawnedObject, 2.0f); // Destroy the spawned object after 2 seconds
//             nextSpawnIndex++; // Move to the next spawn time
//         }
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Include the SceneManager namespace

public class Spawner_by_time : MonoBehaviour
{
    public GameObject fingerPrefab;
    public List<float> spawnTimes = new List<float> { 5.1f, 19.1f, 30.8f, 40.1f, 49.1f, 60.17f, 66.05f, 71.2f, 85.1f };
    private float elapsedTime = 0f; 
    private int nextSpawnIndex = 0;
    private bool isSimulationSceneActive = false;

    void Update()
    {
        // Check if the current scene is Simulation
        if (SceneManager.GetActiveScene().name == "Simulation")
        {
            if (!isSimulationSceneActive)
            {
                isSimulationSceneActive = true;
                elapsedTime = 0f; // Reset the timer when entering the Simulation scene
            }

            elapsedTime += Time.deltaTime; // Increment elapsed time

            // Check if it's time to spawn the next prefab
            if (nextSpawnIndex < spawnTimes.Count && elapsedTime >= spawnTimes[nextSpawnIndex])
            {
                GameObject spawnedObject = Instantiate(fingerPrefab, transform.position, Quaternion.identity);
                Destroy(spawnedObject, 2.0f); // Destroy the spawned object after 2 seconds
                nextSpawnIndex++; // Move to the next spawn time
            }
        }
        else
        {
            isSimulationSceneActive = false;
        }
    }
}

