using System;

namespace CSSLayoutApp
{
    public delegate void MeasureFunction(ICSSNode node, float width, CSSMeasureMode widthMode, float height, CSSMeasureMode heightMode, MeasureOutput measureOutput);

    public interface ICSSNode : IDisposable
    {
        void Initialize();

        void Reset();

        bool IsDirty { get; set; }

        bool IsTextNode { get; set; }

        bool HasNewLayout { get; set; }

        void MarkLayoutSeen();

        bool ValuesEqual(float f1, float f2);

        ICSSNode this[int index] { get; }

        void Insert(int index, ICSSNode node);

        int IndexOf(ICSSNode node);

        ICSSNode Parent { get; }

        void SetMeasureFunction(MeasureFunction measureFunction);

        bool IsMeasureDefined { get; }

        void CalculateLayout(CSSLayoutContext layoutContext);

        CSSDirection StyleDirection { get; set; }

        CSSFlexDirection FlexDirection { get; set; }

        CSSJustify JustifyContent { get; set; }

        CSSAlign AlignItems { get; set; }

        CSSAlign AlignSelf { get; set; }

        CSSAlign AlignContent { get; set; }

        CSSPositionType PositionType { get; set; }

        CSSWrapType Wrap { get; set; }

        float Flex { get; set; }

        float FlexGrow { get; set; }

        float FlexShrink { get; set; }

        float FlexBasis { get; set; }


    }
}
