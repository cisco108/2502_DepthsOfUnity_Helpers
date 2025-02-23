using System.Collections.Generic;
using UnityEngine;

public class ParentingHelper : MonoBehaviour
{
    [SerializeField] private float catchRadius;
    private int maxObjectsToCatch;

    private List<Transform> _parentedObjects = new();
    [InfoBox("This component catches all objects with a collider in a specified radius" +
             " and makes them a child of this.transform")]
    [Button("Parent Objects in Range")]
    private void CatchChildren()
    {
        var results = Physics.OverlapSphere(transform.position, catchRadius);

        foreach (var res in results)
        {
            res.gameObject.transform.SetParent(transform); 
        }
    }
    
    // Considered NonAlloc version, but for editor I'd prefer the regular one
    // because the unlimited objects that can be selected.
    private void CatchChildrenNonAlloc()
    {
        Collider[] results = new Collider[maxObjectsToCatch];
        var size = Physics.OverlapSphereNonAlloc(transform.position, catchRadius, results);

        foreach (var res in results)
        {
            if (!res) { return; }

            res.gameObject.transform.SetParent(transform); 
            _parentedObjects.Add(gameObject.transform);
        }
        
        System.Array.Clear(results, 0, maxObjectsToCatch);
    }

}