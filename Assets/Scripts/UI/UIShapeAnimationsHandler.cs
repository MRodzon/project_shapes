using DG.Tweening;
using Shapes.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Shapes.UI
{
    public static class UIShapeAnimationsHandler
    {
        #region Public methods

        #region Base shape

        public static Sequence BaseShapeSelected(GlobalValuesSO globalValuesSO, Transform transform)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(globalValuesSO.SelectionScaleSize, globalValuesSO.InitialScaleTime)
                .SetEase(Ease.OutCubic));

            return sequence;
        }

        public static Sequence BaseShapeDeselected(GlobalValuesSO globalValuesSO, Transform transform, Vector3 startingScale)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(startingScale, globalValuesSO.InitialScaleTime));

            return sequence;
        }

        public static Sequence BaseShapeSelectionLoop(GlobalValuesSO globalValuesSO, Transform transform, Vector3 startingScale)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform
                .DOScale(startingScale * globalValuesSO.ScaleMultiplier, globalValuesSO.ScaleTime)
                .SetEase(Ease.InOutSine)).SetLoops(-1, LoopType.Yoyo);

            return sequence;
        }

        #endregion Base shape

        #region Triangle

        public static Sequence ShowTriangle(Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(shapeIcon.DOFade(1f, 1f));
            sequence.Join(shapeIcon.rectTransform.DOLocalMoveX(0f, 1f));
            sequence.SetEase(Ease.OutCubic);

            return sequence;
        }

        public static Sequence HideTriangle(Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(shapeIcon.DOFade(0f, 1f));
            sequence.Join(shapeIcon.rectTransform.DOLocalMoveX(-250f, 1f));
            sequence.SetEase(Ease.OutCubic);

            return sequence;
        }

        public static Sequence TriangleClicked(GlobalValuesSO globalValuesSO, Transform transform, Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform
                .DOJump(transform.position, globalValuesSO.JumpPower, globalValuesSO.JumpCount, globalValuesSO.JumpDuration));
            sequence.Join(shapeIcon.rectTransform.DOLocalRotate(new(0, 0, 360), 1f, RotateMode.FastBeyond360)
                .SetRelative().SetEase(Ease.OutQuint));

            return sequence;
        }

        public static Sequence TriangleAttack(GlobalValuesSO globalValuesSO, Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(shapeIcon.rectTransform.DOLocalRotate(new(0, 0, -360), globalValuesSO.AttackTime, RotateMode.FastBeyond360));

            return sequence;
        }

        public static Sequence TriangleTakeDamage(GlobalValuesSO globalValuesSO, Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.SetDelay(globalValuesSO.DamageTakenDelay);
            sequence.Append(shapeIcon.rectTransform.DOPunchScale(shapeIcon.transform.localScale, globalValuesSO.DamageTakenTime));

            return sequence;
        }

        #endregion Triangle

        #region Circle

        public static Sequence ShowCircle(Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(shapeIcon.DOFade(1f, 1f));
            sequence.Join(shapeIcon.rectTransform.DOLocalMoveY(0f, 1f));
            sequence.SetEase(Ease.OutCubic);

            return sequence;
        }

        public static Sequence HideCircle(Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(shapeIcon.DOFade(0f, 1f));
            sequence.Join(shapeIcon.rectTransform.DOLocalMoveY(-250f, 1f));
            sequence.SetEase(Ease.OutCubic);

            return sequence;
        }

        public static Sequence CircleClicked(Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(shapeIcon.rectTransform.DOPunchScale(-Vector3.one * 0.25f, 1f, 4));

            return sequence;
        }

        public static Sequence CircleHighlight(GlobalValuesSO globalValuesSO, Transform transform)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(1, globalValuesSO.InitialScaleTime));

            return sequence;
        }

        public static Sequence CircleAttack(GlobalValuesSO globalValuesSO, Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(shapeIcon.rectTransform.DOPunchPosition(-shapeIcon.rectTransform.position * 100, globalValuesSO.AttackTime));

            return sequence;
        }

        public static Sequence CircleTakeDamage(GlobalValuesSO globalValuesSO, Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.SetDelay(globalValuesSO.DamageTakenDelay);
            sequence.Append(shapeIcon.rectTransform.DOPunchScale(shapeIcon.transform.localScale, globalValuesSO.DamageTakenTime));

            return sequence;
        }

        #endregion Circle

        #region Square

        public static Sequence ShowSquare(Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(shapeIcon.DOFade(1f, 1f));
            sequence.Join(shapeIcon.rectTransform.DOLocalMoveX(0f, 1f));
            sequence.SetEase(Ease.OutCubic);

            return sequence;
        }

        public static Sequence HideSquare(Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(shapeIcon.DOFade(0f, 1f));
            sequence.Join(shapeIcon.rectTransform.DOLocalMoveX(250f, 1f));
            sequence.SetEase(Ease.OutCubic);

            return sequence;
        }

        public static Sequence SquareClicked(GlobalValuesSO globalValuesSO, Transform transform, Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform
                .DOJump(transform.position, globalValuesSO.JumpPower, globalValuesSO.JumpCount, globalValuesSO.JumpDuration));
            sequence.Join(shapeIcon.rectTransform.DOLocalRotate(new(0, 0, -180), 1f, RotateMode.FastBeyond360)
                .SetRelative().SetEase(Ease.OutQuint));

            return sequence;
        }

        public static Sequence SquareHighlight(GlobalValuesSO globalValuesSO, Transform transform)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(1, globalValuesSO.InitialScaleTime));

            return sequence;
        }

        public static Sequence SquareAttack(GlobalValuesSO globalValuesSO, Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(shapeIcon.rectTransform.DOPunchPosition(-shapeIcon.rectTransform.position * 100, globalValuesSO.AttackTime));

            return sequence;
        }

        public static Sequence SquareTakeDamage(GlobalValuesSO globalValuesSO, Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.SetDelay(globalValuesSO.DamageTakenDelay);
            sequence.Append(shapeIcon.rectTransform.DOPunchScale(shapeIcon.transform.localScale, globalValuesSO.DamageTakenTime));

            return sequence;
        }

        #endregion Square

        public static Sequence ShowShape(ShapeTypes shapeType, Image shapeIcon)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(shapeIcon.DOFade(1f, 1f));
            sequence.Join(shapeIcon.rectTransform.DOLocalMoveY(0f, 1f));
            sequence.SetEase(Ease.OutCubic);

            return sequence;
        }

        public static Sequence HideShape(ShapeTypes shapeType, Image shapeIcon)
        {
            switch (shapeType)
            {
                case ShapeTypes.Triangle:
                    return HideTriangle(shapeIcon);

                case ShapeTypes.Circle:
                    return HideCircle(shapeIcon);

                case ShapeTypes.Square:
                    return HideSquare(shapeIcon);

                default:
                    return null;
            }
        }

        public static Sequence ShapeAttack(ShapeTypes shapeType, GlobalValuesSO globalValuesSO, Image shapeIcon)
        {
            switch (shapeType)
            {
                case ShapeTypes.Triangle:
                    return TriangleAttack(globalValuesSO, shapeIcon);

                case ShapeTypes.Circle:
                    return CircleAttack(globalValuesSO, shapeIcon);

                case ShapeTypes.Square:
                    return SquareAttack(globalValuesSO, shapeIcon);

                default:
                    return null;
            }
        }

        public static Sequence ShapeTakeDamage(ShapeTypes shapeType, GlobalValuesSO globalValuesSO, Image shapeIcon)
        {
            switch (shapeType)
            {
                case ShapeTypes.Triangle:
                    return TriangleTakeDamage(globalValuesSO, shapeIcon);

                case ShapeTypes.Circle:
                    return CircleTakeDamage(globalValuesSO, shapeIcon);

                case ShapeTypes.Square:
                    return SquareTakeDamage(globalValuesSO, shapeIcon);

                default:
                    return null;
            }
        }

        #endregion Public methods
    }
}