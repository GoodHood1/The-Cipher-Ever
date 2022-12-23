using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;
using Rnd = UnityEngine.Random;

public class Template : MonoBehaviour
{

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMBombModule module;

    static int ModuleIdCounter = 1;
    int ModuleId;
    private bool ModuleSolved;

    public KMSelectable[] keyboard;
    public TextMesh text;

    bool moduleSolved;
    bool moduleSelected;



    void Awake()
    {



    }

    void Start()
    {
        text.text = "";
        module.GetComponent<KMSelectable>().OnFocus += delegate { moduleSelected = true; };
        module.GetComponent<KMSelectable>().OnDefocus += delegate { moduleSelected = false; };
        ModuleId = ModuleIdCounter++;
        foreach (KMSelectable button in keyboard)
        {
            button.OnInteract += delegate () { keyboardPress(button); return false; };
        }
    }


    private int getPositionFromChar(char c)
    {
        return "QWERTYUIOPASDFGHJKLZXCVBNM".IndexOf(c);
    }


    void Update()
    {
        //CHANGE THIS TO IF MODULE SELECTED AFTER DONE
        if (!moduleSelected)
        {
            for (var ltr = 0; ltr < 26; ltr++)
            {
                if (Input.GetKeyDown(((char)('a' + ltr)).ToString())) {
                    
                    keyboard[getPositionFromChar((char) ('A' + ltr))].OnInteract();
                }
            }
        }
    }

    void keyboardPress(KMSelectable button)
    {
        
        if (text.text.Length < 6)
        {
            text.text += button.name.ToUpper();
        }
        
    }


#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use !{0} to do something.";
#pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string Command)
    {
        yield return null;
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        yield return null;
    }
}
