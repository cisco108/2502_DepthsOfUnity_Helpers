using System;
using UnityEngine;

namespace EventSystem
{
    public class TestEvents : MonoBehaviour
    {
        public ScriptableEvent myEvent;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
               myEvent.Invoke(); 
            }
        }
    }
}