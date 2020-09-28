using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurvedMenuController : MonoBehaviour {

    public GameObject scenarioCardPrefab;
    public GameObject personaCardPrefab;
    public List<Transform> CardSpawnpoints;

    private Game game;
    private int MAX_NUMBER_OF_CARD_OPTION_SLOTS = 7;

    private List<GameObject> scenarioCards = new List<GameObject>();
    private List<GameObject> personaCards = new List<GameObject>();

    private void Start() {
        game = GameObject.FindObjectOfType<Game>();
    }

    public void createAllCards() {
        createScenarioCards();
        createPersonaCards();
    }

    public void deactivateAllCardOptions() {
        deactivateScenarioOptions();
        deactivatePersonaOptions();
    }

    public void deactivateScenarioOptions() {
        foreach (GameObject obj in scenarioCards) {
            obj.SetActive(false);
        }
    }

    public void deactivatePersonaOptions() {
        foreach (GameObject obj in personaCards) {
            obj.SetActive(false);
        }
    }

    public void displayScenarioOptions() {
        foreach (GameObject obj in scenarioCards) {
            obj.SetActive(true);
        }
    }

    public void displayPersonaOptions() {
        foreach (GameObject obj in personaCards) {
            obj.SetActive(true);
        }
    }

    private void createScenarioCards() {
        ScenarioModel[] scenarios = game.getRepository().getScenarios();
        int count = 0;
        foreach (ScenarioModel scenario in scenarios) {
            if (count < MAX_NUMBER_OF_CARD_OPTION_SLOTS) {
                GameObject card = GameObject.Instantiate(scenarioCardPrefab, CardSpawnpoints[count++].transform);
                card.GetComponent<ScenarioOptionCard>().addInfoToCard(scenario);
                scenarioCards.Add(card);
            }
        }
    }

    private void createPersonaCards() {
        PersonaModel[] personas = game.getRepository().getPersonas();
        int count = 0;
        foreach (PersonaModel persona in personas) {
            if (count < MAX_NUMBER_OF_CARD_OPTION_SLOTS) {
                GameObject card = GameObject.Instantiate(personaCardPrefab, CardSpawnpoints[count++].transform);
                card.GetComponent<PersonaOptionCard>().addInfoToCard(persona);
                personaCards.Add(card);
            }
        }
    }

}