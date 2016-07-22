using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Node CurrentAtNode;
    public float MoveSpeed;

    public delegate void CardPlayedEventHandler(Card card);
    public static event CardPlayedEventHandler OnCardPlayed;

    Animator _animator;
    GameObject _barrierOnRoad;
    GameManager _gm;
    HandController _hand;
    // Use this for initialization
    void Start() {
        _animator = GetComponent<Animator>();
        _gm = FindObjectOfType<GameManager>();
        _hand = FindObjectOfType<HandController>();
        HandController.OnUseCard += PlayCard;
    }


    void PlayCard(Card card) {
        if (CheckRoadAhead(card.ThisCardType)) {
            //If the player is using a directional card
            _animator.SetBool("walking", true);
            float nodeDistance = 0;
            if (card.ThisCardType == Card.CardType.up) {
                nodeDistance = Vector3.Distance(CurrentAtNode.transform.position, CurrentAtNode.UpNode.transform.position);
                CurrentAtNode = CurrentAtNode.UpNode;
                _animator.Play("BackRun");
            } else if (card.ThisCardType == Card.CardType.down) {
                nodeDistance = Vector3.Distance(CurrentAtNode.transform.position, CurrentAtNode.DownNode.transform.position);
                CurrentAtNode = CurrentAtNode.DownNode;
                _animator.Play("FrontRun");
            } else if (card.ThisCardType == Card.CardType.left) {
                nodeDistance = Vector3.Distance(CurrentAtNode.transform.position, CurrentAtNode.LeftNode.transform.position);
                CurrentAtNode = CurrentAtNode.LeftNode;
                _animator.Play("LeftRun");
            } else if (card.ThisCardType == Card.CardType.right) {
                nodeDistance = Vector3.Distance(CurrentAtNode.transform.position, CurrentAtNode.RightNode.transform.position);
                CurrentAtNode = CurrentAtNode.RightNode;
                _animator.Play("RightRun");
            }
            iTween.MoveTo(gameObject,
                    iTween.Hash("position", CurrentAtNode.transform.position + Vector3.up * 0.5f,
                                "time", nodeDistance / MoveSpeed,
                                "delay", 0,
                                "easetype", iTween.EaseType.linear,
                                "oncomplete", "CardPlayed",
                                "oncompleteparams", card));
        } else {
            //If the player is using a functional card
            if (_barrierOnRoad != null && card.ThisCardType == Card.CardType.key) {
                _hand.CardInEffectList.Remove(card.transform);
                Destroy(card.gameObject, 1f);
                Destroy(_barrierOnRoad);
                _barrierOnRoad = null;
                iTween.Resume();
            } else {
                _gm.ReStartScene();
            }
        }
    }

    //Finished walking and change the animation back to idle
    void CardPlayed(Card card) {
        _animator.SetBool("walking", false);
        Invoke("PickCardInNode", 0.5f);
        if (OnCardPlayed != null) {
            OnCardPlayed(card);
        }
    }

    //Check whether there are road on the direction we choose
    bool CheckRoadAhead(Card.CardType direction) {
        bool haveRoad = false;
        if (direction == Card.CardType.up) {
            if (CurrentAtNode.UpNode != null) {
                haveRoad = true;
            }
        } else if (direction == Card.CardType.down) {
            if (CurrentAtNode.DownNode != null) {
                haveRoad = true;
            }
        } else if (direction == Card.CardType.left) {
            if (CurrentAtNode.LeftNode != null) {
                haveRoad = true;
            }
        } else if (direction == Card.CardType.right) {
            if (CurrentAtNode.RightNode != null) {
                haveRoad = true;
            }
        }
        return haveRoad;
    }

    void PickCardInNode() {
        Collider2D card = Physics2D.OverlapPoint(CurrentAtNode.transform.position, LayerMask.GetMask(new string[] { "Card" }));
        if (card != null) {
            card.transform.parent = _hand.transform;
            _hand.HandCardList.Add(card.transform);
            _hand.ArrangeCardInHand();
        }
    }


    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Prop") {
            iTween.Pause();
            _hand.CurrentHandState = HandController.HandState.SelectCard;
            _barrierOnRoad = col.gameObject;
        }
    }

    void OnDestroy() {
        HandController.OnUseCard -= PlayCard;
    }
}
