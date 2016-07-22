using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

    public enum CardType {
        up,
        down,
        left,
        right,
        key
    }

    public CardType ThisCardType;
    
}
