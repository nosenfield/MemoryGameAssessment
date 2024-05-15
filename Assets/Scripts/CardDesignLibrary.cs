using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDesignLibrary", menuName = "ScriptableObjects/CardDesignLibrary", order = 1)]


/// <summary>
/// Card faces and backings have been implemented via a ScriptableObject to leverage the Editor's drag/drop and serialization functionality.
/// This allows new faces and backings to be added without adjusting the code.
/// Designers should be careful to not duplicate materials in these arrays, unless specifically intentional (to increase the likelihood of cards having a particular face)
/// </summary>
public class CardDesignLibrary : ScriptableObject
{
    [SerializeField] private Material[] faces;
    [SerializeField]
    public Material[] Faces
    {
        get
        {
            return (Material[])faces.Clone();
        }
    }
    [SerializeField] private Material[] backings;
    [SerializeField]
    public Material[] Backings
    {
        get
        {
            return (Material[])backings.Clone();
        }
    }

}