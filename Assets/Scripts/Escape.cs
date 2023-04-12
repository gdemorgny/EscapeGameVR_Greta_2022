using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    [SerializeField] private Transform _doorTransform;
    [SerializeField] private ScenarioDatas _scenarioData;
    private int _enigmeNumberFinished = 0;
    
    public delegate void enigmeResult(int number, bool unlock);

    public static event enigmeResult OnLampColorChange;

    private void OnEnable()
    {
        ActionComponent.OnActionFinished += EnigmeFinished;
        ActionComponent.OnActionCanceled += CanceledEnigme;
    }
    private void OnDisable()
    {
        ActionComponent.OnActionFinished -= EnigmeFinished;
        ActionComponent.OnActionCanceled -= CanceledEnigme;
    }

    void EnigmeFinished()
    {
        OnLampColorChange?.Invoke(_enigmeNumberFinished, true);
        _enigmeNumberFinished++;
        // TODO : vérifier si toutes les enigmes sont finies
        // pour vérifier je compare le nombre d'enigmes finies avec le nombre d'enigmes total pour la difficulté.
        if (_enigmeNumberFinished >= _scenarioData.MaxEnigmeNumber)
        {
            // SI elles sont toutes finies alors OpenDoor()
            OpenDoor();
        }
        // Sinon on allume une lampe pour dire qu'on a fini une enigme
        // Si on est motivé on peut rajouter un son
    }

    void CanceledEnigme()
    {
        if (_enigmeNumberFinished == _scenarioData.MaxEnigmeNumber)
        {
            CloseDoor();
        }

        _enigmeNumberFinished--;
        OnLampColorChange?.Invoke(_enigmeNumberFinished, false);

    }
    

    void OpenDoor()
    {
        _doorTransform.Rotate(0f,90f,0f,Space.Self);
    }
    void CloseDoor()
    {
        _doorTransform.Rotate(0f,-90f,0f,Space.Self);
    }
}
