using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecklistTasks {
    static Dictionary<int, string> list;

    static void Main()
    {
        list = new Dictionary<int, string>();
        list.Add(1,"Stop Alarm Clock");
    }
}
