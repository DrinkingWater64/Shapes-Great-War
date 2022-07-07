using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeRunner : MonoBehaviour
{

    BehaviourTree tree;
    // Start is called before the first frame update
    void Start()
    {



        var wait0 = ScriptableObject.CreateInstance<WaitNode>();

        tree = ScriptableObject.CreateInstance<BehaviourTree>();
        var log0 = ScriptableObject.CreateInstance<DebugLogNode>();
        log0.message = "Running BT  00000000000";
        var log1 = ScriptableObject.CreateInstance<DebugLogNode>();
        var wait1 = ScriptableObject.CreateInstance<WaitNode>();
        log1.message = "Running BT 1111111111111";
        var log2 = ScriptableObject.CreateInstance<DebugLogNode>();
        var wait2 = ScriptableObject.CreateInstance<WaitNode>();
        log2.message = "Running BT 222222222222222";





        var sequencerTest = ScriptableObject.CreateInstance<SequencerNode>();
        sequencerTest.children.Add(log0);
        sequencerTest.children.Add(wait0);
        sequencerTest.children.Add(log1);
        sequencerTest.children.Add(wait1);
        sequencerTest.children.Add(log2);
        sequencerTest.children.Add(wait2);

        
        var loopNode = ScriptableObject.CreateInstance<RepeatNode>();
        loopNode.child = sequencerTest;




        tree.rootNode = loopNode;
    }

    // Update is called once per frame
    void Update()
    {
        tree.Update();
    }
}
