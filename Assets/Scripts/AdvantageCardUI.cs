using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{

    public class AdvantageCardUI : MonoBehaviour
    {
        private AdvantageDeckManager deck;
        private Image advantageBonus;

        public Sprite scullSprite;
        public Sprite swordSprite;
        public Sprite towerSprite;

        public void Start()
        {
            deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<AdvantageDeckManager>();
            advantageBonus = GetComponentsInChildren<Image>().FirstOrDefault(obj => obj.tag == "AdvantageBonus");
            advantageBonus.enabled = false;

            LeanTween.moveLocalY(gameObject,10,3).setEaseInOutSine().setLoopPingPong();
        }

        public void GenerateAdvantege()
        {
            LeanTween.rotateZ(gameObject, 90, 0.1f);
            LeanTween.rotateZ(gameObject, 180, 0.1f).setDelay(0.1f);
            LeanTween.rotateZ(gameObject, -90, 0.1f).setDelay(0.2f);
            LeanTween.rotateZ(gameObject, 0, 0.1f).setDelay(0.3f);

            var card = deck.GetACard();

            var power = GetComponentInParent<Image>().GetComponentInChildren<Text>();

            power.text = card.Power.ToString();

            advantageBonus.enabled = false;

            switch (card.Bonus)
            {
                case AdvantageBonus.NONE:
                    advantageBonus.enabled = false; 
                    break;
                case AdvantageBonus.SCULL:
                    advantageBonus.sprite = scullSprite;
                    advantageBonus.enabled = true;
                    break;
                case AdvantageBonus.SWORD:
                    advantageBonus.sprite = swordSprite;
                    advantageBonus.enabled = true;
                    break;
                case AdvantageBonus.TOWER:
                    advantageBonus.sprite = towerSprite;
                    advantageBonus.enabled = true;
                    break;
            }

            GetComponent<AudioSource>().Play();
        }
    }
}
