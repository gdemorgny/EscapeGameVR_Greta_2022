using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionComponent : MonoBehaviour
{
    // Class qui permet de lancer automatiquement l'event et de finir une enigme.
    // Il suffit de le mettre dans le gameobject correspondant et de déclencher la fonction FinishingAction()
    public delegate void ActionController();
    public static event ActionController OnActionFinished;
    public static event ActionController OnActionCanceled;

    public void FinishingAction()
    {
        OnActionFinished?.Invoke();
    }
    public void CancelingAction()
    {
        OnActionCanceled?.Invoke();
    }
}
