using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraLongMonogameTutoriel.Scenes;

namespace UltraLongMonogameTutoriel.Managers
{
    internal class SceneManager
    {
        public event EventHandler<string> OnSceneChange;

        public IScene CurrentScene => sceneStack.Peek();

        private readonly Stack<IScene> sceneStack;
        public SceneManager() 
        {
            sceneStack = new Stack<IScene>();
        }
        public void ChangeScene(object sender, string sceneName)
        {
            OnSceneChange?.Invoke(this, sceneName);
        }
        public void AddScene(IScene scene)
        {
            scene.Load();
            sceneStack.Push(scene);
        }
        public void RemoveScene()
        {
            sceneStack.Pop();
        }
        public IScene GetCurrentScene()
        {
            return sceneStack.Peek();
        }
    }
}
