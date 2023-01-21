using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //프리펩 보관할 변수
    public GameObject[] prefabs;

    // 풀 담당할 리스트 
    List<GameObject>[] pools;

    private void Awake() {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++ ) {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index){
        GameObject select = null;
        //비활성화된 풀의 놀고 있는 게임 오브젝트 접근
        //발견하면 select 변수에 할당 
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf){
                //발견하면 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }


        // 찾지 못하면 ?
         
        if (!select)
        { 
            // 새롭게 생성하고 select 변수에 할당
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }

}
