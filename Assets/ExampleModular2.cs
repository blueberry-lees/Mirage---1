using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleModular2 : MonoBehaviour
{
    public GameObject test;

    [ContextMenu("Test")]
    public void Test()
    {
        test.SetActive(true);
    }
}
