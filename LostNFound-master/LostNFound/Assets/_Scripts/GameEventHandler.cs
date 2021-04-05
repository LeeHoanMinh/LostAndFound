using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIL.Library {
    public class GameEventHandler : MonoBehaviour
    {
        public static GameEventHandler Instance;
        private void Awake() {
            Instance = this;
        }
        //Define some game events in the game
        #region Events and Actions
        //Events
        public event Action OnInitGame;
        public event Action OnStartGame;
        public event Action OnWinGame;
        public event Action OnLoseGame;
        public event Action OnLoadGame;

        //Actions
        public void InitGame()
        {
            if (OnInitGame != null) 
                OnInitGame.Invoke();
            Invoke("StartGame", .02f);
        }
        public void StartGame()
        {
            if (OnStartGame != null)
                OnStartGame();
        }
        public void WinGame()
        {
            if (OnWinGame != null)
                OnWinGame();
        }
        public void LoseGame()
        {
            if (OnLoseGame != null)
                OnLoseGame();
        }
        public void LoadGame() {
            //FamilyActivityManager.Instance.OnLoadGame();
            Invoke("StartGame", .02f);
        }
        #endregion
    }
}
