using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeRunner : MonoBehaviour
{

    BehaviourTree tree;
    // Start is called before the first frame update
    void Start()
    {
        tree = ScriptableObject.CreateInstance<BehaviourTree>();
        var log = ScriptableObject.CreateInstance<DebugLogNode>();
        log.message = "Running BT";

        var loopNode = ScriptableObject.CreateInstance<RepeatNode>();
        loopNode.child = log;

        tree.rootNode = loopNode;
    }

    // Update is called once per frame
    void Update()
    {
        tree.Update();
    }
}
