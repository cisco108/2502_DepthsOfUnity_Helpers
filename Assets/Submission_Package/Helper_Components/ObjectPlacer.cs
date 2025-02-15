using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public Transform placeLocation;
    public GameObject spawn;
    public List<GameObject> objectsToPlace;

    [Button("Spawn")]
    public void Sers()
    {
        Instantiate(spawn, placeLocation.position, placeLocation.rotation);
    }
}