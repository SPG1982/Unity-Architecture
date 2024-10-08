﻿using System;
using System.Collections;
using UnityEngine;

namespace DI {

    public sealed class KeyboardInput : MonoBehaviour, IGameState, IMoveInput
    {
        public event Action<Vector3> OnMove;

        private bool isActive;
        public void OnStartGame()
        {
            this.isActive = true;
        }

        void IGameState.OnFinishGame()
        {
            this.isActive = false;
        }

        private void Update()
        {
            if (this.isActive)
            {
                this.HandleKeyboard();
            }
        }

        private void HandleKeyboard()
        {
            //Debug.Log("11111");
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.Move(Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.Move(Vector3.back);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.Move(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.Move(Vector3.right);
            }
        }

        public void Move(Vector3 direction)
        {
            this.OnMove?.Invoke(direction);
        }

    }

}

