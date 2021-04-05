using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIL.Library {
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public int DeadCount = 0;
        //Gameflow + game's general stat
        private void Awake()
        {
            Instance = this;
        }      
        private void Start() {
            if (PlayerPrefs.GetInt("NewGame") == 0)
                GameEventHandler.Instance.InitGame();
            else 
                GameEventHandler.Instance.LoadGame();
        }
    }
}
