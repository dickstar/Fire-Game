using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;

public class SaveObjectLoading : MonoBehaviour {
    public GameObject madeObject;

    public void Start()
    {       
        StartCoroutine(generateItems());//參考https://stackoverflow.com/questions/30110131/unity3d-parse-findasync-method-freezes-ui

        //原來Parse官方是用Continue with
        //使用 Task.ContinueWith 方法，它將繼續(continuation)增加到非同步任務中。繼續(continuation)是當前任務完成後接下去執行的任務。        
        //使用Task的好处是知道什么时候完成，可以调用continueWith来处理结果。﻿
    }

    IEnumerator generateItems()
    {        
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("UserName", "user1");
        var task = query.FindAsync();//Task 介紹 http://fanli7.net/a/JAVAbiancheng/ANT/20140414/491760.html
        while (!task.IsCompleted) yield return null; //被调用函数执行到yield return null；（暂停协程，等待下一帧才继续执行）
        //yield 解釋 http://www.proglab.org/2010/01/yield_16.html

        foreach (var result in task.Result)
        {
            Instantiate(madeObject, new Vector3(result.Get<float>("PositionX"), result.Get<float>("PositionY"), result.Get<float>("PositionZ")), new Quaternion(-90, 0, 0, 0));
        }

    }

}
