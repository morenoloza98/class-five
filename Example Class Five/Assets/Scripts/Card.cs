using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	private bool _interactive;
    private bool interactable;
    private bool flipped;
	private bool _flip = true;
    GameMaster gameMasterScript;
    public GameObject gameMaster;
    private GameObject[] cards;

	// Use this for initialization
	void Start () {
		_interactive = true;
        interactable = true;
        flipped = false;
        gameMasterScript = gameMaster.GetComponent<GameMaster>();
        cards = gameMasterScript.Cards;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

	void OnMouseDown()
	{

        if (!flipped)
        {
            gameMasterScript.AddCard(gameObject);
            Flip();
        }

        if (!_interactive)
		{
			return;
		}
	}

	public void Flip()
	{
		_interactive = false;
		iTween.RotateTo(gameObject, iTween.Hash(
			"y", (_flip ? 0 : 180),
			"time", 1,
			"easetype",iTween.EaseType.easeInSine,
			"oncomplete", "EnableInteraction"
			));
		_flip = !_flip;
        flipped = !flipped;
	}

	public void EnableInteraction()
	{
		_interactive = true;
	}



}
