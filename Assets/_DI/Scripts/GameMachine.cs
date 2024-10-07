using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._DI.Scripts
{
    public sealed class GameMachine : MonoBehaviour
    {
        public GameState GameState
        {
            get { return this.gameState; }
        }

        private readonly List<object> listeners = new();

        private GameState gameState = GameState.FINISH;

        [ContextMenu("Start Game")]
        public void StartGame()
        {
            if (this.gameState != GameState.START)

            this.gameState = GameState.START;

            foreach (var listener in this.listeners)
            {
                if (listener is IGameState startListener)
                {
                    startListener.OnStartGame();
                }
            }
        }


        [ContextMenu("Finish Game")]
        public void FinishGame()
        {
            if (this.gameState != GameState.FINISH)

            this.gameState = GameState.FINISH;

            foreach (var listener in this.listeners)
            {
                if (listener is IGameState finishListener)
                {
                    finishListener.OnFinishGame();
                }
            }
        }

        public void AddListener(object listener)
        {
            this.listeners.Add(listener);
        }

        public void RemoveListener(object listener)
        {
            this.listeners.Remove(listener);
        }
    }
}