using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BehaviourTree : ScriptableObject
{
    public Node rootNode;
    public Node.State treeSate = Node.State.Running;

    public Node.State Update()
    {
        return rootNode.Update();
    }
        
}
