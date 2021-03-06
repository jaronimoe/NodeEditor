﻿using UnityEngine;
using UnityEditor;
using System.Collections;

public static class NodeUtilities
{
    public static void CreateNewGraph(string wantedName)
    {
        NodeGraph currentNodeGraph = CreateAndSaveGraph(wantedName);
        DisplayGraph(currentNodeGraph);
    }

    public static NodeGraph CreateAndSaveGraph(string wantedName)
    {
        NodeGraph currentNodeGraph = (NodeGraph)ScriptableObject.CreateInstance<NodeGraph>();

        if (currentNodeGraph != null)
        {
            currentNodeGraph.graphName = wantedName;
            currentNodeGraph.InitGraph();

            AssetDatabase.CreateAsset(currentNodeGraph, "Assets/SimpleMathNodeEditor/Database/" + wantedName + ".asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            return currentNodeGraph;
        }
        else
        {
            return null;
        }
    }

    public static void LoadGraph()
    {
        NodeGraph currentNodeGraph = null;

        currentNodeGraph = getSavedNodegraph();
        DisplayGraph(currentNodeGraph);
    }
    
    public static void DisplayGraph(NodeGraph currentGraph)
    {
        if (currentGraph != null)
        {
            NodeEditorWindow currentWindow = (NodeEditorWindow)EditorWindow.GetWindow<NodeEditorWindow>();
            if (currentGraph != null)
            {
                currentWindow.currentNodeGraph = currentGraph;
                NodeGraph.Instance = currentGraph;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Node Message", "Unable to load graph!", "OK");
        }
    }

    public static NodeGraph getSavedNodegraph()
    {
        string graphPath = EditorUtility.OpenFilePanel("Load Graph", Application.dataPath + "/SimpleMathNodeEditor/Database/", "");

        Debug.Log(graphPath);

        int pathLength = Application.dataPath.Length;

        string finalPath = graphPath.Substring(pathLength - 6); // remove .asset extension from Path

        return (NodeGraph)AssetDatabase.LoadAssetAtPath(finalPath, typeof(NodeGraph));
    }

    public static void UnloadGraph()
    {
        NodeEditorWindow currentWindow = (NodeEditorWindow)EditorWindow.GetWindow<NodeEditorWindow>();
        if (currentWindow != null)
        {
            currentWindow.currentNodeGraph = null;
        }
    }

    public static void CreateNode(NodeGraph currentGraph, NodeDescriptor nodeDescriptor, Vector2 mousePos)
    {
        if (currentGraph != null)
        {
            NodeBase currentNode = CreateNode(nodeDescriptor);
            positionNode(currentNode, currentGraph, mousePos);
            saveNode(currentNode, currentGraph);
        }
    }
    
    public static NodeBase CreateNode(NodeDescriptor descriptor)
    {
        NodeBase currentNode = null;
        
        if(descriptor.nodeType == NodeType.Graph)
        {
            currentNode = ScriptableObject.CreateInstance<NodeBase>();
        }
        else
        {
            currentNode = ScriptableObject.CreateInstance<NodeBase>();
            currentNode.InitNodeFromDescriptor(descriptor);
        }
                
        return currentNode;
    }

    public static void positionNode(NodeBase currentNode, NodeGraph currentGraph, Vector2 mousePos)
    {
        if (currentNode != null)
        {
            currentNode.InitNode();
            currentNode.nodeRect.x = mousePos.x;
            currentNode.nodeRect.y = mousePos.y;
            currentNode.parentGraph = currentGraph;
            currentNode.timePointer.arrowRect.x = (currentNode.nodeRect.x + currentNode.nodeRect.width * 0.5f) - (currentNode.timePointer.arrowRect.width * 0.5f);
            currentGraph.nodes.Add(currentNode);
        }
    }

    public static void saveNode(NodeBase currentNode, NodeGraph currentGraph)
    {
        if (currentNode != null)
        {
            AssetDatabase.AddObjectToAsset(currentNode, currentGraph);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }

    public static void DeleteNode(NodeBase currentNode, NodeGraph currentGraph)
    {
        if (currentGraph != null)
        {
            currentGraph.nodes.Remove(currentNode);
            GameObject.DestroyImmediate(currentNode, true);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
