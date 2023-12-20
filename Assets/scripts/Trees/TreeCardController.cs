using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TreeCardController : MonoBehaviour
{
    public GameObject Tree;
    public Image mask;
    public int price;
    public float timeWaitcardActive;
    public Sprite cardactive;
    public Sprite cardnotactive;
    SelectedCusor selectedCusor;
    GameManager gameManager;
    bool isActiveCard;

    Image cur_imgcard;
    private void Start()
    {
        isActiveCard = true;
        gameManager = FindObjectOfType<GameManager>();
        selectedCusor = GameObject.FindAnyObjectByType<SelectedCusor>()
            .GetComponent<SelectedCusor>();
        cur_imgcard = this.GetComponent<Image>();
    }

    private void Update()
    {
        updateStatusCard();

        if(!isActiveCard) StartCoroutine(waitCardactive());
        if (mask.fillAmount>0)
        {
            mask.fillAmount = mask.fillAmount - 1/ timeWaitcardActive * Time.deltaTime;
        }
    }
    public void updateStatusCard()
    {
        if (gameManager.pointsManager.cur_points < price)
        {
            isActiveCard = false;
            cur_imgcard.sprite = cardnotactive;
        }
        if(!isActiveCard)
        {
            cur_imgcard.sprite = cardnotactive;
            
        }
        else cur_imgcard.sprite = cardactive;
    }
    private void OnMouseDown()
    {
        if (mask.fillAmount > 0 || !isActiveCard || selectedCusor.cur_Item != null) return;
        Debug.Log("this ok ");
        selectedCusor.cur_tree = Tree;
        selectedCusor.priceOftree = price;
        selectedCusor.isSelected = false;
        isActiveCard = false;
        mask.fillAmount = 1f;
        gameManager.pointsManager.addPoint(-price);
        
    }

    IEnumerator waitCardactive()
    {
        yield return new WaitUntil(()=> mask.fillAmount ==0);
        if(gameManager.pointsManager.cur_points >= price)
            isActiveCard = true;
    }
}
