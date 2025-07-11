using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SabanMete.Core.Utils
{
        public interface ISceneLoader
        {
            UniTask LoadScenesAsync(IEnumerable<string> sceneNames, LoadSceneMode mode = LoadSceneMode.Additive);
            UniTask UnloadSceneAsync(string sceneName);
        }

        public class SceneLoader : ISceneLoader
        {
            public async UniTask LoadScenesAsync(IEnumerable<string> sceneNames, LoadSceneMode mode = LoadSceneMode.Additive)
            {
                foreach (var sceneName in sceneNames)
                {
                    if (SceneManager.GetSceneByName(sceneName).isLoaded)
                        continue;

                    var loadOp = SceneManager.LoadSceneAsync(sceneName, mode);
                    await loadOp.ToUniTask();
                }
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
