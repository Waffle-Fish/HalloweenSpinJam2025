using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomDeathMessageScript : MonoBehaviour
{
    TextMeshProUGUI tmp;
    float randNum;
    List<Tuple<float,String>> deathMessages = new()
    {
        new Tuple<float, string>(0.2f, "Skill Issue"),
        new Tuple<float, string>(0.2f, "Get Rekt Nerd"),
        new Tuple<float, string>(0.2f, "You suck Brandon - Colleen"),
        new Tuple<float, string>(0.2f, "F**king B*tch - Colleen"),
        new Tuple<float, string>(0.05f, "L + ratio + don’t care + didn’t ask + cry about it + who asked + stay mad + get real + bleed + mald seethe cope harder + dilate + incorrect + hoes mad + pound sand + basic skill issue + typo + ur dad left + you fell off + no u + the audacity + triggered + repelled + ur a minor + k. + any askers + get a life + ok and? + cringe + copium + go outside + touch grass + kick rocks + quote tweet + think again + not based + not funny didn’t laugh + social credits -999, 999, 999, 999 + get good + reported + ad hominem + ok boomer + small pp + ur allergic to sunlight + GG! + get rekt + trolled + your loss + muted + banned + kicked + permaban + useless + i slept with ur mom + yo momma + yo momma so fat + redpilled + no bitches allowed + i said it better + tiktok fan + get a life + unsubscribed + plundered + go tell reddit + donowalled + simp + get sticked bug LOL + talk nonsense + trump supporter + your’re a full time discord mod + you’re* + grammar issue + nerd + get clapped + kys"),
        new Tuple<float, string>(0.15f, "L + Ratio"),
    };

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        
    }

    private void Start() {
        tmp.text = GetRandMessage();
    }

    private string GetRandMessage()
    {
        randNum = UnityEngine.Random.Range(0f, 1f);
        float total = 0f;
        foreach (var pair in deathMessages)
        {
            total += pair.Item1;
            if (randNum <= total)
            {
                return pair.Item2;
            }
        }
        return deathMessages[0].Item2;
    }
}
