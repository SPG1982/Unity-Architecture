using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public sealed class MoveController : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        private IMoveInput input;

        private IPlayer player;

        public void Construct(IMoveInput input, IPlayer player)
        {
            this.input = input;
            this.player = player;
        }


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
            player.Move(direction);
        }
    }
