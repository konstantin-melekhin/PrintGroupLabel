Module LabelContent
    Public LabelSNContent As String

    Public Function LabelSN(LabelDate As String, PrintTextSN As String, PrintCodeSN As String, Model As String, labelCount As Integer)
        '^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR10,10~SD15^JUS^LRN^CI0^XZ
        LabelSNContent = "
^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR10,10~MD5^JUS^LRN^CI0^XZ
^XA
^MMT
^PW650
^LL0201
^LS0
^FO96,128^GFA,02560,02560,00040,:Z64:
eJztkz2unTAQhX1F4dJlujdLyAYiO0tKeQsEXN2CkiW8nbwYUVBmC0YU73VxOYXlyTE/bwORkoYpGBkdPp0zY5S66qqr/rZa6aUKlm6eFIn/8p2S0qN4ZXUv8X6L2seiExnkGRoaggTohEk6vQgrS4Mwm2w877xfMkJHo8SiS0U3bjrwEmV96gZZQ3a0FtQkGbpq4znouJVDBwP9tGQiHRLpMTakPVqtrEW71zjioFQVzXNdM72ZkGmYkGjweuGsbDILw+DgOW080y/Q1drj2znQJ69GS2xmzwevX9+zy6aD8zU4GuAvWuVYr1HY9IF59yfTeybM6Rt4nra8RRfR2qjn5fQn0+83SoU3zOCV+bEVx/AH3ixHXiMPeSlzqg+eKrFbl9Ak6mnXgZerbJ01vqG+5M2q+GttA3/I+zx5uquSLTHBKzpVeHXRYX5suh/x4G261z4kN0ycqQOvzM+W+WXXqSOv6W7phQh8wWLTxpOE/RLm14pS5/y6iq0zmy5gyXi37/fnM7LL6uTBX7Sw14YGj7jzInivj3jHbVTxk1e2Gr52bLzx8If71ylr8gNxP8BL/+yvueqqq/5n/QGBgl71:2AB9
^FO64,128^GFA,00256,00256,00004,:Z64:
eJxjYKAEsP9gYOD/AMUPGBjkDzAw2ANxPYhuANJA/J+BgRGIGf4B6T8MDMxAzA6igVrZoVrlkbU3QLSDtNZDtf2nyJF4AQCESRoM:9F12
^FO0,128^GFA,00768,00768,00012,:Z64:
eJxjYBjZgP2AHOMBKNv+hz3zAyi7/g+C/eOPfTOM/aFE/iBM/Q8G+8cw8f8M9p/h7AcIdv0P+Y9w8//Z/YeJM/6xq4exGezs7KFsxgIbGXmoesYfCHGGvzV2/HDz/yDY9R/k2GHm6z+wg7t5FBAHAOLPMJc=:B706
^FO384,0^GFA,00768,00768,00012,:Z64:
eJztjjEKAjEQRSeskHKOMBeRzbVSLLiQwjJH8QoDW2zpFQJ7AC1j4zfZuGAjdmLhL8Ln8XkZon++HofXPn7ke6HBwly59F4CIuKdx8otZgikco6T5vKunIL6Hbf9yCmTq7ZB6KDerL8MHJAyo3E7qZc6pywxpOYxwHxU30vxd8Cl7B2e/Fb2Z175shTPqXI1up3cpS5t/R3/hTwAHyFPIw==:0A21
^BY5,3,81^FT41,137^BCN,,N,N
^FD>;" & PrintCodeSN & "^FS
^FT30,51^A0N,33,33^FH\^FD" & Model & "^FS
^FT395,169^A0N,33,33^FH\^FD" & PrintTextSN & "^FS
^FT471,51^A0N,33,33^FH\^FD" & LabelDate & "^FS
^PQ" & labelCount & ",0,1,Y^XZ"

        Return (LabelSNContent)
    End Function

    Public Function LabelSN4(LabelDate As String, PrintTextSN As String, PrintCodeSN As String, Model As String, labelCount As Integer)
        '^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR10,10~SD15^JUS^LRN^CI0^XZ
        LabelSNContent = "
^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,10^JMA^MD5^JUS^LRN^CI0^XZ
^XA
^MMT
^PW650
^LL0201
^LS0
^BY5,3,81^FT41,137^BCN,,N,N
^FD>;" & PrintTextSN & "^FS
^FT30,51^A0N,33,33^FH\^FD" & Model & "^FS
^FT471,51^A0N,33,33^FH\^FD" & LabelDate & "^FS
^FT163,169^A0N,33,33^FH\^FDSN:^FS
^FT215,169^A0N,33,33^FH\^FD" & PrintTextSN & "^FS
^PQ" & labelCount & ",0,1,Y^XZ"

        Return (LabelSNContent)
    End Function

    Public Function LabelSN3(LabelDate As String, PrintTextSN As String, PrintCodeSN As String, Model As String, labelCount As Integer)
        '^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR10,10~SD15^JUS^LRN^CI0^XZ
        LabelSNContent = "
^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,10^JMA^MD5^JUS^LRN^CI0^XZ
^XA
^MMT
^PW650
^LL0201
^LS0
^BY5,3,87^FT48,143^BCN,,N,N
^FD>;" & PrintTextSN & "^FS
^FT47,48^A0N,33,33^FH\^FD" & Model & "^FS
^FT459,48^A0N,33,33^FH\^FD" & LabelDate & "^FS
^FT163,177^A0N,37,36^FH\^FDSN:^FS
^FT215,177^A0N,37,36^FH\^FD" & PrintTextSN & "^FS
^PQ" & labelCount & ",0,1,Y^XZ"

        Return (LabelSNContent)
    End Function




    ' Описание операторов ZPL 
    '^XA - начало этикетки
    '^XZ - конец этикетки
    '^MMT - определяет как будут печататься этикетки, групоой или одиночке
    '^LS10 сдвиг влево всех элементов до начала отсчета
    '^FT40,293^A0N,108,108^FH\^FDID^FS где
    '^FT40,293 позиция FTx,y
    '^A0N - поворот (Т = Normal),108,108 - высота шрифта, ширина текста


    Public Function LabelSN2(LabelDate As String, PrintTextSN As String, Model As String, labelCount As Integer)
        '^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR10,10~SD15^JUS^LRN^CI0^XZ
        LabelSNContent = "
^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,20^JMA^MD5^JUS^LRN^CI0^XZ
^XA
^MMT
^PW650
^LL0201
^LS0
^BY5,3,96^FT48,143^BCN,,N,N
^FD>;" & PrintTextSN & "^FS
^FT51,43^A0N,37,36^FH\^FD" & Model & "^FS
^FT445,43^A0N,37,36^FH\^FD" & LabelDate & "^FS
^FT153,182^A0N,42,40^FH\^FDSN:^FS
^FT215,182^A0N,42,40^FH\^FD" & PrintTextSN & "^FS
^PQ" & labelCount & ",0,1,Y^XZ"
        Return (LabelSNContent)
    End Function


    Public Function LabelPallet(LabelDate As String, Liter As String, Pallet As String, Box As Integer)
        '^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR10,10~SD15^JUS^LRN^CI0^XZ
        LabelSNContent = "
^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,20^JMA^MD5^JUS^LRN^CI0^XZ
^XA
^MMT
^PW650
^LL0201
^LS0
^FO0,96^GFA,03840,03840,00040,:Z64:
eJztVDGO2zAQlEEcWOoJ+snxKXkKeVCh0k9IfhIFKVzeFwSkcEoWBkLfbTgZkhKNk4UkQIKk0boYyx6NZneWapq99tprr7322utflJ7eXlunwwbtAf7tD3DtFq/DWm/SssGzax6mzecC4+pGv8U7AG51Y6C/O+ZhTWusaGlxx7vzDNHBLHc/Eh8TqJev93rB0vRB+IHX3+ESAI0Z3+mgQ1cGidgG207NgagQ1BVjAvZhHHqa76aiBy2F19GnUGgqMNpPoJosehhC1JkXWkSVeTHRTZ94N73TVbSnPyMGIM8TyPP2RJ6p/nCc9UwwExRtEnRsvRmgEm/RO0tMetGOdsQQaZcgrdjnC79Xfx/Psx64Y7ZPY3J24EDMkdGj6r1HyHrIvIHxFJ5wqvqKJVIcyUtzQSTP9EFRzwwEpqReK49die2YByTpnYreadYDlqAxIOdb9GwfZn9J74PGa9XraTXz4Eofsz+mzpi/VX9P3MBYNtOUfhNkPa/wpeo9QR4uzTw/W+ZX2n5mzOc6P1daYh7TLQ8lBD4cn+v8nC083jgHm2JOV+ydS1L1mCvy/vku78sM3BeCqnqjFZt5nS+Ll4BdTWn/uJxVrwuF19JOWuSJkM4v91nHm97CY4c8GKqcD66Rox7bvvlr536VpIMW8nlrutjk81H1VrW8bPRl699bqa2X0k/0flVq6+X1J3p/m/eb/vb6j/UDsWP3lQ==:1CE3
^FO96,0^GFA,02688,02688,00028,:Z64:
eJztkkFOwzAQRe1m4aWP4BtwhV6BA3CXCPUAXClVF1lyBFxYdOuusNpRPvOdxiQSS0BCZBRlpLy8fNsTY9Zaa63vKA/In2fZTWyT9RZNc6lMnPjkz0AK6EIvptWWquejj0DcIobnQVkMsXohBXqtqi+w/MLc2yb1gByAR7Y4y2vV00uU7cnmHqXj4HLI2LHN8s5ITqw0mtzuH7iAT++I1OSGLG47fTR5ZO/0HPPI2ukwCjshqgcMyqJHnjFdXfVC12LhoeSNXoe36nF/ONHT15Xt4ZZez7yRHaSZvFDyevUauHvd30Hq/lC8J82zgxeei0z7s1yhh+O5jOfZs908ssFpnhnnsKtzKF4QeobzA+zMi+plr3mGc8dgca1eR1Y8/i8n1Y+TdzGcbcnbXEx4jebOym0Oy/ry4U+y9Lt5a631f+sD00RP8Q==:08B9
^FO96,64^GFA,01792,01792,00028,:Z64:
eJzt0jFuwyAUBmAQA1IXxo4+Qo/wepMeBZbOuRK5QY/gsSOjVT3x90eWbYiUTlWy+EWKEC+f//CwMWed9X8FoNxp2T96z3DLXWemYuL7vvFxLA2SFEcKVMdHcBlQZd5dgLKn7BUPnYBp3p2gbo5odPzl5hq6cdgcl6OTHDfH5eCWl4QEV52GJXIpuXPtG1ad+hITP7nLM2+rW+jAjdTNxeJwQJbczSVgz0PXW8+nsXexdzIfecwa8qI5HPf6vAXd+fI3XXe+eIWl83SSMZ6Pf+BCJ8xrox1dG7BVoWtXIreuro6XYIZ5TjUGpSu+3bsZ8sKPXJSuhPa+jHn+Sz6L1dfs+cqZI++sx9QvxfFAmw==:7B89
^FT323,176^A0N,50,50^FH\^FD" & Box & "^FS
^FT323,62^A0N,50,50^FH\^FD" & Liter & "^FS
^FT323,117^A0N,50,50^FH\^FD" & Pallet & "^FS
^FT470,44^A0N,33,33^FH\^FD" & LabelDate & "^FS
^PQ1,0,1,Y^XZ"

        Return (LabelSNContent)
    End Function

End Module
