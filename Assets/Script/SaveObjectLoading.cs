using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;

public class SaveObjectLoading : MonoBehaviour {
    public GameObject madeObject;

    public void Start()
    {       
        StartCoroutine(generateItems());        
    }

    IEnumerator generateItems()
    {
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("UserName", "user1");
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        
        foreach (var result in task.Result)
        {
            Instantiate(madeObject, new Vector3(result.Get<float>("PositionX"), result.Get<float>("PositionY"), result.Get<float>("PositionZ")), new Quaternion(-90, 0, 0, 0));
        }

    }

}
