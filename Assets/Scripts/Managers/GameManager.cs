using Shapes.Core;
using UnityEngine;
using Zenject;

namespace Shapes.Managers
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        #region Variables
        
        private IUIManager uiManager;
        private IShapeOffManager shapeOffManager;

        #endregion Variables

        #region Unity methods

        private void Awake()
        {
            Initialize();
        }

        #endregion Unity methods

        #region Private methods

        [Inject]
        private void Inject(IUIManager uiManager, IShapeOffManager shapeOffManager)
        {
            this.uiManager = uiManager;
            this.shapeOffManager = shapeOffManager;
        }

        private void Initialize()
        {
            GameFlow();

            uiManager.Initialize();
        }

        private async void GameFlow()
        {
            while (true)
            {
                var selectedShapeType = await uiManager.AwaitShapeSelection();

                await shapeOffManager.Combat(selectedShapeType);

                await uiManager.ReturnToShapeSelection();
            }
        }

        #endregion Private methods
    }
}