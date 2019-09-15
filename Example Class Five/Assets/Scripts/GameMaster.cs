using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject[] Cards;
    public GameObject cardOne;
    public GameObject cardTwo;
    Card cardScript;
    public int count;
    public GameObject card;

    // Use this for initialization
    void Start (){
		SortCards();
		PlaceCards();
        cardOne = null;
        cardTwo = null;
        count = 3;
        cardScript = card.GetComponent<Card>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}


	void SortCards()
	{
		// https://en.wikipedia.org/wiki/Fisher-Yates_shuffle
		for (int i = 0; i < Cards.Length; i++)
		{
			int j = Random.Range(i, Cards.Length );

			GameObject temp = Cards[i];
			Cards[i] = Cards[j];
			Cards[j] = temp;
		}
	}

	void PlaceCards()
	{
		for (int i = 0; i < Cards.Length; i++)
		{
			int row = Mathf.FloorToInt( i / 3 );
			int col = i % 3;

			float x = -4f + (4 * col);
			float y = -2.5f + (-5 * row);

			Vector3 position = new Vector3(x, y, 0);
			Cards[i].transform.localPosition = position;
		}
	}

    public void AddCard(GameObject card)
    {
        if(cardOne == null)
        {
            cardOne = card;
        }
        else
        {
            cardTwo = card;
        }


        if (cardOne != null && cardTwo != null)
        {
            if (CheckMatch())
            {
                cardOne.gameObject.SetActive(false);
                cardTwo.gameObject.SetActive(false);
                cardOne = null;
                cardTwo = null;
                count--;
            }
            else
            {
                Invoke("FlipAfterTime", 1.3f);
            }

        }

    }

    public bool CheckMatch()
    {
        if(cardOne.gameObject.tag == cardTwo.gameObject.tag)
        {
            return true;
        }
        return false;
    }

    public void FlipAfterTime()
    {
        cardOne.GetComponent<Card>().Flip();
        cardTwo.GetComponent<Card>().Flip();
        cardOne = null;
        cardTwo = null;
    }

}
