﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class NodeEditorWindow : EditorWindow
{
    #region Variables
    public static NodeEditorWindow currentEditorWindow;

    public NodePropertyView currentPropertyView;
    public NodeWorkView currentWorkView;
    public NodeGraph currentNodeGraph;

    public float viewPercentage = 0.84f;
    private static GuiStyles styles = new GuiStyles();
    #endregion

    #region Methods
    public static void InitEditorWindow()
    {
        currentEditorWindow = (NodeEditorWindow) EditorWindow.GetWindow<NodeEditorWindow>();
        currentEditorWindow.title = "Node Editor";

        CreateViews();
    }

    public static void DestroyEditor()
    {
        currentEditorWindow.Close();
    }

    void OnEnable()
    {
        Debug.Log("Node Editor Windows was Enabled.");
    }

    void OnDestroy()
    {
        Debug.Log("Node Editor Window was Destroyed.");
    }

    void Update() { }

    void OnGUI()
    {
        if(currentPropertyView == null || currentWorkView == null)
        {
            CreateViews();
            return;
        }

        if (styles == null)
        {
            styles = new GuiStyles();
        }

        Event e = Event.current;
        ProcessEvents(e);

        currentWorkView.isInsidePropertyView = currentPropertyView.viewRect.Contains(e.mousePosition);

        //Workview
        currentWorkView.UpdateView(position, new Rect(0f,0f, viewPercentage, 1f), e, currentNodeGraph);
        currentWorkView.ProcessEvents(e);
        //Properties
        currentPropertyView.UpdateView(new Rect(position.width,position.y,position.width,position.height), 
                                        new Rect(viewPercentage, 0f,1f - viewPercentage, 1f), e, currentNodeGraph);
        currentPropertyView.ProcessEvents(e);

        Repaint();
    }
    #endregion

    #region Utilities
    private static void CreateViews()
    {
        if(currentEditorWindow != null)
        {
            currentEditorWindow.currentPropertyView = new NodePropertyView();
            currentEditorWindow.currentWorkView = new NodeWorkView();
        }
        else
        {
            currentEditorWindow = (NodeEditorWindow)EditorWindow.GetWindow<NodeEditorWindow>();
        }
    }

    private void ProcessEvents(Event e)
    {
        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.A)
        {
            viewPercentage -= 0.01f;
        }
        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.D)
        {
            viewPercentage += 0.01f;
        }
    }
    
    #endregion

}
