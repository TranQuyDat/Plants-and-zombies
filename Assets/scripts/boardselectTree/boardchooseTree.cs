using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class boardchooseTree : MonoBehaviour
{
    public List<GameObject> listslotCard_view;//la list cac slot o thanh bar  

    public List<GameObject> listTreeSelected;// dung de luu chu cac cell da chon
    

    public GameManager gameManager;

    PlayableDirector playable;
    GameObject cur_selectTree;
    
    private void Start()
    {
        playable = gameManager.gameObject.
            GetComponent<PlayableDirector>();
        playable.Pause();
    }

    private void Update()
    {
        if (gameManager.GameStart)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void btn_Add()
    {
        if (cur_selectTree == null) return;
        cell_boardselectTree cell = cur_selectTree.GetComponent<cell_boardselectTree>();
        for (int i =0; i<listslotCard_view.Count;i++)
        {
            if (cell.ischoosed) return;
            GameObject item = listslotCard_view[i].
                transform.Find("item").gameObject;
            
            if (item.GetComponent<Image>().sprite != null) continue;

            item.SetActive(true);
            listTreeSelected.Add(cur_selectTree);
            
            cell.gameObject.transform.Find("item")
                .GetComponent<Image>().color = Color.gray;
            
            item.GetComponent<Image>()
                .sprite = cur_selectTree.transform.Find("item")
                .GetComponent<Image>().sprite;

            cell.ischoosed = true;
            cur_selectTree = null;
            return;
        }
        
    }

    public void btn_remove()
    {
        
        for (int i = 0; i < listslotCard_view.Count; i++)
        {
            GameObject item = listslotCard_view[i].
                transform.Find("item").gameObject;
            
            item.GetComponent<Image>().sprite = null;
            item.SetActive(false);

            if (listTreeSelected.Count > i)
            {
                cell_boardselectTree cell = listTreeSelected[i].
               GetComponent<cell_boardselectTree>();

                cell.ischoosed = false;
                listTreeSelected[i].transform.Find("item").
                    GetComponent<Image>().color = Color.white;
            }
        }
        listTreeSelected.Clear();
    }
     
    public void btn_start()
    {
        foreach (GameObject item in listTreeSelected) 
        {
            if (item == null) return; 
            gameManager.selectBarController.listselectbar.
                Add(item.GetComponent<cell_boardselectTree>().data);
        }
        gameManager.GameStart = true;

        playable.time = 4;
        playable.Resume();

    }

    public void setcur_selectTree( GameObject obj)
    {
        if (obj == null) return;
        cur_selectTree = obj;
    }
    
}
