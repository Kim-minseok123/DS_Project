using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
public class testStartServer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var bro = Backend.Initialize(true);
        if (bro.IsSuccess())
        {
            Debug.Log("�ʱ�ȭ ����");
        }
        else {
            Debug.Log("�ʱ�ȭ ����!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Backend.AsyncPoll();
    }
}
