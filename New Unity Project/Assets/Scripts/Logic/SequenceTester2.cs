using System;
using UnityEngine;

namespace Logic
{
    public class SequenceTester2 : MonoBehaviour
    {
        private void Start()
        {
            //GeneralMethods();
        }

        private void GeneralMethods()
        {
            MethodA();
            MethodB();
            MethodC();
        }
        
        private void MethodA()
        {
            Debug.Log("Method A");
            
            MethodA1();
            MethodA2();

        }
        
        private void MethodA1()
        {
            Debug.Log("Method A.1");
            MethodA11();
            MethodA12();
        }
        
        private void MethodA2()
        {
            Debug.Log("Method A.2");
            MethodA21();
            MethodA22();
        }

        private void MethodA11()
        {
            Debug.Log("Method A.1.1");
        }
        
        private void MethodA12()
        {
            Debug.Log("Method A.1.2");
        }
        
        private void MethodA21()
        {
            Debug.Log("Method A.2.1");
        }
        
        private void MethodA22()
        {
            Debug.Log("Method A.2.2");
        }
        
        private void MethodB()
        {
            Debug.Log("Method B");
        }
        
        private void MethodC()
        {
            Debug.Log("Method C");
        }
        
        
    }
}
