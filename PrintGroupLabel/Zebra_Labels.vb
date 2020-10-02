﻿Module Zebra_Labels
    Public Function KWH310_Pallet_Label(Box As String)
        Dim Content As String
        Content = "
^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^JUS^LRN^CI0^XZ
~DG000.GRF,07680,060,
,::::::::::::::::::::::::::gI07F0h060C0,gH01FFC0gY071C0,gH03FFE0gY03F80,gH07FHFh01F,gH07C1F80,gH0F80783FFE03F01E1DFHF9E7C00F80783C3C1E1E001E1E0F0H0F007807C00FFE1E03C7FFC3C,gH03003C3FFE07F81E3DFHF9FFE03FE0783C3C1E1E001E1E1F0H0F00781FF00FFE1E03C7FFC3C,gK03C3FFE0FFC1E7DFHF9FHF07FF0783C3C1E1E001E1E1F0H0F80F83FF80FFE0F0787FFC3C,gI01FFC3C1E1E1E1E700F01F0F0F8F8783C3C1E1E001E1E3F0H0F80F87C7C0E1E0F078783C3C,gI01FFC3C1E3C0E1E700F01F0F8F078783C3C1E1E001E1E3F0H0FC1F8783C0E1E0F078783C3C,gI01FFC3C1E3C0F1EE00F01E079E03C7FFC3FFE1E001E1E7F0H0FC1F8F01E0E1E078F0783C3C,gI01FFC3C1E3FHF1FE00F01E079E03C7FFC3FFE1FFE1E1EFF0H0HE3B8F01E0E1E078F0783C3FFC,gH03003C3C1E3FHF1FC00F01E079E03C7FFC3FFE1FHF1E1EEF0H0HE3B8F01E0E1E038E0783C3FFE,gH0F003C3C1E3FHF1FE00F01E079E03C783C3C1E1FHF9E1FEF0H0E7738F01E1E1E038E0783C3FHF,gH0F80783C1E3C001EF00F01E079E03C783C3C1E1E079E1FCF0H0E7738F01E1E1E03DE0783C3C0F,gH07E1F83C1E3C001E780F01F0F8F078783C3C1E1E079E1F8F0H0E7F38783C1C1E01DC0783C3C0F,gH07FHF03C1E1E0C1E780F01F8F0F8F8783C3C1E1E079E1F8F0H0E3E387C7C3C1E01DC0783C3C0F,gH03FFE1FC1E1FHF1E3C0F01FHF07FF0783C3C1E1FHF9E1F0F0H0E3E383FF8FIF80FC3F83C3FHF,gH01FFC1F81E0FFE1E3C0F01EFE03FE0783C3C1E1FHF1E1F0F0H0E1C381FF0FIF80F83F03C3FFE,gI07F01F01E03F81E3E0F01E7800F80783C3C1E1FFC1E1E0F0H0E1C3807C0FIF80F83E03C3FF8,hH01E0gV0E00380F,:hH01E0gV0E00381F,hH01E0gV0E0038FE,hH01E0hG0FC,hH01E0hG0F8,,::::::N07F,M01FFC0,M03FFE0,M07FHF0,M0FC1F0,M0F00F81F80F3E07FF007E03CF81E0F03F807FF0H0F00781FC1FHF83F01E7C0F078783C07E03C383F807FF0H0IF83FFE07F07FFE1FC0,L01F00603FC0FHF07FF80FF03FFC1E0F0FFE0FHFI0F00787FF1FHF87F81FFE0F0F8783C0FF83C78FFE0FHFI0IF83FFE1FFC7FFE7FF0,L01E0I07FE0FHF87FFC1FF83FFE1E0F0FHF1FHFI0F80F87FF9FHF8FFC1FHF0F0F8783C1FFC3CF8FHF1FHFI0IF83FFE1FFE7FFE7FF8,L01E0I0F0F0F878783C3C3C3E1E1E0F1E1F1E0F0H0F80F8F0F80F01E1E1F0F0F1F8783C3C3E3CE1E1F1E0F0H0F0783C1E3C3E03C0F0F8,L01E0H01E070F87C783C781C3E1F1E0F0C0F1E0F0H0FC1F860780F03C0E1F0F8F1F8783C3C183CE0C0F1E0F0H0F0783C1E181E03C06078,L01E0H01E078F03C783C781E3C0F1FHFH01F1E0F0H0FC1F800F80F03C0F1E078F3F87FFC78003DC001F1E0F0H0F0783C1E003E03C0H0F8,L01E0H01FHF8F03C7FF87FFE3C0F1FHF01FF1FHFI0HE3B80FF80F03FHF1E078F7F87FFC78003FC01FF1FHFI0F0783C1E03FE03C00FF8,L01E0061FHF8F03C7FF07FFE3C0F1FHF07EF0FHFI0HE3B83F780F03FHF1E078F7787FFC78003F807EF0FHFI0F0783C1E0FDE03C03F78,L01F00F9FHF8F03C7FFC7FFE3C0F1E0F0F0F03FF0H0E773878780F03FHF1E078FF78783C78003FC0F0F03FF0H0F0783C1E1E1E03C07878,M0F00F9E0H0F03C781E78003C0F1E0F1E0F07CF0H0E7738F0780F03C001E078FE78783C78003DE1E0F07CF0H0F0783C1E3C1E03C0F078,M0FC3F1E0H0F87C781E78003E1F1E0F1E0F078F0H0E7F38F0780F03C001F0F8FC78783C3C183CF1E0F078F0H0F0783C1E3C1E03C0F078,M07FHF0F060FC78781E3C183F1E1E0F1F1F0F0F0H0E3E38F8F80F01E0C1F8F0FC78783C3C3E3CF1F1F0F0F0H0F0783C1E3E3E03C0F8F8,M03FFE0FHF8FHF87FFE3FFE3FFE1E0F1FHF0F0F0H0E3E38FHF80F01FHF1FHF0F878783C1FFC3C79FHF0F0F0H0F079FC1E3FFE03C0FHF8,M01FFC07FF0F7F07FFC1FFC3DFC1E0F0FF71E0F0H0E1C387FB80F00FFE1EFE0F878783C0FF83C78FF71E0F0H0F079F81E1FEE03C07FB8,N07F001FC0F3C07FF807F03CF01E0F07C7BE0F0H0E1C383E3C0F003F81E780F078783C03F03C7C7C7BE0F0H0F079F01E0F8F03C03E3C,V0F0P03C0gR01E0,:::::,::::::gH079E1E01F0M0FC20U01E01F780F80F01FC003E0H0E007E003F800FC0F3C,gH079E1E03E0L01FCE0U01E03E780F80F07FF00FF801E01FF80FFE03FF0F3C,gH079E1E07C0L03FDE0U01E07C3C0F81E0FHF81FFC03E03FFC1FHF07FF8F3C,gH079E1E0F80L03C1E0U01E0F83C1FC1E1FHFC3FFC07E03FFE3FHF07FFCF3C,gH079E1E1F0M03C1E0U01E1F03C1DC1E3F07C3C3E1FE07C3E3E0F8F87CF3C,gH079E1E3E01EF0FE0FJFC1F0787F03C07801E3E03C1DC1E3C03E381E3FE0781E3C078F03CF3C,gH030C1E7C01FE3FF8FJFC1F079FFC3C07801E7C01E1DC1C7C01878003DE0781E3E0H0F03C618,gK01EF801FE3FFCFIFDC1F071FFE1E0F001EF801E3DE3C780H07BE039E0H01E3FC0I03C0,gK01FFC01F0787C3C1E1E3F8F3C3E1E0F001FFC01E38E3C780H07FF821E0H03C1FFC0H0780,gK01FFC01E0303C3C1E1E3F8F181E1E0F001FFC00E38E38780H07FFC01E0H07C0FHFI0F80,gK01FFE01E0H07C3C1E0E3B8E003E0F1E001FFE00E38E38780H07FFC01E0H0F803FF801F,gK01F9F01E007FC3C1E0F7BDE03FE0F1E001F9F00F38E78780H07C3E01E001F0H03F803E,gK01F0F01E01FBC3C1E0F7BDE0FDE071C001F0F00F7077878018781E01E003C0I07C078,gK01E0F81E03C3C3C1E077BDC1E1E071C001E0F807707707C03E781E01E007807803C0F0,gK01E0781E0783C3C1E0771DC3C1E07BC001E07807707703C03E781E01E00F007C03C1E0,gK01E07C1E0783C3C1E07F1FC3C1E03B8001E07C07707703F0FC3C3E01E01E003E07C3C0,gK01E03C1E07C7C3C1E03F1F83E3E03B8001E03C07E03F01FHFC3FFC01E03FFE3FHF87FFC0,gK01E01E1E07FFC3C1FC3E0F83FFE01F8001E01E03E03E00FHF81FFC01E03FFE1FHF87FFC0,gK01E01F1E03FDC3C0FC3E0F81FEE01F0H01E01F03E03E007FF00FF801E07FFE0FHF0FHFC0,gK01E00F1E01F1E3C07C3E0F80F8F01F0H01E00F03E03E001FC003E001E07FFE03FC0FHFC0,hR01E,:hR03E,hQ01FC,hQ01F8,hQ01F0,,::::::::~DG001.GRF,03840,060,
,:::::::::::::::::::::::::::::kH01C,L0F803E0iG018180gH01FFC,L0F803E0iG01C380gH07FF8,L0F803E0iH0HFgI01FHF0,L0F803E0iH07E0gH01E0,L0F803E0jM0380,:L0F803E00FC01F001F00FC03C7C0H01FFE78F80F80F8FIF0FIFH07E00FHF8007E00F81F0H07C1E01F803C7C001F8031F803E0F1F03E0F8,L0F803E03FF01F803F03FF03DFF0H01FFE7BFE0F80F8FIF0FIF01FF80FHFE01FF80F83F0H07C3E07FE03DFF007FE073FE03E1F1F07E0F8,L0F803E0FHFC1F803F07FF83FHF8001FFE7FHF0780F0FIF0FIF07FFE0FIF07FFE0F83F0H07C7E1FHF83FHF81FHF87FHF03E3F1F07E0F8,L0JFE0F87C1F803F0F87C3F8FC001F007F1F87C1F0F81F0F81F07C3E0F83F07C3E0F87F0H07C781F0F83F8FC1F0F87F0F83E3C1F0FE0F8,L0JFE1F03E1FC07F0F87C3F07C001F007E0F87C1F0F81F0F81F0F81F0F81F0F81F0F87F0H07CF03E07C3F07C3E07C7E07C3E781F0FE0F8,L0JFE1F03E1FC07F1F03C3E03E001F007C07C3C1E0F81F0F81F0F81F0F81F0F81F0F8FF0H07CF03E07C3E03E3E07C7E07C3E781F1FE0,L0JFE3E01F1FE0FF1F03E3E03E001F007C07C3E3E0F81F0F81F1F00F8F83E1F00F8F8FF0H07DE07C03E3E03E7C03E7C03E3EF01F1FE0,L0F803E3E01F1EE0EF1FHFE3E03E001F007C07C3E3E0F81F0F81F1F00F8FHFE1F00F8F9DF0H07FE07C03E3E03E7C03E7C03E3FF01F3BE0,L0F803E3E01F1EF1EF1FHFE3E03E001F007C07C1E3C0F81F0F81F1F00F8FHF81F00F8F9DF0H07FC07C03E3E03E7C03E7C03E3FE01F3BE0,L0F803E3E01F1E71CF1FHFE3E03E001F007C07C1E3C0F81F0F81F1F00F8FHFE1F00F8FB9F0H07FE07C03E3E03E7C03E7C03E3FF01F73E0,L0F803E3E01F1E7BCF1F0H03E03E001F007C07C0F7C0F81F0F81F1F00F8F81F1F00F8FB9F0H07DF07C03E3E03E7C03E7C03E3EF81F73E0,L0F803E3E01F1E7BCF1F0H03E03E001F007C07C0F780F81F0F81F1F00F8F80F9F00F8FF1F0H07CF87C03E3E03E7C03E7C03E3E7C1FE3E0,L0F803E1F03E1E3B8F1F0H03F03E001F007E07C0F780F81F0F81F0F81F0F80F8F81F0FF1F0H07CF83E07C3F03E3E07C3E07C3E7C1FE3E0,L0F803E1F03E1E3F8F0F8383F07C001F007E0F807780F81F0F81F0F81F0F80F8F81F0FE1F0H07C7C3E07C3F07C3E07C3E07C3E3E1FC3E0F8,L0F803E0F87C1E1F0F0FC7E3F8FC001F007F1F807F00F81F0F81F07C3E0F81F87C3E0FE1F0H07C7C1F0F83F8FC1F0F81F0F83E3E1FC3E0F8,L0F803E0FHFC1E1F0F07FFC3FHF8001F007FHFH07F00F81F0F81F07FFE0FIF07FFE0FC1F0H07C3E1FHF83FHF81FHF81FHF03E1F1F83E0F8,L0F803E03FF01E0E0F03FF83EFF0H01F007DFE003E00F81F0F81F01FF80FIF01FF80FC1F0H07C3E07FE03EFF007FE007FE03E1F1F83E0F8,L0F803E00FC01E0E0F00FE03E3C0H01F007C78003E00F81F0F81F007E00FHFC007E00F81F0H07C3F01F803E3C001F8001F803E1F9F03E0F8,gM03E0N07C0I03E0hH03E0,gM03E0N07C0I03C0hH03E0,gM03E0N07C0I07C0hH03E0,:gM03E0N07C0H07F80hH03E0,gM03E0N07C0H07F0hI03E0,gM03E0N07C0H07E0hI03E0,,:^XA
^MMT
^PW673
^LL0201
^LS0
^FT96,128^XG000.GRF,1,1^FS
^FT64,160^XG001.GRF,1,1^FS
^FT528,155^A0N,38,38^FH\^FD" & Box & "^FS
^PQ1,0,1,Y^XZ
^XA^ID000.GRF^FS^XZ
^XA^ID001.GRF^FS^XZ
"
        Return Content

    End Function

    Public Function KWH310_SN_Label(SN As String)
        Dim Content As String
        Content = "
        ^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,00^JMA^MD5^JUS^LRN^CI0^XZ
        ^XA
        ^MMT
        ^PW650
        ^LL0201
        ^LS0
        ^BY4,3,80^FT55,121^BCN,,Y,N
        ^FD>:" & SN & "^FS
        ^PQ1,0,1,Y^XZ
        "
        Return Content
    End Function



End Module
