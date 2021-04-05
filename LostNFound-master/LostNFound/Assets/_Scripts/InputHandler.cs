using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIL.Library.Utility;
using DIL.Library.Features;

namespace DIL.Library {
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance;
        private void Awake() {
            Instance = this;
        }
        public TouchState State { get { return _state; } }
        private TouchState _state = TouchState.Drop;
        private Vector3 _startTouchPos;
        private float diffX, diffY;
        private float startFrame;
        public GameObject GetHoveredObject()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));
            if (hit.collider == null) return null;
            return hit.collider.gameObject;
        }
        public GameObject GetHoldObject()
        {
            if (!Input.GetMouseButtonDown(0)) return null;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));

            if (hit.collider == null || Input.GetMouseButtonUp(0)) return null;
            return hit.collider.gameObject;
        }
        public GameObject GetClickedObject()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));

            if (hit.collider == null) return null;
            if (Input.GetMouseButtonUp(0))
                return hit.collider.gameObject;
            else return null;
        }
        public GameObject GetDropObject()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));
            if (Input.GetMouseButtonUp(0))
                return hit.collider.gameObject;
            else 
                return null;
        }
        private void TouchCheck()
        {
            if (Input.GetMouseButtonDown(0) && _state == TouchState.Drop)
            {
                _startTouchPos = Input.mousePosition;
                _state = TouchState.Start;
                startFrame = Time.realtimeSinceStartup;
            }

            if (_state == TouchState.Start)
            {
                if (Input.mousePosition != _startTouchPos)
                {
                    _state = TouchState.Drag;
                    Drag();
                }
            }
            if (_state == TouchState.Drag)
                Drag();
            if (Input.GetMouseButtonUp(0))
            {
                _state = TouchState.Drop;
                if (Time.realtimeSinceStartup - startFrame < 0.5f)
                    Swipe();
            }
        }

        #region Move Command Definition
        void Swipe()
        {
            float disX = Mathf.Abs(Input.mousePosition.x - _startTouchPos.x);
            float disY = Mathf.Abs(Input.mousePosition.y - _startTouchPos.y);
            if (disX > diffX && disX > disY)
            {
                if (Input.mousePosition.x > _startTouchPos.x) {
                //Swipe Right
                    ConsoleLog.Instance.Log("Swipe Right");
                    if (OnSwipeRight != null)
                        OnSwipeRight();
                }
                else {
                //SwipeLeft
                    ConsoleLog.Instance.Log("Swipe Left");
                    if (OnSwipeLeft != null)
                        OnSwipeLeft();
                }
                    
            }

            if (disY > diffY && disY > disX)
            {
                if (Input.mousePosition.y > _startTouchPos.y) {
                //Swipe Up
                    ConsoleLog.Instance.Log("Swipe Up");
                    if (OnSwipeUp != null)
                        OnSwipeUp();
                }
                else {
                //Swipe Down
                    ConsoleLog.Instance.Log("Swipe Down");
                    if (OnSwipeDown != null)
                        OnSwipeDown();
                }   
            }
        }
        void Drag()
        {
            float disX = Mathf.Abs(Input.mousePosition.x - _startTouchPos.x);
            float disY = Mathf.Abs(Input.mousePosition.y - _startTouchPos.y);
            if (disX > diffX && disX > disY)
            {
                if (Input.mousePosition.x > _startTouchPos.x) {
                //Drag Right
                    ConsoleLog.Instance.Log("Drag Right");
                    if (OnDragRight != null)
                        OnDragRight();
                }
                    
                else {
                //Drag Left
                    ConsoleLog.Instance.Log("Drag Left");
                    if (OnDragLeft != null)
                        OnDragLeft();
                }
                    
            }

            if (disY > diffY && disY > disX)
            {
                if (Input.mousePosition.y > _startTouchPos.y) {
                //Drag Up
                    ConsoleLog.Instance.Log("Drag Up");
                    if (OnDragUp != null)
                        OnDragRight();
                }
                    
                else {
                //Drag Down
                    ConsoleLog.Instance.Log("Drag Down");
                    if (OnDragDown != null)
                        OnDragDown();
                }
                    
            }
        }
        #endregion
        
        #region Move Event Action
        public event Action OnSwipeUp;
        public event Action OnSwipeDown;
        public event Action OnSwipeLeft;
        public event Action OnSwipeRight;
        public event Action OnDragUp;
        public event Action OnDragDown;
        public event Action OnDragLeft;
        public event Action OnDragRight;
        #endregion
        private void Update()
        {
            TouchCheck();
        }
    }
}

