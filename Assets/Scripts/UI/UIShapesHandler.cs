using DG.Tweening;
using Shapes.Core;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shapes.UI
{
    public class UIShapesHandler : MonoBehaviour
    {
        #region Events

        public event Action<UIShape> OnShapeSelected;

        #endregion Events

        #region Variables

        [SerializeField]
        private RectTransform versusSpot;
        [SerializeField]
        private HorizontalLayoutGroup layoutGroup;
        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField]
        private List<UISelectableShape> selectableShapes = new();
        [SerializeField]
        private List<UIShape> enemyShapes = new();

        private (UISelectableShape shape, int selectionIndex) selectedShape;

        private UIShape currentEnemyShape;

        private Sequence transitionSequence;

        private IShapeOffManager shapeOffManager;

        #endregion Variables

        #region Unity methods

        private void OnEnable()
        {
            foreach (var shape in selectableShapes)
            {
                shape.OnShapeSelected += Shape_OnShapeSelected;
            }
        }

        private void OnDisable()
        {
            foreach (var shape in selectableShapes)
            {
                shape.OnShapeSelected -= Shape_OnShapeSelected;
            }
        }

        #endregion Unity methods

        #region Public methods

        public void Initialize()
        {
            foreach (var shape in selectableShapes)
            {
                shape.Initialize();
            }

            foreach (var shape in enemyShapes)
            {
                shape.Initialize();
            }
        }

        public async Task ReenableShapesSelection()
        {
            List<Task> showShapes = new();

            foreach (var shape in selectableShapes)
            {
                if (shape == selectedShape.shape)
                {
                    continue;
                }

                showShapes.Add(shape.ShowShape());
            }

            foreach (var shape in enemyShapes)
            {
                shape.gameObject.SetActive(false);
            }

            await Task.WhenAll(showShapes);

            canvasGroup.interactable = true;

            selectedShape.shape.SetInteractable(true);
            selectedShape = (null, -1);
        }

        public async Task HideSelectableShapes()
        {
            selectedShape.shape.SetInteractable(false);

            canvasGroup.interactable = false;

            List<Task> hideShapes = new();

            foreach (var shape in selectableShapes)
            {
                if (shape == selectedShape.shape)
                {
                    continue;
                }

                hideShapes.Add(shape.HideShape());
            }

            await Task.WhenAll(hideShapes);
        }

        public async Task MoveShapeToVersusSpot()
        {
            var selectedEnemyShape = shapeOffManager.SelectEnemyShape();

            foreach (var shape in enemyShapes)
            {
                if (shape.ShapeType == selectedEnemyShape)
                {
                    shape.gameObject.SetActive(true);
                    continue;
                }

                shape.gameObject.SetActive(false);
            }

            transitionSequence.Kill();
            transitionSequence = DOTween.Sequence();
            transitionSequence.Append(selectedShape.shape.ShapeIcon.rectTransform
                .DOMove(versusSpot.position, 0.5f).SetEase(Ease.InOutCubic));

            await transitionSequence.AsyncWaitForCompletion();
        }

        public async Task MoveShapeToSelectionSpot()
        {
            transitionSequence.Kill();
            transitionSequence = DOTween.Sequence();
            transitionSequence.Append(selectedShape.shape.ShapeIcon.rectTransform
                .DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.InOutCubic));

            await transitionSequence.AsyncWaitForCompletion();
        }

        public async Task ShapesAttack(IShape enemyShape)
        {
            currentEnemyShape = enemyShapes.First(x => x.ShapeType == enemyShape.GetShapeType());

            List<Task> tasks = new();

            tasks.Add(selectedShape.shape.ShapeAttack());
            tasks.Add(currentEnemyShape.ShapeAttack());

            await Task.WhenAll(tasks);
        }

        public async Task HurtShapeOffVictim(IShape shape)
        {
            if(shape.GetShapeType() == selectedShape.shape.ShapeType)
            {
                await selectedShape.shape.ShapeTakeDamage();
            }
            else if (shape.GetShapeType() == currentEnemyShape.ShapeType)
            {
                await currentEnemyShape.ShapeTakeDamage();
            }
            else
            {
                Debug.LogError("Wrong shape set as victim.");
            }
        }

        #endregion Public methods

        #region Private methods

        [Inject]
        private void Inject(IShapeOffManager shapeOffManager)
        {
            this.shapeOffManager = shapeOffManager;
        }

        #region Event callbacks

        private void Shape_OnShapeSelected(UISelectableShape selectedShape)
        {
            this.selectedShape = (selectedShape, selectedShape.transform.GetSiblingIndex());

            OnShapeSelected?.Invoke(selectedShape);
        }

        #endregion Event callbacks

        #endregion Private methods
    }
}