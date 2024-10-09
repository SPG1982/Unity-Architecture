using System;
using System.Collections;
using UnityEngine;

    public sealed class KeyboardInput : MonoBehaviour, IStartGameListener, IFinishGameListener, IMoveInput
    {
        public event Action<Vector3> OnMove;

        private bool isActive;
        void IStartGameListener.OnStartGame()
        {
            this.isActive = true;
        }

        void IFinishGameListener.OnFinishGame()
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
