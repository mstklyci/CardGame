using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurBelirleme : MonoBehaviour
{
    public static int Sira;
    public static bool KartAldi;
    public static bool KartVerildi;
    private void Start()
    {
        Sira = 1;
        KartAldi = false;
        KartVerildi = false;
    }

    private void Update()
    {
        SiraBelirleme();
    }
    void SiraBelirleme()
    {
        if (Sira == 1 || Sira == 5 || Sira == 9 || Sira == 13 || Sira == 17 || Sira == 21 || Sira == 25 || Sira == 29 || Sira == 34 || Sira == 38 ||
            Sira == 42|| Sira == 46 || Sira == 50 || Sira == 54 || Sira == 58 || Sira == 62 || Sira == 66 || Sira == 70 || Sira == 75 || Sira == 79||
            Sira == 83 || Sira == 87 || Sira == 91 || Sira == 95 || Sira == 99 || Sira == 103 || Sira == 107 || Sira == 111 || Sira == 116 || Sira == 120)           
        {
            KartSurukleme.currentPlayer = "1";
        }
        else if (Sira == 2 || Sira == 6 || Sira == 10 || Sira == 14 || Sira == 18 || Sira == 22 || Sira == 26 || Sira == 30 || Sira == 35 || Sira == 39||
                 Sira == 43|| Sira == 47 || Sira == 51 || Sira == 55 || Sira == 59 || Sira == 63 || Sira == 67 || Sira == 71 || Sira == 76 || Sira == 80||
                 Sira == 84 || Sira == 88 || Sira == 92 || Sira == 96 || Sira == 100 || Sira == 104 || Sira == 108 || Sira == 112 || Sira == 117 || Sira == 121)
        {
            KartSurukleme.currentPlayer = "2";
        }
        else if (Sira == 3 || Sira == 7 || Sira == 11 || Sira == 15 || Sira == 19 || Sira == 23 || Sira == 27 || Sira == 31|| Sira == 36 || Sira == 40||
                 Sira == 44|| Sira == 48 || Sira == 52 || Sira == 56 || Sira == 60 || Sira == 64 || Sira == 68 || Sira == 72 || Sira == 77 || Sira == 81||
                 Sira == 85 || Sira == 89 || Sira == 93 || Sira == 97 || Sira == 101 || Sira == 105 || Sira == 109 || Sira == 113 || Sira == 118 || Sira == 122)
        {
            KartSurukleme.currentPlayer = "3";
        }
        else if (Sira == 4 || Sira == 8 || Sira == 12 || Sira == 16 || Sira == 20 || Sira == 24 || Sira == 28 || Sira == 32 || Sira == 37 || Sira == 41||
                 Sira == 45|| Sira == 49 || Sira == 53 || Sira == 57 || Sira == 61 || Sira == 65 || Sira == 69 || Sira == 73 || Sira == 78 || Sira == 82||
                 Sira == 86 || Sira == 90 || Sira == 94 || Sira == 98 || Sira == 102 || Sira == 106 || Sira == 110 || Sira == 114 || Sira == 119 || Sira == 123)
        {
            KartSurukleme.currentPlayer = "4";
        }
    }

    public static bool KartVerdi
    {
        get
        {
            return KartVerildi;
        }
        set
        {
            if (value == true && KartVerildi != value)
            {
                Sira++;
                KartAldi = false;
            }
            KartVerildi = false;
        }
    }
}