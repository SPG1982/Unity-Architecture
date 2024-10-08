using DI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._DI.Scripts
{
    public sealed class GameMachine : MonoBehaviour
    {
        [SerializeField]
        private GameLocator gameLocator;


        private GameState gameState = GameState.FINISH;

        public GameState GameState
        {
            get { return gameState; }
        }

        

        [ContextMenu("Start Game")]
        public void StartGame()
        {
            if (gameState != GameState.START)

            gameState = GameState.START;

            //foreach (var listener in gameLocator.services)
            //{
            //    if (listener is IGameState startListener)
            //    {
            //        startListener.OnStartGame();
            //    }
            //}

            KeyboardInput listenerKI = gameLocator.GetService<KeyboardInput>();
            listenerKI.OnStartGame();

            MoveController listenerMC = gameLocator.GetService<MoveController>();
            listenerMC.OnStartGame();
            //Debug.Log(listenerMC.GetType().ToString());
            //Console.WriteLine(listenerMC.GetType());
        }


        [ContextMenu("Finish Game")]
        public void FinishGame()
        {
            if (gameState != GameState.FINISH)

            gameState = GameState.FINISH;

            foreach (var listener in gameLocator.services)
            {
                if (listener is IGameState finishListener)
                {
                    finishListener.OnFinishGame();
                }
            }
        }


    }
}