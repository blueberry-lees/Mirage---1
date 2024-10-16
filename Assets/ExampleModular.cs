using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleModular : MonoBehaviour
{

    public ExampleModular2 testObj;

    [ContextMenu("Test")]
    public void Test()
    {
        testObj.Test();
    }
}
