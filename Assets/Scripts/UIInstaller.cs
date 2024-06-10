using Shapes.Managers;
using UnityEngine;
using Zenject;

namespace Shapes.Installers
{
    public class UIInstaller : MonoInstaller<UIInstaller>
    {
        #region Variables

        [SerializeField]
        private UIManager uiManager;

        #endregion Variables

        #region Public methods

        public override void InstallBindings()
        {
            Container.BindInstance(uiManager).NonLazy();
        }

        #endregion Public methods
    }
}