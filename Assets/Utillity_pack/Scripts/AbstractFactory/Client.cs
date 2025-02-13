using System;
using UnityEngine;

namespace AbstractFactory
{
    public class Client : MonoBehaviour
    {
        private void Start()
        {
            Main();
        }

        public void Main()
        {
            // Debug.Log($"Client: Testing client with the first factory type...");
            // Debug.Log(new ConcreteFactory1() + "\n");

            Debug.Log($"Client: Testing same client with the second factory type...");
            ClientMethod(new ConcreteFactory2());
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();

            Debug.Log(productB.FooB());
            Debug.Log(productB.AnotherFooB(productA));
        }
    }
}