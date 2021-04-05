using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIL.Library {
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance;
        public ClockUI ClockUI;
        public DayManager DayUI;
        public int dayTime, timeSteps;
        public bool CanCountTime;
        private int timeStep;
        public FamilyEventManager eventSpawner;
        public int DaySpawnEvent;
        public PopUpEnergyFx PopUpEnergyFx;
        public FamilyActivityManager familyActivityManager;
        private void Awake() {
            timeStep = timeSteps * 50;
            Instance = this;
        }
        private void Start() {
            GameEventHandler.Instance.OnStartGame += StartCountingTime;
        }
        public int CurTime, CurDay;
        private float TimeToPercent(int dayTimeScale) {
            return (float)CurTime / (float)dayTimeScale;
        }
        public void PauseGame() {
            Time.timeScale = 0;
        }
        public void ResumeGame() {
            Time.timeScale = 1;
        }

        public bool isHoldingTime()
        {
            return CanCountTime;
        }
        public void HoldGame() {
            CanCountTime = false;
        }
        public void DeHoldGame() {
            StartCountingTime();
        }
        public void StartCountingTime() {
            CanCountTime = true;
            DayUI.DayUpdate(CurDay);
            StartCoroutine(TimeUpdate());
        }
        private IEnumerator TimeUpdate() {
            int dayTimeInTimeScale = dayTime * 50;
            while (CanCountTime) {
                CurTime++;
                if (CurTime % timeStep == 0)
                    OneTimeStep();
                if (CurTime == dayTimeInTimeScale) {
                    CurTime = 0;
                    CurDay++;
                    if (CurDay > 8) DaySpawnEvent = 2;
                    if (CurDay > 14) DaySpawnEvent = 1;
                    Player.Instance.AddEnergy();
                    PopUpEnergyFx.PlayEffect(Player.Instance.EnergyAdd);
                    if (CurDay % DaySpawnEvent == 0) eventSpawner.SpawnEvent();
                    DayUI.DayUpdate(CurDay);
                    AudioManager.AM.Play("Newday");
                }

                //Display UI
                ClockUI.SetArrow(TimeToPercent(dayTimeInTimeScale));
                yield return new WaitForSeconds(.02f);
            }
            yield return null;
        }
        public event Action OnOneTimeStep;
        public void OneTimeStep() {
            if (OnOneTimeStep != null)
                OnOneTimeStep();
        }
    }
}
