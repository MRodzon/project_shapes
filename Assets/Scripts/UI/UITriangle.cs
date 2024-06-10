using DG.Tweening;
using Shapes.Core;
using System.Threading.Tasks;

namespace Shapes.UI
{
    public class UITriangle : UISelectableShape
    {
        #region Public methods

        public override void Initialize()
        {
            base.Initialize();

            shapeType = ShapeTypes.Triangle;
        }

        public override async Task ShowShape()
        {
            button.interactable = false;

            shapeIcon.rectTransform.DOLocalMoveX(-250f, 0f);

            showSequence.Complete();
            showSequence = UIShapeAnimationsHandler.ShowTriangle(shapeIcon);
            showSequence.OnComplete(() => SetInteractable(true));

            await showSequence.AsyncWaitForCompletion();
        }

        public override async Task HideShape()
        {
            showSequence.Complete();
            showSequence = UIShapeAnimationsHandler.HideTriangle(shapeIcon);

            await showSequence.AsyncWaitForCompletion();
        }

        public override async Task ShapeAttack()
        {
            shapeOffSequence.Kill();
            shapeOffSequence = UIShapeAnimationsHandler.TriangleAttack(globalValuesSO, shapeIcon);

            await shapeOffSequence.AsyncWaitForCompletion();
        }

        public override async Task ShapeTakeDamage()
        {
            shapeOffSequence.Kill();
            shapeOffSequence = UIShapeAnimationsHandler.TriangleTakeDamage(globalValuesSO, shapeIcon);

            await shapeOffSequence.AsyncWaitForCompletion();
        }

        #endregion Public methods

        #region Protected methods

        protected override void ShapeClicked()
        {
            base.ShapeClicked();

            clickedSequence.Kill();
            clickedSequence = UIShapeAnimationsHandler.TriangleClicked(globalValuesSO, transform, shapeIcon);
        }

        #endregion Protected methods
    }
}