using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public enum IngredientType
{
    Base,
    Solute,
    Junk
}

public enum AlchemicalTraits
{
    Energize,
    Heal,
    Cure,
    Poison,
    Antidote,
}

public struct BunsenBurnerProcess
{
    public BunsenBurnerProcess(int minTemp, int maxTemp, IngredientScriptableObject result)
    {
        this.minTemp = minTemp;
        this.maxTemp = maxTemp;
        this.result = result;
    }

    public int minTemp;
    public int maxTemp;
    public IngredientScriptableObject result;
}

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Scriptable Object/New Ingredient", order = 2)]
public class IngredientScriptableObject : SerializedScriptableObject
{
    [BoxGroup("General Information")]
    [HorizontalGroup("General Information/Split", Width = 80)]
    [VerticalGroup("General Information/Split/Left")]
    [PreviewField(75, ObjectFieldAlignment.Center)]
    [HideLabel]
    public Image ingredientImage;
    [VerticalGroup("General Information/Split/Right")]
    public int ID;
    [VerticalGroup("General Information/Split/Right")]
    public string ingredientName;
    [VerticalGroup("General Information/Split/Right")]
    public int ingredientTier;
    [VerticalGroup("General Information/Split/Right")]
    public GameObject ingredientPrefab;
    [VerticalGroup("General Information/Split/Right")]
    public IngredientType ingredientType;

    [BoxGroup("Alchemical Properties")]
    public List<AlchemicalTraits> alchemicalTratis;

    [FoldoutGroup("Alchemical Properties/Processes")]
    public bool canMortarPestle;
    [HorizontalGroup("Alchemical Properties/Processes/MortarPestle")]
    [HideIf("@!canMortarPestle")]
    [PreviewField(Alignment = ObjectFieldAlignment.Center)]
    [HideLabel]
    public IngredientScriptableObject mortarPestleResult;
    [HorizontalGroup("Alchemical Properties/Processes/MortarPestle")]
    [HideIf("@!canMortarPestle")]
    [PreviewField(Alignment = ObjectFieldAlignment.Center)]
    [HideLabel]
    public IngredientScriptableObject mortarPestleResult2;

    [FoldoutGroup("Alchemical Properties/Processes")]
    public bool canJuicer;
    [HorizontalGroup("Alchemical Properties/Processes/Juicer")]
    [HideIf("@!canJuicer")]
    [PreviewField(Alignment = ObjectFieldAlignment.Center)]
    [HideLabel]
    public IngredientScriptableObject juicerResult;
    [HorizontalGroup("Alchemical Properties/Processes/Juicer")]
    [HideIf("@!canJuicer")]
    [PreviewField(Alignment = ObjectFieldAlignment.Center)]
    [HideLabel]
    public IngredientScriptableObject juicerResult2;

    [FoldoutGroup("Alchemical Properties/Processes")]
    public bool canChopping;
    [HorizontalGroup("Alchemical Properties/Processes/Chopping")]
    [HideIf("@!canChopping")]
    [PreviewField(Alignment = ObjectFieldAlignment.Center)]
    [HideLabel]
    public IngredientScriptableObject choppingResult;
    [HorizontalGroup("Alchemical Properties/Processes/Chopping")]
    [HideIf("@!canChopping")]
    [PreviewField(Alignment = ObjectFieldAlignment.Center)]
    [HideLabel]
    public IngredientScriptableObject choppingResult2;

    [FoldoutGroup("Alchemical Properties/Processes")]
    public bool canImbue;
    [FoldoutGroup("Alchemical Properties/Processes")]
    [HideIf("@!canImbue")]
    public List<IngredientScriptableObject> ImbueRecipe = new List<IngredientScriptableObject>();

    [FoldoutGroup("Alchemical Properties/Processes")]
    public bool canBunsenBurner;
    [FoldoutGroup("Alchemical Properties/Processes")]
    [HideIf("@!canBunsenBurner")]
    public List<BunsenBurnerProcess> bunsenProcesses = new List<BunsenBurnerProcess>();
}
