using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// The Card component represents a clickable card game object with two faces, a front and a back
/// </summary>
public class Card : MonoBehaviour, IPointerClickHandler
{
    public static Action<Card> CardClicked;

    private Material backMaterial;
    private Material faceMaterial;
    private int id;

    public int ID
    {
        get { return id; }
    }
    [SerializeField] private Image cardImage;


    public void InitializeCard(int _id, Material face, Material back)
    {
        id = _id;
        faceMaterial = face;
        backMaterial = back;
        cardImage.material = backMaterial;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CardClicked.Invoke(this);
    }

    public void ShowFace()
    {
        cardImage.material = faceMaterial;
    }

    public void ShowBack()
    {
        cardImage.material = backMaterial;
    }
}