using DG.Tweening;
using Shapes.Core;
using Shapes.UI;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Shapes.Managers
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        #region Variables

        [SerializeField]
        private UIShapesHandler uiShapesHandler;
        [SerializeField]
        private RectTransform versusPanel;

        private IGameManager gameManager;

        private Sequence transitionSequence;

        private ShapeTypes selectedShapeType;

        #endregion Variables

        #region Unity methods

        private void OnEnable()
        {
            uiShapesHandler.OnShapeSelected += UiShapesHandler_OnShapeSelected;
        }

        private void OnDisable()
        {
            uiShapesHandler.OnShapeSelected -= UiShapesHandler_OnShapeSelected;
        }

        #endregion Unity methods

        #region Public methods

        public void Initialize()
        {
            uiShapesHandler.Initialize();
        }

        public async Task<ShapeTypes> AwaitShapeSelection()
        {
            while(selectedShapeType == ShapeTypes.None)
            {
                await Task.Yield();
            }

            await uiShapesHandler.HideSelectableShapes();

            await PrepareViewForShapeOff();

            await Task.Delay(500);

            return selectedShapeType;
        }

        public async Task ReturnToShapeSelection()
        {
            await Task.Delay(500);

            await ReturnViewFromShapeOff();

            await uiShapesHandler.ReenableShapesSelection();

            selectedShapeType = ShapeTypes.None;
        }

        public async Task ShapeOff(IShape shapeToHurt)
        {
            await uiShapesHandler.ShapeAttack();

            await uiShapesHandler.HurtShapeOffVictim(shapeToHurt);
        }

        #endregion Public methods

        #region Private methods

        [Inject]
        private void Inject(IGameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        private async Task PrepareViewForShapeOff()
        {
            List<Task> tasks = new();

            tasks.Add(uiShapesHandler.MoveShapeToVersusSpot());
            tasks.Add(SetVersusPanelVisibility(true));

            await Task.WhenAll(tasks);
        }

        private async Task ReturnViewFromShapeOff()
        {
            List<Task> tasks = new();

            tasks.Add(uiShapesHandler.MoveShapeToSelectionSpot());
            tasks.Add(SetVersusPanelVisibility(false));

            await Task.WhenAll(tasks);
        }

        private async Task SetVersusPanelVisibility(bool isVisible)
        {
            float moveValue = isVisible ? Screen.height / 2 : -Screen.height / 2;

            transitionSequence.Kill();
            transitionSequence = DOTween.Sequence();
            transitionSequence.Append(versusPanel.DOAnchorPosY(moveValue, 0.5f).SetEase(isVisible ? Ease.OutCubic : Ease.InCubic));

            await transitionSequence.AsyncWaitForCompletion();
        }

        #region Event callbacks

        private void UiShapesHandler_OnShapeSelected(UIShape selectedShape)
        {
            selectedShapeType = ShapeTypes.Triangle;
        }

        #endregion Event callbacks

        #endregion Private methods
    }
}