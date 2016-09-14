using UnityEngine;
using System;

[Serializable]
public class NodeInput
{
    public bool isOccupied;
    public Rect rect = new Rect(0f, 0f, 20f, 20f);
    public int position; // index of the NodeInput Handle 
    public int outputPos; // index of the NodeOutput Handle that connects to the NodeInput
    public NodeBase inputNode;

    public void updatePosition()
    {
        rect.x = inputNode.nodeRect.x - 10f;
        rect.y = inputNode.nodeRect.y + (inputNode.nodeRect.height * (1f / (inputNode.nodeInputs.Count + 1))) * (position + 1) - 10f;
    }

    public Rect getOutputPosRect()
    {
        return inputNode.nodeOutputs[outputPos].rect;
    }

    public NodeOutput getConnectedOutput()
    {
        return inputNode.nodeOutputs[outputPos];
    }
}
