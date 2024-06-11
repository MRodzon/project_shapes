using Shapes.Core;
using Shapes.Managers;
using UnityEngine;
using Zenject;

namespace Shapes.Installers
{
    public class GameInstaller : MonoInstaller
    {
        #region Variables

        [SerializeField]
        private GameManager gameManager;

        #endregion Variables

        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<IGameManager>().FromInstance(gameManager).AsSingle();
            Container.Bind<IUIManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IShapeOffManager>().To<ShapeOffManager>().AsSingle();
        }

        #endregion Public methods
    }
}