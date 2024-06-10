using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Shapes.UI
{
    public class UISelectableShape : UIShape, IPointerEnterHandler, IPointerExitHandler
    {
        #region Events

        public event Action<UISelectableShape> OnShapeSelected;

        #endregion Events

        #region Variables

        [SerializeField]
        protected Button button;
        [SerializeField]
        private ParticleSystem particles;

        protected Sequence highlightSequence;
        protected Sequence clickedSequence;

        private Vector3 startingScale;
        private bool isCursorOver;

        #endregion Variables

        #region Unity methods

        private void OnEnable()
        {
            button.onClick.AddListener(Button_OnClicked);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Button_OnClicked);
        }

        #endregion Unity methods

        #region Public methods

        public override void Initialize()
        {
            base.Initialize();

            startingScale = transform.localScale;
        }

        public void SetInteractable(bool isInteractable)
        {
            button.interactable = isInteractable;

            if (isInteractable && isCursorOver)
            {
                ShapeSelected();
            }
        }
        #endregion Public methods

        #region Protected methods

        protected virtual void ShapeSelected()
        {
            particles.Play();

            highlightSequence.Kill();
            highlightSequence = UIShapeAnimationsHandler.BaseShapeSelected(globalValuesSO, transform);
            highlightSequence.OnComplete(() =>
            {
                highlightSequence = UIShapeAnimationsHandler
                .BaseShapeSelectionLoop(globalValuesSO, transform, startingScale);
            });
        }

        protected virtual void ShapeDeselected()
        {
            particles.Stop();

            highlightSequence.Kill();
            highlightSequence = UIShapeAnimationsHandler.BaseShapeDeselected(globalValuesSO, transform, startingScale);
        }

        protected virtual void ShapeClicked()
        {
            highlightSequence.Kill();

            ShapeDeselected();

            OnShapeSelected?.Invoke(this);
        }

        #endregion Protected methods

        #region Private methods

        #region Event callbacks

        private void Button_OnClicked()
        {
            ShapeClicked();
        }

        #endregion Event callbacks

        #endregion Private methods

        #region Unity events

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (button.interactable)
            {
                ShapeSelected();
            }

            isCursorOver = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (button.interactable)
            {
                ShapeDeselected();
            }

            isCursorOver = false;
        }

        #endregion Unity events
    }
}