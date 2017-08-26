using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text Money;
	public Text Approval;
	public Text Power;
	public Text Economy;
	public Text Army;
	public Text Moral;

	public Text Question;
	public Text Answer1;
	public Text Answer2;

	// Use this for initialization
	void Start () {
		UpdateStat ();
		LoadQuestion ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpdateStat(){
		Money.text = DataController.Instance.Money.ToString ();
		Approval.text = DataController.Instance.Approval.ToString ();
		Power.text = DataController.Instance.Power.ToString ();
		Economy.text = DataController.Instance.Economy.ToString ();
		Army.text = DataController.Instance.Army.ToString ();
		Moral.text = DataController.Instance.Moral.ToString ();
	}

	void LoadQuestion(){
		List<ScenarioItem> list = DataController.Instance.GetScenarioList ();
		int idx = Random.Range (0, list.Count - 1);
		DataController.Instance.CurrentScenarioItem = list [idx];

		Question.text = DataController.Instance.CurrentScenarioItem.Question;
		Answer1.text = DataController.Instance.CurrentScenarioItem.Answer1;
		Answer2.text = DataController.Instance.CurrentScenarioItem.Answer2;
	}

	public void OnClickAnswer1(){
		DataController.Instance.Money += DataController.Instance.CurrentScenarioItem.Money1;
		DataController.Instance.Approval += DataController.Instance.CurrentScenarioItem.Approval1;
		DataController.Instance.Power += DataController.Instance.CurrentScenarioItem.Power1;
		DataController.Instance.Economy += DataController.Instance.CurrentScenarioItem.Economy1;
		DataController.Instance.Army += DataController.Instance.CurrentScenarioItem.Army1;
		DataController.Instance.Moral += DataController.Instance.CurrentScenarioItem.Moral1;
		UpdateStat ();
		LoadQuestion ();
	}

	public void OnClickAnswer2(){
		DataController.Instance.Money += DataController.Instance.CurrentScenarioItem.Money2;
		DataController.Instance.Approval += DataController.Instance.CurrentScenarioItem.Approval2;
		DataController.Instance.Power += DataController.Instance.CurrentScenarioItem.Power2;
		DataController.Instance.Economy += DataController.Instance.CurrentScenarioItem.Economy2;
		DataController.Instance.Army += DataController.Instance.CurrentScenarioItem.Army2;
		DataController.Instance.Moral += DataController.Instance.CurrentScenarioItem.Moral2;
		UpdateStat ();
		LoadQuestion ();
	
	}
}
