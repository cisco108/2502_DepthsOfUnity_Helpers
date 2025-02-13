using UnityEngine;

namespace EventSystem
{
    public class CubeBehaviour : MonoBehaviour
    {

        public void MoveCube()
        {
            var cubes = GameObject.FindGameObjectsWithTag("tag");
            int randomIndex = Random.Range(0, cubes.Length);
            var pos = cubes[randomIndex].transform.position;
            pos.y += Random.Range(1, 3);
            cubes[randomIndex].transform.position = pos;
        }
    }
}