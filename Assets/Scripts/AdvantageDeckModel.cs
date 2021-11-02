using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class AdvantageDeckModel : MonoBehaviour
    {
        private System.Random randomCard = new System.Random();
        private List<AdvantageCardModel> _deck = new List<AdvantageCardModel>();

        public List<AdvantageCardModel> Deck
        {
            get => _deck;
        }

        public void CollectDeck()
        {
            if (_deck.Count > 0)
            {
                _deck.Clear();
            }

            for (int i = 0; i < 2; i++)
            {
                _deck.Add(new AdvantageCardModel(AdvantagePowerAndBonus.ZERO_WITH_SCULL));
            }

            for (int i = 0; i < 8; i++)
            {
                _deck.Add(new AdvantageCardModel(AdvantagePowerAndBonus.ZERO));
            }

            for (int i = 0; i < 4; i++)
            {
                _deck.Add(new AdvantageCardModel(AdvantagePowerAndBonus.ONE_WITH_TOWER));
            }

            for (int i = 0; i < 4; i++)
            {
                _deck.Add(new AdvantageCardModel(AdvantagePowerAndBonus.ONE_WITH_SWORD));
            }

            for (int i = 0; i < 4; i++)
            {
                _deck.Add(new AdvantageCardModel(AdvantagePowerAndBonus.TWO));
            }

            for (int i = 0; i < 2; i++)
            {
                _deck.Add(new AdvantageCardModel(AdvantagePowerAndBonus.THREE));
            }
        }

        public AdvantageDeckModel()
        {
            CollectDeck();
        }

        public AdvantageCardModel DrawACard()
        {
            if(_deck.Count == 0)
            {
                CollectDeck();
            }

            var card = _deck.ElementAt(randomCard.Next(_deck.Count));
            _deck.Remove(card);

            return card;
        }
    }
}