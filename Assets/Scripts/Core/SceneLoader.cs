using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace SabanMete.Core.Utils
{
    
        public class GameSceneReadySignal{}
        public class HideLoadingScreenSignal{}
        public class ShowLoadingScreenSignal{}
        public interface ISceneLoader
        {
            UniTask LoadScenesAsync(IEnumerable<string> sceneNames, LoadSceneMode mode = LoadSceneMode.Additive,bool showLoadingScreen = true);
            UniTask UnloadSceneAsync(string sceneName);
        }

        public class SceneLoader : ISceneLoader
        {
            private SignalBus signalBus;

            [Inject]
            public SceneLoader(SignalBus signalBus)
            {
                this.signalBus = signalBus;
            }
            public async UniTask LoadScenesAsync(IEnumerable<string> sceneNames, LoadSceneMode mode = LoadSceneMode.Additive,bool showLoadingScreen = true)
            {
                if(showLoadingScreen)
                    signalBus.Fire(new ShowLoadingScreenSignal());
                foreach (var sceneName in sceneNames)
                {
                    if (SceneManager.GetSceneByName(sceneName).isLoaded)
                        continue;

                    var loadOp = SceneManager.LoadSceneAsync(sceneName, mode);
                    await loadOp.ToUniTask();
                }
                await UniTask.Yield();
                signalBus.Fire(new GameSceneReadySignal());
            }

            public async UniTask UnloadSceneAsync(string sceneName)
            {
                if (!SceneManager.GetSceneByName(sceneName).isLoaded)
                    return;

                var unloadOp = SceneManager.UnloadSceneAsync(sceneName);
                await unloadOp.ToUniTask();
            }
        }



}
