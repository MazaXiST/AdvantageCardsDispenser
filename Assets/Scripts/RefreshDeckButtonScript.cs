using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class RefreshDeckButtonScript : MonoBehaviour
    {
        private GameObject[] cardObjects;
        private AdvantageDeckManager deck;
        private List<Image> advantageCards = new List<Image>();

        // Start is called before the first frame update
        void Start()
        {
            deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<AdvantageDeckManager>();

            cardObjects = GameObject.FindGameObjectsWithTag("AdvantageCardUI");// GetComponentsInParent<Image>().FirstOrDefault(obj => obj.tag == "AdvantageCard");
            
            foreach(var image in cardObjects)
            {
                 advantageCards.Add(image.GetComponentInChildren<Image>());
            }
        }

        public void Refresh()
        {
            LeanTween.moveLocalY(gameObject, -110, 0.05f);
            LeanTween.moveLocalY(gameObject, -80, 0.1f).setDelay(0.15f); ;


            foreach (var card in advantageCards)
            {
                foreach(var bonusImage in card.GetComponentsInChildren<Image>().Where(obj => obj.tag == "AdvantageBonus"))
                {
                    bonusImage.enabled = false;
                }

                foreach (var power in card.GetComponentsInChildren<Text>())
                {
                    power.text = "X";
                }
            }

            GetComponent<AudioSource>().Play();

            foreach (var card in cardObjects)
            {
                LeanTween.rotateZ(card, 179, 0.1f);
            }

            foreach (var card in cardObjects)
            {
                LeanTween.rotateZ(card, 0, 0.1f).setDelay(0.1f);
            }
        }
    }
}
