using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DI
{

    public sealed class MoveController : MonoBehaviour, IGameState
    {
        private IMoveInput input;

        private IPlayer player;

        public void Construct(IMoveInput input, IPlayer player)
        {
            this.input = input;
            this.player = player;
        }


        public void OnStartGame()
        {
            input.OnMove += OnMove;
        }

        void IGameState.OnFinishGame()
        {
            input.OnMove -= OnMove;
        }

        private void OnMove(Vector3 direction)
        {
            player.Move(direction);
        }
    }
}
