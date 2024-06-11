using DG.Tweening;
using Shapes.Core;
using System.Threading.Tasks;

namespace Shapes.UI
{
    public class UICircle : UISelectableShape
    {
        #region Public methods

        public override void Initialize()
        {
            base.Initialize();

            shapeType = ShapeTypes.Circle;
        }

        public override async Task ShowShape()
        {
            button.interactable = false;

            shapeIcon.rectTransform.DOLocalMoveY(-250f, 0f);

            showSequence.Complete();
            showSequence = UIShapeAnimationsHandler.ShowCircle(shapeIcon);
            showSequence.OnComplete(() => SetInteractable(true));

            await showSequence.AsyncWaitForCompletion();
        }

        public override async Task HideShape()
        {
            showSequence.Complete();
            showSequence = UIShapeAnimationsHandler.HideCircle(shapeIcon);

            await showSequence.AsyncWaitForCompletion();
        }

        public override async Task ShapeAttack()
        {
            shapeOffSequence.Kill();
            shapeOffSequence = UIShapeAnimationsHandler.CircleAttack(globalValuesSO, shapeIcon);

            await shapeOffSequence.AsyncWaitForCompletion();
        }

        public override async Task ShapeTakeDamage()
        {
            shapeOffSequence.Kill();
            shapeOffSequence = UIShapeAnimationsHandler.CircleTakeDamage(globalValuesSO, shapeIcon);

            await shapeOffSequence.AsyncWaitForCompletion();
        }

        #endregion Public methods

        #region Protected methods

        protected override void ShapeClicked()
        {
            base.ShapeClicked();

            clickedSequence.Kill();
            clickedSequence = UIShapeAnimationsHandler.CircleClicked(shapeIcon);
        }

        #endregion Protected methods
    }
}