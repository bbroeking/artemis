using UnityEngine;
using System.Collections.Generic;

public static class MapPath
{
    // Map Path
    public const string BPath = "Map/B/";
    public const string BLPath = "Map/BL/";
    public const string BLRPath = "Map/BLR/";
    public const string BRPath = "Map/BR/";
    public const string LPath = "Map/L/";
    public const string LRPath = "Map/LR/";
    public const string RPath = "Map/R/";
    public const string TPath = "Map/T/";
    public const string TBPath = "Map/TB/";
    public const string TBLPath = "Map/TBL/";
    public const string TBLRPath = "Map/TBLR/";
    public const string TBRPath = "Map/TBR/";
    public const string TLPath = "Map/TL/";
    public const string TLRPath = "Map/TLR/";
    public const string TRPath = "Map/TR/";

    // B maps
    public const string baseB = BPath + "B Base";
    public const string baseB1E = BPath + "B Base +1";
    public const string baseB2E = BPath + "B Base +2";
    public const string pitB = BPath + "B Pit";
    public const string pitB1E = BPath + "B Pit +1";
    public const string pitB2E = BPath + "B Pit +2";

    // BL
    public const string baseBL = BLPath + "BL Base";
    public const string baseBL1E = BLPath + "BL Base +1";
    public const string baseBL2E = BLPath + "BL Base +2";
    public const string pitBL = BLPath + "BL Pit";
    public const string pitBL1E = BLPath + "BL Pit +1";
    public const string pitBL2E = BLPath + "BL Pit +2";

    // BLR
    public const string baseBLR = BLRPath + "BLR Base";
    public const string baseBLR1E = BLRPath + "BLR Base +1";
    public const string baseBLR2E = BLRPath + "BLR Base +2";
    public const string pitBLR = BLRPath + "BLR Pit";
    public const string pitBLR1E = BLRPath + "BLR Pit +1";
    public const string pitBLR2E = BLRPath + "BLR Pit +2";

    // BR
    public const string baseBR = BRPath + "BR Base";
    public const string baseBR1E = BRPath + "BR Base +1";
    public const string baseBR2E = BRPath + "BR Base +2";
    public const string pitBR = BRPath + "BR Pit";
    public const string pitBR1E = BRPath + "BR Pit +1";
    public const string pitBR2E = BRPath + "BR Pit +2";

    // L
    public const string baseL = LPath + "L Base";
    public const string baseL1E = LPath + "L Base +1";
    public const string baseL2E = LPath + "L Base +2";
    public const string pitL = LPath + "L Pit";
    public const string pitL1E = LPath + "L Pit +1";
    public const string pitL2E = LPath + "L Pit +2";

    // LR
    public const string baseLR = LRPath + "LR Base";
    public const string baseLR1E = LRPath + "LR Base +1";
    public const string baseLR2E = LRPath + "LR Base +2";
    public const string pitLR = LRPath + "LR Pit";
    public const string pitLR1E = LRPath + "LR Pit +1";
    public const string pitLR2E = LRPath + "LR Pit +2";
    
    // R
    public const string baseR = RPath + "R Base";
    public const string baseR1E = RPath + "R Base +1";
    public const string baseR2E = RPath + "R Base +2";
    public const string pitR = RPath + "R Pit";
    public const string pitR1E = RPath + "R Pit +1";
    public const string pitR2E = RPath + "R Pit +2";

    // T
    public const string baseT = TPath + "T Base";
    public const string baseT1E = TPath + "T Base +1";
    public const string baseT2E = TPath + "T Base +2";
    public const string pitT = TPath + "T Pit";
    public const string pitT1E = TPath + "T Pit +1";
    public const string pitT2E = TPath + "T Pit +2";

    // TB
    public const string baseTB = TBPath + "TB Base";
    public const string baseTB1E = TBPath + "TB Base +1";
    public const string baseTB2E = TBPath + "TB Base +2";
    public const string pitTB = TBPath + "TB Pit";
    public const string pitTB1E = TBPath + "TB Pit +1";
    public const string pitTB2E = TBPath + "TB Pit +2";

    // TBL
    public const string baseTBL = TBLPath + "TBL Base";
    public const string baseTBL1E = TBLPath + "TBL Base +1";
    public const string baseTBL2E = TBLPath + "TBL Base +2";
    public const string pitTBL = TBLPath + "TBL Pit";
    public const string pitTBL1E = TBLPath + "TBL Pit +1";
    public const string pitTBL2E = TBLPath + "TBL Pit +2";

    // TBLR
    public const string baseTBLR = TBLRPath + "TBLR Base";
    public const string baseTBLR1E = TBLRPath + "TBLR Base +1";
    public const string baseTBLR2E = TBLRPath + "TBLR Base +2";
    public const string pitTBLR = TBLRPath + "TBLR Pit";
    public const string pitTBLR1E = TBLRPath + "TBLR Pit +1";
    public const string pitTBLR2E = TBLRPath + "TBLR Pit +2";

    // TBR
    public const string baseTBR = TBRPath + "TBR Base";
    public const string baseTBR1E = TBRPath + "TBR Base +1";
    public const string baseTBR2E = TBRPath + "TBR Base +2";
    public const string pitTBR = TBRPath + "TBR Pit";
    public const string pitTBR1E = TBRPath + "TBR Pit +1";
    public const string pitTBR2E = TBRPath + "TBR Pit +2";

    // TL
    public const string baseTL = TLPath + "TL Base";
    public const string baseTL1E = TLPath + "TL Base +1";
    public const string baseTL2E = TLPath + "TL Base +2";
    public const string pitTL = TLPath + "TL Pit";
    public const string pitTL1E = TLPath + "TL Pit +1";
    public const string pitTL2E = TLPath + "TL Pit +2";

    // TLR
    public const string baseTLR = TLRPath + "TLR Base";
    public const string baseTLR1E = TLRPath + "TLR Base +1";
    public const string baseTLR2E = TLRPath + "TLR Base +2";
    public const string pitTLR = TLRPath + "TLR Pit";
    public const string pitTLR1E = TLRPath + "TLR Pit +1";
    public const string pitTLR2E = TLRPath + "TLR Pit +2";

    // TR
    public const string baseTR = TRPath + "TR Base";
    public const string baseTR1E = TRPath + "TR Base +1";
    public const string baseTR2E = TRPath + "TR Base +2";
    public const string pitTR = TRPath + "TR Pit";
    public const string pitTR1E = TRPath + "TR Pit +1";
    public const string pitTR2E = TRPath + "TR Pit +2";
}
