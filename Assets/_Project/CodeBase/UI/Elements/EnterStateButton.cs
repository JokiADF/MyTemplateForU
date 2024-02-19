using System;
using _Project.CodeBase.Infrastructure.States.GameStates;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.CodeBase.UI.Elements
{
    public class EnterStateButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private GameStateId gameStateId;
        
        private GameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Awake() => 
            button.onClick.AddListener(Enter);

        private void Enter()
        {
            switch (gameStateId)
            {
                case GameStateId.GameBootstrap: _gameStateMachine.Enter<GameBootstrapState>(); break;
                case GameStateId.GameLoading: _gameStateMachine.Enter<GameLoadingState>(); break;
                case GameStateId.GameHub: _gameStateMachine.Enter<GameHubState>(); break;
                case GameStateId.GameLoop: _gameStateMachine.Enter<GameLoopState>(); break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}