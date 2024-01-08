using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LinkedList<string> list = new LinkedList<string>();

        list.AddFirst("홍길동");
        list.AddLast("김길동");
        list.AddLast("고길동");
        list.AddLast("최길동");
        list.AddLast("함길동");
        list.AddLast("박길동");

        LinkedListNode<string> node = list.First;

        Debug.Log(list);    
    }
}
