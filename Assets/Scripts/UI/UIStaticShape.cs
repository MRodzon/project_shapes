using DG.Tweening;
using Shapes.Core;
using System.Threading.Tasks;
using UnityEngine;

namespace Shapes.UI
{
    public class UIStaticShape : UIShape
    {
        #region Variables

        [SerializeField]
        private ShapeTypes preselectedShapeType;

        #endregion Variables

        #region Public methods

        public override void Initialize()
        {
            base.Initialize();

            shapeType = preselectedShapeType;
        }

        public override async Task ShowShape()
        {
            showSequence.Complete();
            showSequence = UIShapeAnimationsHandler.ShowShape(shapeType, shapeIcon);

            await showSequence.AsyncWaitForCompletion();
        }

        public override async Task HideShape()
        {
            showSequence.Complete();
            showSequence = UIShapeAnimationsHandler.HideShape(shapeType, shapeIcon);

            await showSequence.AsyncWaitForCompletion();
        }

        public override async Task ShapeAttack()
        {
            shapeOffSequence.Kill();
            shapeOffSequence = UIShapeAnimationsHandler.ShapeAttack(shapeType, globalValuesSO, shapeIcon);

            await shapeOffSequence.AsyncWaitForCompletion();
        }

        public override async Task ShapeTakeDamage()
        {
            shapeOffSequence.Kill();
            shapeOffSequence = UIShapeAnimationsHandler.ShapeTakeDamage(shapeType, globalValuesSO, shapeIcon);

            await shapeOffSequence.AsyncWaitForCompletion();
        }

        #endregion Public methods
    }
}