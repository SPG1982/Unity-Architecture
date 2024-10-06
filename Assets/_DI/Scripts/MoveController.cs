using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DI
{
    public sealed class MoveController : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        [SerializeField]
        private KeyboardInput input;

        [SerializeField]
        private Player player;


        void IStartGameListener.OnStartGame()
        {
            this.input.OnMove += this.OnMove;
        }

        void IFinishGameListener.OnFinishGame()
        {
            this.input.OnMove -= this.OnMove;
        }

        private void OnMove(Vector3 direction)
        {
            this.player.Move(direction);
        }
    }
}
