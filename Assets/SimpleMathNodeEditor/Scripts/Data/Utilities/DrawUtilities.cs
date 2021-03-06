﻿using UnityEngine;
using UnityEditor;
using System.Collections;

public static class DrawUtilities
{
    public static void DrawNodeCurve(Rect start, Rect end, float inputId, int numberOfInputs)
    {
        Vector3 startPos = new Vector3(start.x + start.width + 10f, start.y + start.height * 0.5f, 0);
        Vector3 endPos = new Vector3(end.x - 10f, end.y + (end.height * (1f / (numberOfInputs + 1))) * inputId, 0);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);

        for (int i = 0; i < 3; i++) // Draw a shadow
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);

        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 2);
    }

    public static void DrawMultiInputNodeCurve(Rect start, Rect end, float inputId)
    {
        Vector3 startPos = new Vector3(start.x + start.width + 10f, start.y + start.height * 0.5f, 0);
        Vector3 endPos = new Vector3(end.x - 24f, end.y + ((end.height + 25f) * 0.5f) * inputId, 0);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);

        for (int i = 0; i < 3; i++) // Draw a shadow
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);

        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 2);
    }
    
    public static void DrawNodeCurve(Rect start, Rect end, Color col)
    {
        Vector3 startPos = new Vector3(start.x + start.width , start.y + start.height * 0.5f, 0);
        Vector3 endPos = new Vector3(end.x , end.y + end.height * 0.5f, 0);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);

        for (int i = 0; i < 3; i++) // Draw a shadow
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);

        Handles.DrawBezier(startPos, endPos, startTan, endTan, col, null, 2);
    }

    public static void DrawNodeCurve(Vector3 start, Rect end, float inputId, int numberOfInputs)
    {
        Vector3 endPos = new Vector3(end.x - 10f, end.y + (end.height * (1f / (numberOfInputs + 1))) * inputId, 0);
        Vector3 startTan = start + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);

        for (int i = 0; i < 3; i++) // Draw a shadow
            Handles.DrawBezier(start, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);

        Handles.DrawBezier(start, endPos, startTan, endTan, Color.black, null, 2);
    }

    public static void DrawMouseCurve(Rect start, Vector3 mousePosition, float thickness)
    {
        Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height * 0.5f, 0);
        Vector3 endPos = mousePosition;
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);

        for (int i = 0; i < 3; i++) // Draw a shadow
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);

        Handles.DrawBezier(startPos, endPos, startTan, endTan, WorkPreferences.nodeCurveColor, null, WorkPreferences.nodeCurveThickness);
    }
    
    public static void DrawNodeCurve(Rect start, Rect end, Color col, float thickness)
    {
        Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height * 0.5f, 0);
        Vector3 endPos = new Vector3(end.x, end.y + (end.height * 0.5f), 0);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);

        for (int i = 0; i < 3; i++) // Draw a shadow
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);

        Handles.DrawBezier(startPos, endPos, startTan, endTan, col, null, thickness);
    }

    public static void DrawCurve(Vector3 start, Vector3 end, Color col, float thickness)
    {
        Vector3 startTan = start + Vector3.right * 50;
        Vector3 endTan = end + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);

        for (int i = 0; i < 3; i++) // Draw a shadow
            Handles.DrawBezier(start, end, startTan, endTan, shadowCol, null, (i + 1) * 5);

        Handles.DrawBezier(start, end, startTan, endTan, col, null, thickness);
    }

    public static void DrawRangeCurve(Vector3 startRange, Vector3 endRange, Vector3 nodeStartPos, Vector3 splitRangePos, Color col,float opacity ,float thickness)
    {
        Color opaqueCol = new Color(col.r, col.g, col.b, opacity);
        Vector3 startTan = startRange - Vector3.up * 50;
        Vector3 endTan = endRange - Vector3.up * 50;
        Vector3 splitRangeTan = splitRangePos + Vector3.up * 50;
       
        Handles.DrawBezier(nodeStartPos, splitRangePos, nodeStartPos, splitRangePos, opaqueCol, null, thickness);
        Handles.DrawBezier(splitRangePos, startRange, splitRangeTan, startTan, opaqueCol, null, thickness);
        Handles.DrawBezier(splitRangePos, endRange, splitRangeTan, endTan, opaqueCol, null, thickness);
    }

    public static void DrawRangeCurveShadow(Vector3 startRange, Vector3 endRange, Vector3 nodeStartPos, Vector3 splitRangePos, Color col, float opacity, float thickness)
    {
        Vector3 startTan = startRange - Vector3.up * 50;
        Vector3 endTan = endRange - Vector3.up * 50;
        Vector3 splitRangeTan = splitRangePos + Vector3.up * 50;

        Color shadowCol = new Color(0, 0, 0, 0.06f);
        for (int i = 0; i < 3; i++) // Draw a shadow
        {
            Handles.DrawBezier(nodeStartPos, splitRangePos, nodeStartPos, splitRangePos, shadowCol, null, (i + 1) * 5);
            Handles.DrawBezier(splitRangePos, startRange, splitRangeTan, startTan, shadowCol, null, (i + 1) * 5);
            Handles.DrawBezier(splitRangePos, endRange, splitRangeTan, endTan, shadowCol, null, (i + 1) * 5);
        }
    }

    public static void DrawGrid(Rect viewRect, float gridSpacing, Color gridColor)
    {
        int widthDivs = Mathf.CeilToInt(viewRect.width / gridSpacing);
        int heightDivs = Mathf.CeilToInt(viewRect.height / gridSpacing);

        Handles.BeginGUI();

        Handles.color = gridColor;

        for (int x = 0; x < widthDivs; x++)
        {
            Handles.DrawLine(new Vector3(gridSpacing * x, 0f, 0f), new Vector3(gridSpacing * x, viewRect.height, 0f));
        }

        for (int y = 0; y < heightDivs; y++)
        {
            Handles.DrawLine(new Vector3(0f, gridSpacing * y, 0f), new Vector3(viewRect.width, gridSpacing * y, 0f));
        }

        Handles.EndGUI();
    }
}
