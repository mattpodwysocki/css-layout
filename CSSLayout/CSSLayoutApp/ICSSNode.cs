using System;

namespace CSSLayoutApp
{
    public delegate void MeasureFunction(ICSSNode node, float width, CSSMeasureMode widthMode, float height, CSSMeasureMode heightMode, MeasureOutput measureOutput);

    public interface ICSSNode : IDisposable
    {
        void Initialize();

        void Reset();

        bool IsDirty { get; }

        void MarkDirty();

        bool IsTextNode { get; set; }

        bool HasNewLayout { get; set; }

        void MarkLayoutSeen();

        bool ValuesEqual(float f1, float f2);

        ICSSNode this[int index] { get; }

        int Count { get; set; }

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

        Spacing Margin { get; set; }

        Spacing Padding { get; set; }

        Spacing Border { get; set; }

        Spacing Position { get; set; }

        float StyleWidth { get; set; }

        float StyleHeight { get; set; }

        float StyleMaxWidth { get; set; }

        float StyleMaxHeight { get; set; }

        float StyleMinWidth { get; set; }

        float StyleMinHeight { get; set; }

        float LayoutX { get; set; }

        float LayoutY { get; set; }

        float LayoutWidth { get; set; }

        float LayoutHeight { get; set; }

        CSSDirection LayoutDirection { get; }

        CSSOverflow Overflow { get; set; }

        object Data { get; set; }
    }
}
