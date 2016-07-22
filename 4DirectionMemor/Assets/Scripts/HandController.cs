using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandController : MonoBehaviour {

    public enum HandState {
        Setup,
        SelectCard,
        UseCard
    }

    public int NumberOfBeginCard;
    public float CardDistance;
    public float HandYPosition;
    public float UseCardYPosition;

    public List<Transform> HandCardList = new List<Transform>();
    public HandState CurrentHandState;

    public List<Transform> CardInEffectList = new List<Transform>();

    public delegate void UseCardEventHandler(Card card);
    public static event UseCardEventHandler OnUseCard;

    // Use this for initialization
    void Start() {
        PlayerController.OnCardPlayed += CardEffectFinish;
    }

    // Update is called once per frame
    void Update() {
        if (CurrentHandState == HandState.Setup) {
            DecideHandBeginOrder();
        } else if (CurrentHandState == HandState.SelectCard) {
            SelectCard();
        }
    }

    Collider2D GetClickedCard() {
        Collider2D card = null;
        if (Input.GetMouseButtonDown(0)) {
            card = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), LayerMask.GetMask(new string[] { "Card" }));
        }
        return card;
    }

    void DecideHandBeginOrder() {
        Collider2D card = GetClickedCard();
        if (card != null) {
            if (!HandCardList.Contains(card.transform)) {
                HandCardList.Add(card.transform);
            }
            ArrangeCardInHand();
            //Change the hand state to select card state after all card is set
            if (HandCardList.Count >= NumberOfBeginCard) {
                CurrentHandState = HandState.SelectCard;
            }
        }
    }

    public void ArrangeCardInHand() {
        foreach (Transform card in HandCardList) {
            float handLeftMost = -((HandCardList.Count - 1) / 2.0f) * CardDistance;
            float zDistance = 1.0f / HandCardList.Count;
            int indexOfCard = HandCardList.IndexOf(card);
            Vector3 targetPosition = new Vector3(handLeftMost + indexOfCard * CardDistance, HandYPosition, 1 - zDistance * indexOfCard);
            iTween.Stop(card.gameObject);
            iTween.MoveTo(card.gameObject, iTween.Hash("position", targetPosition, "time", 1f, "islocal", true));
            card.gameObject.ScaleTo(Vector3.one * 3, 1f, 0);
            card.gameObject.RotateTo(new Vector3(0, 180, 0), 1f, 1f);
        }
    }

    public void ArrangeCardInUse() {
        foreach (Transform card in CardInEffectList) {
            float handLeftMost = -((CardInEffectList.Count - 1) / 2.0f) * CardDistance;
            float zDistance = 1.0f / CardInEffectList.Count;
            int indexOfCard = CardInEffectList.IndexOf(card);
            Vector3 targetPosition = new Vector3(handLeftMost + indexOfCard * CardDistance, UseCardYPosition, 0 - zDistance * indexOfCard);
            iTween.Stop(card.gameObject);
            iTween.MoveTo(card.gameObject, iTween.Hash("position", targetPosition, "time", 1f, "islocal", true));
            card.gameObject.ScaleTo(Vector3.one * 3, 1f, 0);
            card.gameObject.RotateTo(new Vector3(0, 0, 0), 1f, 0f);
        }
    }

    void SelectCard() {
        Collider2D card = GetClickedCard();
        if (card != null) {
            CurrentHandState = HandState.UseCard;
            HandCardList.Remove(card.transform);
            ArrangeCardInHand();
            if (!CardInEffectList.Contains(card.transform))
                CardInEffectList.Add(card.transform);
            ArrangeCardInUse();
            if (OnUseCard != null) {
                OnUseCard(card.GetComponent<Card>());
            }
        }
    }

    void CardEffectFinish(Card card) {
        if(!HandCardList.Contains(card.transform))
            HandCardList.Add(card.transform);
        ArrangeCardInHand();
        CardInEffectList.Remove(card.transform);
        ArrangeCardInUse();
        CurrentHandState = HandState.SelectCard;
    }

    void OnDestroy() {
        PlayerController.OnCardPlayed -= CardEffectFinish;
    }
}
