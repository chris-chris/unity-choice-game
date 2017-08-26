using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {


	// Singleton class start
	static GameObject _container;
	static GameObject Container {
		get {
			return _container;
		}
	}

	static DataController _instance;
	public static DataController Instance {
		get {
			if( ! _instance ) {
				_container = new GameObject();
				_container.name = "DataController";
				_instance = _container.AddComponent( typeof(DataController) ) as DataController;
				DontDestroyOnLoad (_container);
			}

			return _instance;
		}
	}
	// Singleton class end

	public int Money = 0;
	public int Approval = 0;
	public int Power = 0;
	public int Economy = 0;
	public int Army = 0;
	public int Moral = 0;

	public List<ScenarioItem> ScenarioList;

	public ScenarioItem CurrentScenarioItem;

	public void LoadScenario(){
		TextAsset scenarioText = Resources.Load ("Scenario/GameNormal") as TextAsset;
		string[] list = scenarioText.text.Split ('\n');
		int i = 0;

		ScenarioList = new List<ScenarioItem> ();

		foreach (string line in list) {
			i++;
			if (i == 1)
				continue;

			string[] values = line.Split (',');
			if (values.Length != 16)
				continue;

			ScenarioItem Item = new ScenarioItem ();
			/*
			number,question,
			answer1,money1,approval1,power1,economy1,army1,moral1,
			answer2,money2,approval2,power2,economy2,army2,moral2
			*/
			Item.ID = int.Parse(values [0]);

			Item.Question = values [1];

			Item.Answer1 = values [2];
			Item.Money1 = int.Parse(values [3]);
			Item.Approval1 = int.Parse(values [4]);
			Item.Power1 = int.Parse(values [5]);
			Item.Economy1 = int.Parse(values [6]);
			Item.Army1 = int.Parse(values [7]);
			Item.Moral1 = int.Parse(values [8]);

			Item.Answer2 = values [9];
			Item.Money2 = int.Parse(values [10]);
			Item.Approval2 = int.Parse(values [11]);
			Item.Power2 = int.Parse(values [12]);
			Item.Economy2 = int.Parse(values [13]);
			Item.Army2 = int.Parse(values [14]);
			Item.Moral2 = int.Parse(values [15]);

			ScenarioList.Add (Item);

		}
	}

	public List<ScenarioItem> GetScenarioList(){

		if (ScenarioList == null) {
			LoadScenario ();
		}

		return ScenarioList;

	}

	void Start(){
		LoadScenario ();
	}

}
