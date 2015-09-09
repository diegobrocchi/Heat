Imports System.ComponentModel.DataAnnotations

Public Enum ThermalUnitKindEnum
    <Display(name:="Gruppo termico singolo")> _
    SingleThermalUnit = 1

    <Display(name:="Tubo/nastro radiante")> _
    TubeOrRadiantStrip = 2

    <Display(name:="Gruppo termico modulare")> _
    ModularThermalUnit = 3

    <Display(name:="Generatore di aria calda")> _
        HotAirGenerator = 4

End Enum
