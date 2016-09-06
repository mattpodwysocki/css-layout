/**
 * Copyright (c) 2014-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 */

#pragma once

#include <assert.h>
#include <math.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>

#ifndef __cplusplus
#include <stdbool.h>
#endif

// Not defined in MSVC++
#ifndef NAN
static const unsigned long __nan[2] = {0xffffffff, 0x7fffffff};
#define NAN (*(const float *) __nan)
#endif

#define CSSUndefined NAN

#include "CSSMacros.h"

CSS_EXTERN_C_BEGIN

__declspec(dllexport) typedef enum CSSDirection {
  CSSDirectionInherit,
  CSSDirectionLTR,
  CSSDirectionRTL,
} CSSDirection;

__declspec(dllexport) typedef enum CSSFlexDirection {
  CSSFlexDirectionColumn,
  CSSFlexDirectionColumnReverse,
  CSSFlexDirectionRow,
  CSSFlexDirectionRowReverse,
} CSSFlexDirection;

__declspec(dllexport) typedef enum CSSJustify {
  CSSJustifyFlexStart,
  CSSJustifyCenter,
  CSSJustifyFlexEnd,
  CSSJustifySpaceBetween,
  CSSJustifySpaceAround,
} CSSJustify;

__declspec(dllexport) typedef enum CSSOverflow {
  CSSOverflowVisible,
  CSSOverflowHidden,
} CSSOverflow;

// Note: auto is only a valid value for alignSelf. It is NOT a valid value for
// alignItems.
__declspec(dllexport) typedef enum CSSAlign {
  CSSAlignAuto,
  CSSAlignFlexStart,
  CSSAlignCenter,
  CSSAlignFlexEnd,
  CSSAlignStretch,
} CSSAlign;

__declspec(dllexport) typedef enum CSSPositionType {
  CSSPositionTypeRelative,
  CSSPositionTypeAbsolute,
} CSSPositionType;

__declspec(dllexport) typedef enum CSSWrapType {
  CSSWrapTypeNoWrap,
  CSSWrapTypeWrap,
} CSSWrapType;

__declspec(dllexport) typedef enum CSSMeasureMode {
  CSSMeasureModeUndefined,
  CSSMeasureModeExactly,
  CSSMeasureModeAtMost,
  CSSMeasureModeCount,
} CSSMeasureMode;

__declspec(dllexport) typedef enum CSSDimension {
  CSSDimensionWidth,
  CSSDimensionHeight,
} CSSDimension;

__declspec(dllexport) typedef enum CSSEdge {
  CSSEdgeLeft,
  CSSEdgeTop,
  CSSEdgeRight,
  CSSEdgeBottom,
  CSSEdgeStart,
  CSSEdgeEnd,
  CSSEdgeHorizontal,
  CSSEdgeVertical,
  CSSEdgeAll,
  CSSEdgeCount,
} CSSEdge;

__declspec(dllexport) typedef enum CSSPrintOptions {
  CSSPrintOptionsLayout = 1,
  CSSPrintOptionsStyle = 2,
  CSSPrintOptionsChildren = 4,
} CSSPrintOptions;

__declspec(dllexport) typedef struct CSSSize {
  float width;
  float height;
} CSSSize;

__declspec(dllexport) typedef struct CSSNode *CSSNodeRef;
__declspec(dllexport) typedef CSSSize (*CSSMeasureFunc)(void *context,
                                  float width,
                                  CSSMeasureMode widthMode,
                                  float height,
                                  CSSMeasureMode heightMode);
typedef void (*CSSPrintFunc)(void *context);

// CSSNode
__declspec(dllexport) CSSNodeRef CSSNodeNew();
__declspec(dllexport) void CSSNodeInit(const CSSNodeRef node);
__declspec(dllexport) void CSSNodeFree(const CSSNodeRef node);

__declspec(dllexport) void CSSNodeInsertChild(const CSSNodeRef node, const CSSNodeRef child, const uint32_t index);
__declspec(dllexport) void CSSNodeRemoveChild(const CSSNodeRef node, const CSSNodeRef child);
__declspec(dllexport) CSSNodeRef CSSNodeGetChild(const CSSNodeRef node, const uint32_t index);
__declspec(dllexport) uint32_t CSSNodeChildCount(const CSSNodeRef node);

__declspec(dllexport) void CSSNodeCalculateLayout(const CSSNodeRef node,
                            const float availableWidth,
                            const float availableHeight,
                            const CSSDirection parentDirection);

// Mark a node as dirty. Only valid for nodes with a custom measure function
// set.
// CSSLayout knows when to mark all other nodes as dirty but because nodes with
// measure functions
// depends on information not known to CSSLayout they must perform this dirty
// marking manually.
__declspec(dllexport) void CSSNodeMarkDirty(const CSSNodeRef node);
__declspec(dllexport) bool CSSNodeIsDirty(const CSSNodeRef node);

__declspec(dllexport) void CSSNodePrint(const CSSNodeRef node, const CSSPrintOptions options);

__declspec(dllexport) bool CSSValueIsUndefined(const float value);

#define CSS_NODE_PROPERTY(type, name, paramName)                \
  __declspec(dllexport) void CSSNodeSet##name(const CSSNodeRef node, type paramName); \
  __declspec(dllexport) type CSSNodeGet##name(const CSSNodeRef node);

#define CSS_NODE_STYLE_PROPERTY(type, name, paramName)                     \
  __declspec(dllexport) void CSSNodeStyleSet##name(const CSSNodeRef node, const type paramName); \
  __declspec(dllexport) type CSSNodeStyleGet##name(const CSSNodeRef node);

#define CSS_NODE_STYLE_EDGE_PROPERTY(type, name, paramName)                                    \
  __declspec(dllexport) void CSSNodeStyleSet##name(const CSSNodeRef node, const CSSEdge edge, const type paramName); \
  __declspec(dllexport) type CSSNodeStyleGet##name(const CSSNodeRef node, const CSSEdge edge);

#define CSS_NODE_LAYOUT_PROPERTY(type, name) __declspec(dllexport) type CSSNodeLayoutGet##name(const CSSNodeRef node);

CSS_NODE_PROPERTY(void *, Context, context);
CSS_NODE_PROPERTY(CSSMeasureFunc, MeasureFunc, measureFunc);
CSS_NODE_PROPERTY(CSSPrintFunc, PrintFunc, printFunc);
CSS_NODE_PROPERTY(bool, IsTextnode, isTextNode);
CSS_NODE_PROPERTY(bool, HasNewLayout, hasNewLayout);

CSS_NODE_STYLE_PROPERTY(CSSDirection, Direction, direction);
CSS_NODE_STYLE_PROPERTY(CSSFlexDirection, FlexDirection, flexDirection);
CSS_NODE_STYLE_PROPERTY(CSSJustify, JustifyContent, justifyContent);
CSS_NODE_STYLE_PROPERTY(CSSAlign, AlignContent, alignContent);
CSS_NODE_STYLE_PROPERTY(CSSAlign, AlignItems, alignItems);
CSS_NODE_STYLE_PROPERTY(CSSAlign, AlignSelf, alignSelf);
CSS_NODE_STYLE_PROPERTY(CSSPositionType, PositionType, positionType);
CSS_NODE_STYLE_PROPERTY(CSSWrapType, FlexWrap, flexWrap);
CSS_NODE_STYLE_PROPERTY(CSSOverflow, Overflow, overflow);
CSS_NODE_STYLE_PROPERTY(float, Flex, flex);
CSS_NODE_STYLE_PROPERTY(float, FlexGrow, flexGrow);
CSS_NODE_STYLE_PROPERTY(float, FlexShrink, flexShrink);
CSS_NODE_STYLE_PROPERTY(float, FlexBasis, flexBasis);

CSS_NODE_STYLE_EDGE_PROPERTY(float, Position, position);
CSS_NODE_STYLE_EDGE_PROPERTY(float, Margin, margin);
CSS_NODE_STYLE_EDGE_PROPERTY(float, Padding, padding);
CSS_NODE_STYLE_EDGE_PROPERTY(float, Border, border);

CSS_NODE_STYLE_PROPERTY(float, Width, width);
CSS_NODE_STYLE_PROPERTY(float, Height, height);
CSS_NODE_STYLE_PROPERTY(float, MinWidth, minWidth);
CSS_NODE_STYLE_PROPERTY(float, MinHeight, minHeight);
CSS_NODE_STYLE_PROPERTY(float, MaxWidth, maxWidth);
CSS_NODE_STYLE_PROPERTY(float, MaxHeight, maxHeight);

CSS_NODE_LAYOUT_PROPERTY(float, Left);
CSS_NODE_LAYOUT_PROPERTY(float, Top);
CSS_NODE_LAYOUT_PROPERTY(float, Right);
CSS_NODE_LAYOUT_PROPERTY(float, Bottom);
CSS_NODE_LAYOUT_PROPERTY(float, Width);
CSS_NODE_LAYOUT_PROPERTY(float, Height);
CSS_NODE_LAYOUT_PROPERTY(CSSDirection, Direction);

CSS_EXTERN_C_END
