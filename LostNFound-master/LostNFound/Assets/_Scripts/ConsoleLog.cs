using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIL.Library.Features {
    public class ConsoleLog : MonoBehaviour
    {
        public static ConsoleLog Instance;
        public bool DebugMode;
        private void Awake() {
            Instance = this;
        } 
        public void Log(string value) {
            if (DebugMode)
                Debug.Log(value);
        }
    }
}
