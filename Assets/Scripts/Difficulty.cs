using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    [SerializeField] private ScenarioDatas _scenario;

    public void SetDifficultyLevel(int EnigmeNumber)
    {
        _scenario.MaxEnigmeNumber = EnigmeNumber;
        SceneManager.LoadScene(1);
    }



}
