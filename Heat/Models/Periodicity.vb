Imports System.ComponentModel.DataAnnotations

Public Enum Periodicity
    <Display(name:="Nessuna")> _
    None = 0
    <Display(name:="Giornaliera")> _
    Daily = 1
    <Display(name:="Settimanale")> _
    Weekly = 2
    <Display(name:="Mensile")> _
    Monthly = 3
    <Display(name:="Trimestrale")> _
    Quarterly = 4
    <Display(name:="Annuale")> _
    Yearly = 5
    <Display(name:="Biennale")> _
    Biennial = 6
    <Display(name:="Triennale")> _
    Three_year = 7
    <Display(name:="Quadriennale")> _
        Four_year = 8
    <Display(name:="Quinquennale")> _
    quinquennial = 9

End Enum
