using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class AdvantageDeckManager : MonoBehaviour
    {
        private readonly UInt16 _fullDeckSize = 24;
        private readobly UInt16 _cardsDrawedToRefresh = 3;
        private AdvantageDeckModel _deck;

        public AdvantageCardModel GetACard()
        {
            if(_deck.Deck.Count == _fullDeckSize - _cardsDrawedToRefresh)
            {
                GameObject.Find("RefreshDeckButton").GetComponent<Button>().onClick.Invoke();
            }
            return _deck.DrawACard();
        }

        public int GetDeckSize()
        {
            return _deck.Deck.Count;
        }

        public void RefreshDeck()
        {
            _deck.CollectDeck();
        }

        // Start is called before the first frame update
        void Start()
        {
            _deck = new AdvantageDeckModel();
        }

    }
}
