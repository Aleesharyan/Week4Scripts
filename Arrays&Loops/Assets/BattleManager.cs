using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject fighterPrefab;
    public int teamSize = 3;
    public string[] fighterNames;
    public GameObject[] teamAFighters;
    public GameObject[] teamBFighters;

    // Start is called before the first frame update
    void Start()
    {
        //Create our teams and call our team generator function
        teamAFighters = CreateTeam(teamAFighters);
        teamBFighters = CreateTeam(teamBFighters);
        //Randomly assign two fighters to go head to head
        GameObject randomA = teamAFighters[Random.Range(0, teamSize)];
        GameObject randomB = teamBFighters[Random.Range(0, teamSize)];
        Battle(randomA, randomB);
    }

    public GameObject[] CreateTeam(GameObject[] incTeam)
    {
        //create our team of fighters
        //spawn each fighter, and add them to our team
        incTeam = new GameObject[teamSize]; //indexes = 0, 1 and 2
        for (int i = 0; i < teamSize; i++)
        {
            //spawn the fighter (go = game object)
            GameObject go = Instantiate(fighterPrefab);
            //assign to team
            incTeam[i] = go;
            //pick a random name from our array and give it top out fighters
            go.GetComponent<character>().UpdateName(fighterNames[Random.Range(0, fighterNames.Length)]);
        }
        //because the variable we pass through is only a copy we need to send this info back
        //from the temp variable incTeam to our actual team variable
        return incTeam;
    }

    public void Battle(GameObject fighterA, GameObject fighterB)
    {
        int coinFlip = Random.Range(0, 2);
        character FAStats = fighterA.GetComponent<character>();
        character FBStats = fighterB.GetComponent<character>();
        if (coinFlip == 0)
        {
            //fighterB.GetComponent<character>().health -= 
                //fighterA.GetComponent<character>().attack - fighterB.GetComponent<character>().defense;
            //above = bad, below = good
            FBStats.health -= FAStats.attack - FBStats.defense;
            Debug.Log("Fighter A attacks Fighter B");
            Debug.Log("Fighter B's health is now: " + FBStats.health);
        }
        else
        {
            FAStats.health -= FBStats.attack - FAStats.defense;
            Debug.Log("Fighter B attacks Fighter A");
            Debug.Log("Fighter A's health is now: " + FAStats.health);

        }
    }
}
