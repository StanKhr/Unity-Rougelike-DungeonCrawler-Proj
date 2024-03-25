using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FSM.GameLoop.Enums;
using FSM.GameLoop.Interfaces;
using FSM.GameLoop.States;
using FSM.Main;
using Plugins.StanKhrEssentials.Scripts.Utility;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

namespace FSM.GameLoop.Machines
{
    public class StateMachineGameLoop : StateMachine, IStateMachineGameLoop
    {
        #region Fields

        private Dictionary<GameSceneType, string> _scenesDictionary;

        #endregion
        
        #region Unity Callbacks

        protected override async void Start()
        {
            base.Start();
            
            DontDestroyOnLoad(gameObject);

            await LocalizationSettings.InitializationOperation;
            
            ToMainMenuState();
        }

        #endregion
        
        #region Methods
        
        public void ToMainMenuState()
        {
            SwitchState(new StateGameLoopMainMenu(this));
        }

        public void ToDungeonState()
        {
            SwitchState(new StateGameLoopDungeon(this));
        }

        public void ToDeathState()
        {
            SwitchState(new StateGameLoopDeath(this));
        }

        public void LoadScene(GameSceneType type)
        {
            var sceneName = GetSceneName(type);
            if (string.IsNullOrEmpty(sceneName))
            {
                LogWriter.DevelopmentLog($"Scene {sceneName} not found", LogType.Warning);
                return;
            }
            
            SceneManager.LoadSceneAsync(sceneName);
        }

        public void UnloadScene(GameSceneType type)
        {
            var sceneName = GetSceneName(type);
            if (string.IsNullOrEmpty(sceneName))
            {
                LogWriter.DevelopmentLog($"Scene {sceneName} not found", LogType.Warning);
                return;
            }
            
            SceneManager.UnloadSceneAsync(sceneName);
        }

        public void ExitGame()
        {
            SwitchState(null);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private string GetSceneName(GameSceneType sceneType)
        {
            if (_scenesDictionary == null)
            {
                _scenesDictionary = new Dictionary<GameSceneType, string>();

                var enumNames = Enum.GetNames(typeof(GameSceneType));
                for (int i = 0; i < enumNames.Length; i++)
                {
                    _scenesDictionary.Add((GameSceneType)i, enumNames[i]);
                }
            }

            return _scenesDictionary.GetValueOrDefault(sceneType);
        }

        #endregion
    }
}
