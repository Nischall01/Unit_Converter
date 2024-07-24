Imports System.Data.SqlTypes

Public Class Form1
    Dim fromUnit As String
    Dim toUnit As String

    Private SameUnitSelected As Boolean = False
    Private PreviouslySelectedLeftUnit As Integer
    Private PreviouslySelectedRightUnit As Integer

    Dim InputValue As Double
    Dim OutputValue As Double

    Dim Quantities As String() = {"Length", "Mass", "Temperature", "Speed", "Area", "Volume", "Time"}
    Dim Quantity As String

    Dim Length_units As String() = {"Meter", "Centimeter", "Kilometer", "Millimeter", "Micrometer", "Nanometer", "Mile", "Yard", "Foot", "Inch", "Nautical Mile"}
    Dim Mass_units As String() = {"Kilogram", "Gram", "Milligram", "Pound", "Tonne", "Imperial Ton", "US Ton", "Stone", "Ounce"}
    Dim Temperature_units As String() = {"Celsius", "Fahrenheit", "Kelvin", "Rankine"}
    Dim Speed_units As String() = {"Kilometer Per Hour", "Mile Per Hour", "Meter Per Second", "Knot", "Foot Per Second", "Mach", "Kilometer Per Second", "Centimeter Per Second", "Inch Per Second"}
    Dim Area_units As String() = {"Square Meter", "Square Kilometer", "Square Centimeter", "Square Millimeter", "Square Micrometer", "Hectare", "Acre", "Square Mile", "Square Yard", "Square Foot", "Square Inch"}
    Dim Volume_units As String() = {"Cubic Meter", "Cubic Kilometer", "Cubic Centimeter", "Cubic Millimeter", "Liter", "Milliliter", "Gallon", "Quart", "Pint", "Cup", "Fluid Ounce", "Tablespoon", "Teaspoon", "Cubic Yard", "Cubic Foot", "Cubic Inch"}
    Dim Time_units As String() = {"Second", "Millisecond", "Microsecond", "Nanosecond", "Minute", "Hour", "Day", "Week", "Month", "Year"}

    ' Define the conversion factors for each unit with respect to a base unit (e.g., meters)
    Private ReadOnly LengthConversionFactors As New Dictionary(Of String, Dictionary(Of String, Double)) From {
    {"Meter", New Dictionary(Of String, Double) From {
        {"Centimeter", 100},
        {"Foot", 3.281},
        {"Inch", 39.3701},
        {"Kilometer", 0.001},
        {"Millimeter", 1000},
        {"Micrometer", 1000000.0},
        {"Nanometer", 1000000000.0},
        {"Mile", 0.000621371},
        {"Yard", 1.094},
        {"Nautical Mile", 0.000539957}
    }},
    {"Centimeter", New Dictionary(Of String, Double) From {
        {"Meter", 0.01},
        {"Foot", 0.03281},
        {"Inch", 0.393701},
        {"Kilometer", 0.00001},
        {"Millimeter", 10},
        {"Micrometer", 10000},
        {"Nanometer", 10000000},
        {"Mile", 0.00000621371},
        {"Yard", 0.01094},
        {"Nautical Mile", 0.00000539957}
    }},
    {"Foot", New Dictionary(Of String, Double) From {
        {"Meter", 0.3048},
        {"Centimeter", 30.48},
        {"Inch", 12},
        {"Kilometer", 0.0003048},
        {"Millimeter", 304.8},
        {"Micrometer", 304800},
        {"Nanometer", 304800000},
        {"Mile", 0.000189394},
        {"Yard", 0.333333},
        {"Nautical Mile", 0.000164579}
    }},
    {"Inch", New Dictionary(Of String, Double) From {
        {"Meter", 0.0254},
        {"Centimeter", 2.54},
        {"Foot", 0.0833333},
        {"Kilometer", 0.0000254},
        {"Millimeter", 25.4},
        {"Micrometer", 25400},
        {"Nanometer", 25400000},
        {"Mile", 0.0000157828},
        {"Yard", 0.0277778},
        {"Nautical Mile", 0.0000137149}
    }},
    {"Kilometer", New Dictionary(Of String, Double) From {
        {"Meter", 1000},
        {"Centimeter", 100000},
        {"Foot", 3280.84},
        {"Inch", 39370.1},
        {"Millimeter", 1000000},
        {"Micrometer", 1000000000},
        {"Nanometer", 1000000000000},
        {"Mile", 0.621371},
        {"Yard", 1094},
        {"Nautical Mile", 0.539957}
    }},
    {"Millimeter", New Dictionary(Of String, Double) From {
        {"Meter", 0.001},
        {"Centimeter", 0.1},
        {"Foot", 0.00328084},
        {"Inch", 0.0393701},
        {"Kilometer", 0.000001},
        {"Micrometer", 1000},
        {"Nanometer", 1000000},
        {"Mile", 0.00000062137},
        {"Yard", 0.001094},
        {"Nautical Mile", 0.00000053996}
    }},
    {"Micrometer", New Dictionary(Of String, Double) From {
        {"Meter", 0.000001},
        {"Centimeter", 0.0001},
        {"Foot", 0.00000328084},
        {"Inch", 0.0000393701},
        {"Kilometer", 0.000000001},
        {"Millimeter", 0.001},
        {"Nanometer", 1000},
        {"Mile", 0.00000000062137},
        {"Yard", 0.000001094},
        {"Nautical Mile", 0.00000000053996}
    }},
    {"Nanometer", New Dictionary(Of String, Double) From {
        {"Meter", 0.000000001},
        {"Centimeter", 0.0000001},
        {"Foot", 0.0000000032808},
        {"Inch", 0.00000003937},
        {"Kilometer", 0.000000000001},
        {"Millimeter", 0.000001},
        {"Micrometer", 0.001},
        {"Mile", 0.00000000000062137},
        {"Yard", 0.000000001094},
        {"Nautical Mile", 0.00000000000053996}
    }},
    {"Mile", New Dictionary(Of String, Double) From {
        {"Meter", 1609.34},
        {"Centimeter", 160934},
        {"Foot", 5280},
        {"Inch", 63360},
        {"Kilometer", 1.60934},
        {"Millimeter", 1609340},
        {"Micrometer", 1609340000.0},
        {"Nanometer", 1609340000000.0},
        {"Yard", 1760},
        {"Nautical Mile", 0.868976}
    }},
    {"Yard", New Dictionary(Of String, Double) From {
        {"Meter", 0.9144},
        {"Centimeter", 91.44},
        {"Foot", 3},
        {"Inch", 36},
        {"Kilometer", 0.0009144},
        {"Millimeter", 914.4},
        {"Micrometer", 914400},
        {"Nanometer", 914400000},
        {"Mile", 0.000568182},
        {"Nautical Mile", 0.000493736}
    }},
    {"Nautical Mile", New Dictionary(Of String, Double) From {
        {"Meter", 1852},
        {"Centimeter", 185200},
        {"Foot", 6076.12},
        {"Inch", 72913.4},
        {"Kilometer", 1.852},
        {"Millimeter", 1852000},
        {"Micrometer", 1852000000.0},
        {"Nanometer", 1852000000000.0},
        {"Mile", 1.15078},
        {"Yard", 2046.6}
    }}
}

    Private ReadOnly MassConversionFactors As New Dictionary(Of String, Dictionary(Of String, Double)) From {
    {"Kilogram", New Dictionary(Of String, Double) From {
        {"Gram", 1000},
        {"Milligram", 1000000.0},
        {"Pound", 2.20462},
        {"Tonne", 0.001},
        {"Imperial Ton", 0.000984207},
        {"US Ton", 0.00110231},
        {"Stone", 0.157473},
        {"Ounce", 35.274}
    }},
    {"Gram", New Dictionary(Of String, Double) From {
        {"Kilogram", 0.001},
        {"Milligram", 1000},
        {"Pound", 0.00220462},
        {"Tonne", 0.000001},
        {"Imperial Ton", 0.00000098421},
        {"US Ton", 0.00000110231},
        {"Stone", 0.000157473},
        {"Ounce", 0.035274}
    }},
    {"Milligram", New Dictionary(Of String, Double) From {
        {"Kilogram", 0.000001},
        {"Gram", 0.001},
        {"Pound", 0.00000220462},
        {"Tonne", 0.000000001},
        {"Imperial Ton", 0.00000000098421},
        {"US Ton", 0.00000000110231},
        {"Stone", 0.000000157473},
        {"Ounce", 0.000035274}
    }},
    {"Pound", New Dictionary(Of String, Double) From {
        {"Kilogram", 0.453592},
        {"Gram", 453.592},
        {"Milligram", 453592},
        {"Tonne", 0.000453592},
        {"Imperial Ton", 0.000446429},
        {"US Ton", 0.0005},
        {"Stone", 0.0714286},
        {"Ounce", 16}
    }},
    {"Tonne", New Dictionary(Of String, Double) From {
        {"Kilogram", 1000},
        {"Gram", 1000000.0},
        {"Milligram", 1000000000.0},
        {"Pound", 2204.62},
        {"Imperial Ton", 0.984207},
        {"US Ton", 1.10231},
        {"Stone", 157.473},
        {"Ounce", 35274}
    }},
    {"Imperial Ton", New Dictionary(Of String, Double) From {
        {"Kilogram", 1016.05},
        {"Gram", 1016050},
        {"Milligram", 1016050000.0},
        {"Pound", 2240},
        {"Tonne", 1.01605},
        {"US Ton", 1.12},
        {"Stone", 160},
        {"Ounce", 35840}
    }},
    {"US Ton", New Dictionary(Of String, Double) From {
        {"Kilogram", 907.185},
        {"Gram", 907185},
        {"Milligram", 907185000.0},
        {"Pound", 2000},
        {"Tonne", 0.907185},
        {"Imperial Ton", 0.892857},
        {"Stone", 143.0},
        {"Ounce", 32000}
    }},
    {"Stone", New Dictionary(Of String, Double) From {
        {"Kilogram", 6.35029},
        {"Gram", 6350.29},
        {"Milligram", 6350290.0},
        {"Pound", 14},
        {"Tonne", 0.00635029},
        {"Imperial Ton", 0.00625},
        {"US Ton", 0.0067},
        {"Ounce", 224}
    }},
    {"Ounce", New Dictionary(Of String, Double) From {
        {"Kilogram", 0.0283495},
        {"Gram", 28.3495},
        {"Milligram", 28349.5},
        {"Pound", 0.0625},
        {"Tonne", 0.0000283495},
        {"Imperial Ton", 0.000028213},
        {"US Ton", 0.00002835},
        {"Stone", 0.00446429}
    }}
}

    Private ReadOnly SpeedConversionFactors As New Dictionary(Of String, Dictionary(Of String, Double)) From {
    {"Meter Per Second", New Dictionary(Of String, Double) From {
        {"Kilometer Per Hour", 3.6},
        {"Mile Per Hour", 2.23694},
        {"Knot", 1.94384},
        {"Foot Per Second", 3.28084},
        {"Mach", 0.00293663},  ' Mach at sea level and 20°C (~1225.08 km/h or ~761.21 mph)
        {"Kilometer Per Second", 0.001},
        {"Centimeter Per Second", 100},
        {"Inch Per Second", 39.3701}
    }},
    {"Kilometer Per Hour", New Dictionary(Of String, Double) From {
        {"Meter Per Second", 0.277778},
        {"Mile Per Hour", 0.621371},
        {"Knot", 0.539957},
        {"Foot Per Second", 0.911344},
        {"Mach", 0.000815347},
        {"Kilometer Per Second", 0.000277778},
        {"Centimeter Per Second", 27.7778},
        {"Inch Per Second", 109.361}
    }},
    {"Mile Per Hour", New Dictionary(Of String, Double) From {
        {"Meter Per Second", 0.44704},
        {"Kilometer Per Hour", 1.60934},
        {"Knot", 0.868976},
        {"Foot Per Second", 1.46667},
        {"Mach", 0.000823688},
        {"Kilometer Per Second", 0.00044704},
        {"Centimeter Per Second", 44.704},
        {"Inch Per Second", 1760}
    }},
    {"Knot", New Dictionary(Of String, Double) From {
        {"Meter Per Second", 0.514444},
        {"Kilometer Per Hour", 1.852},
        {"Mile Per Hour", 1.15078},
        {"Foot Per Second", 1.68781},
        {"Mach", 0.000964555},
        {"Kilometer Per Second", 0.000514444},
        {"Centimeter Per Second", 51.4444},
        {"Inch Per Second", 2057.48}
    }},
    {"Foot Per Second", New Dictionary(Of String, Double) From {
        {"Meter Per Second", 0.3048},
        {"Kilometer Per Hour", 1.09728},
        {"Mile Per Hour", 0.681818},
        {"Knot", 0.592484},
        {"Mach", 0.000291667},
        {"Kilometer Per Second", 0.0003048},
        {"Centimeter Per Second", 30.48},
        {"Inch Per Second", 12}
    }},
    {"Mach", New Dictionary(Of String, Double) From {
        {"Meter Per Second", 340.29}, ' Speed of sound in air at sea level and 20°C
        {"Kilometer Per Hour", 1225.08},
        {"Mile Per Hour", 761.21},
        {"Knot", 661.44},
        {"Foot Per Second", 1126.54},
        {"Kilometer Per Second", 0.34029},
        {"Centimeter Per Second", 34029},
        {"Inch Per Second", 136000}
    }},
    {"Kilometer Per Second", New Dictionary(Of String, Double) From {
        {"Meter Per Second", 1000},
        {"Kilometer Per Hour", 3600},
        {"Mile Per Hour", 2236.94},
        {"Knot", 1943.84},
        {"Foot Per Second", 3280.84},
        {"Mach", 2.93663},
        {"Centimeter Per Second", 100000},
        {"Inch Per Second", 393701}
    }},
    {"Centimeter Per Second", New Dictionary(Of String, Double) From {
        {"Meter Per Second", 0.01},
        {"Kilometer Per Hour", 36},
        {"Mile Per Hour", 22.3694},
        {"Knot", 19.4384},
        {"Foot Per Second", 0.0328084},
        {"Mach", 0.0000293663},
        {"Kilometer Per Second", 0.00001},
        {"Inch Per Second", 39.3701}
    }},
    {"Inch Per Second", New Dictionary(Of String, Double) From {
        {"Meter Per Second", 0.0254},
        {"Kilometer Per Hour", 0.09144},
        {"Mile Per Hour", 0.0568182},
        {"Knot", 0.049244},
        {"Foot Per Second", 0.0833333},
        {"Mach", 0.000025144},
        {"Kilometer Per Second", 0.0000254},
        {"Centimeter Per Second", 2.54}
    }}
}

    Private ReadOnly TemperatureConversionFactors As New Dictionary(Of String, Dictionary(Of String, Double)) From {
    {"Celsius", New Dictionary(Of String, Double) From {
        {"Fahrenheit", 1.8}, ' Conversion factor to Fahrenheit
        {"Kelvin", 1}, ' Conversion factor to Kelvin
        {"Rankine", 1.8} ' Conversion factor to Rankine
    }},
    {"Fahrenheit", New Dictionary(Of String, Double) From {
        {"Celsius", 5.0 / 9.0}, ' Conversion factor to Celsius
        {"Kelvin", 5.0 / 9.0}, ' Conversion factor to Kelvin
        {"Rankine", 1} ' Conversion factor to Rankine
    }},
    {"Kelvin", New Dictionary(Of String, Double) From {
        {"Celsius", 1}, ' Conversion factor to Celsius
        {"Fahrenheit", 9.0 / 5.0}, ' Conversion factor to Fahrenheit
        {"Rankine", 9.0 / 5.0} ' Conversion factor to Rankine
    }},
    {"Rankine", New Dictionary(Of String, Double) From {
        {"Celsius", 5.0 / 9.0}, ' Conversion factor to Celsius
        {"Fahrenheit", 1}, ' Conversion factor to Fahrenheit
        {"Kelvin", 5.0 / 9.0} ' Conversion factor to Kelvin
    }}
}

    Private ReadOnly AreaConversionFactors As New Dictionary(Of String, Dictionary(Of String, Double)) From {
    {"Square Meter", New Dictionary(Of String, Double) From {
        {"Square Kilometer", 0.000001},
        {"Square Centimeter", 10000.0},
        {"Square Millimeter", 1000000.0},
        {"Square Micrometer", 1000000000000.0},
        {"Hectare", 0.0001},
        {"Acre", 0.000247105},
        {"Square Mile", 0.0000003861},
        {"Square Yard", 1.19599},
        {"Square Foot", 10.7639},
        {"Square Inch", 1550}
    }},
    {"Square Kilometer", New Dictionary(Of String, Double) From {
        {"Square Meter", 1000000.0},
        {"Square Centimeter", 10000000000.0},
        {"Square Millimeter", 1000000000000.0},
        {"Square Micrometer", 1.0E+18},
        {"Hectare", 100},
        {"Acre", 247.105},
        {"Square Mile", 0.386102},
        {"Square Yard", 1195990.0},
        {"Square Foot", 10763900.0},
        {"Square Inch", 1550003000.0}
    }},
    {"Square Centimeter", New Dictionary(Of String, Double) From {
        {"Square Meter", 0.0001},
        {"Square Kilometer", 0.0000000001},
        {"Square Millimeter", 100},
        {"Square Micrometer", 100000000.0},
        {"Hectare", 0.00000001},
        {"Acre", 0.0000000247105},
        {"Square Mile", 0.00000000003861},
        {"Square Yard", 0.0119599},
        {"Square Foot", 0.107639},
        {"Square Inch", 0.1550003}
    }},
    {"Square Millimeter", New Dictionary(Of String, Double) From {
        {"Square Meter", 0.000001},
        {"Square Kilometer", 0.000000000001},
        {"Square Centimeter", 0.01},
        {"Square Micrometer", 1000000.0},
        {"Hectare", 0.0000000001},
        {"Acre", 0.000000000247105},
        {"Square Mile", 0.0000000000003861},
        {"Square Yard", 0.00000119599},
        {"Square Foot", 0.0000107639},
        {"Square Inch", 0.0001550003}
    }},
    {"Square Micrometer", New Dictionary(Of String, Double) From {
        {"Square Meter", 0.000000000001},
        {"Square Kilometer", 1.0E-18},
        {"Square Centimeter", 0.00000001},
        {"Square Millimeter", 0.000001},
        {"Hectare", 0.0000000000000001},
        {"Acre", 0.000000000000000247105},
        {"Square Mile", 3.861E-19},
        {"Square Yard", 0.00000000000119599},
        {"Square Foot", 0.0000000000107639},
        {"Square Inch", 0.000000001550003}
    }},
    {"Hectare", New Dictionary(Of String, Double) From {
        {"Square Meter", 10000.0},
        {"Square Kilometer", 0.01},
        {"Square Centimeter", 100000000.0},
        {"Square Millimeter", 10000000000.0},
        {"Square Micrometer", 1.0E+16},
        {"Acre", 2.47105},
        {"Square Mile", 0.0003861},
        {"Square Yard", 11959.9},
        {"Square Foot", 107639.0},
        {"Square Inch", 15500030.0}
    }},
    {"Acre", New Dictionary(Of String, Double) From {
        {"Square Meter", 4046.86},
        {"Square Kilometer", 0.00404686},
        {"Square Centimeter", 404686000.0},
        {"Square Millimeter", 4046860000.0},
        {"Square Micrometer", 4.04686E+15},
        {"Hectare", 0.404686},
        {"Square Mile", 0.00015625},
        {"Square Yard", 4840},
        {"Square Foot", 43560},
        {"Square Inch", 6272640}
    }},
    {"Square Mile", New Dictionary(Of String, Double) From {
        {"Square Meter", 2589990.0},
        {"Square Kilometer", 2.58999},
        {"Square Centimeter", 25899900000.0},
        {"Square Millimeter", 2589990000000.0},
        {"Square Micrometer", 2.58999E+18},
        {"Hectare", 258.999},
        {"Acre", 640},
        {"Square Yard", 2295680.0},
        {"Square Foot", 27880000.0},
        {"Square Inch", 3687000000.0}
    }},
    {"Square Yard", New Dictionary(Of String, Double) From {
        {"Square Meter", 0.836127},
        {"Square Kilometer", 0.000000836127},
        {"Square Centimeter", 83612.7},
        {"Square Millimeter", 8361270.0},
        {"Square Micrometer", 8361270000000.0},
        {"Hectare", 0.0000836127},
        {"Acre", 0.000229568},
        {"Square Mile", 0.000000444089},
        {"Square Foot", 9},
        {"Square Inch", 1296}
    }},
    {"Square Foot", New Dictionary(Of String, Double) From {
        {"Square Meter", 0.092903},
        {"Square Kilometer", 0.000000092903},
        {"Square Centimeter", 929.03},
        {"Square Millimeter", 92903.0},
        {"Square Micrometer", 92903000000.0},
        {"Hectare", 0.000000092903},
        {"Acre", 0.00000022957},
        {"Square Mile", 0.00000003587},
        {"Square Yard", 0.111111},
        {"Square Inch", 144}
    }},
    {"Square Inch", New Dictionary(Of String, Double) From {
        {"Square Meter", 0.00064516},
        {"Square Kilometer", 0.00000000064516},
        {"Square Centimeter", 6.4516},
        {"Square Millimeter", 645.16},
        {"Square Micrometer", 645160000.0},
        {"Hectare", 0.00000000064516},
        {"Acre", 0.000000001588},
        {"Square Mile", 0.000000000002491},
        {"Square Yard", 0.000771605},
        {"Square Foot", 0.00694444}
    }}
}

    Private ReadOnly VolumeConversionFactors As New Dictionary(Of String, Dictionary(Of String, Double)) From {
    {"Cubic Meter", New Dictionary(Of String, Double) From {
        {"Cubic Kilometer", 0.000000001},
        {"Cubic Centimeter", 1000000.0},
        {"Cubic Millimeter", 1000000000.0},
        {"Liter", 1000.0},
        {"Milliliter", 1000000.0},
        {"Gallon", 264.172},
        {"Quart", 1056.688},
        {"Pint", 2113.38},
        {"Cup", 4226.75},
        {"Fluid Ounce", 33814.0226},
        {"Tablespoon", 67.628},
        {"Teaspoon", 202.884},
        {"Cubic Yard", 1.30795},
        {"Cubic Foot", 35.3147},
        {"Cubic Inch", 61023.7}
    }},
    {"Cubic Kilometer", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 1000000000.0},
        {"Cubic Centimeter", 1.0E+15},
        {"Cubic Millimeter", 1.0E+18},
        {"Liter", 1000000000000.0},
        {"Milliliter", 1.0E+15},
        {"Gallon", 2641720.0},
        {"Quart", 10566900.0},
        {"Pint", 21133800.0},
        {"Cup", 42267500.0},
        {"Fluid Ounce", 3381400000.0},
        {"Tablespoon", 6762800.0},
        {"Teaspoon", 20288400.0},
        {"Cubic Yard", 1307950.0},
        {"Cubic Foot", 35314700.0},
        {"Cubic Inch", 61023700000.0}
    }},
    {"Cubic Centimeter", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.000001},
        {"Cubic Kilometer", 0.000000000000001},
        {"Cubic Millimeter", 1000.0},
        {"Liter", 0.001},
        {"Milliliter", 1},
        {"Gallon", 0.000264172},
        {"Quart", 0.00105669},
        {"Pint", 0.00211338},
        {"Cup", 0.00422675},
        {"Fluid Ounce", 0.033814},
        {"Tablespoon", 0.000067628},
        {"Teaspoon", 0.000202884},
        {"Cubic Yard", 0.0000000495113},
        {"Cubic Foot", 0.0000353147},
        {"Cubic Inch", 1.63871}
    }},
    {"Cubic Millimeter", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.000000001},
        {"Cubic Kilometer", 1.0E-18},
        {"Cubic Centimeter", 0.001},
        {"Liter", 0.000001},
        {"Milliliter", 0.001},
        {"Gallon", 0.000000264172},
        {"Quart", 0.00000105669},
        {"Pint", 0.00000211338},
        {"Cup", 0.00000422675},
        {"Fluid Ounce", 0.000033814},
        {"Tablespoon", 0.000000067628},
        {"Teaspoon", 0.000000202884},
        {"Cubic Yard", 0.000000000495113},
        {"Cubic Foot", 0.000000353147},
        {"Cubic Inch", 0.000163871}
    }},
    {"Liter", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.001},
        {"Cubic Kilometer", 0.000000000001},
        {"Cubic Centimeter", 1000.0},
        {"Cubic Millimeter", 1000000.0},
        {"Milliliter", 1000.0},
        {"Gallon", 0.264172},
        {"Quart", 1.05669},
        {"Pint", 2.11338},
        {"Cup", 4.22675},
        {"Fluid Ounce", 33.8140226},
        {"Tablespoon", 0.67628},
        {"Teaspoon", 2.02884},
        {"Cubic Yard", 0.00130795},
        {"Cubic Foot", 0.0353147},
        {"Cubic Inch", 61.0237}
    }},
    {"Milliliter", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.000001},
        {"Cubic Kilometer", 0.000000000000001},
        {"Cubic Centimeter", 1},
        {"Cubic Millimeter", 1000},
        {"Liter", 0.001},
        {"Gallon", 0.000000264172},
        {"Quart", 0.00000105669},
        {"Pint", 0.00000211338},
        {"Cup", 0.00000422675},
        {"Fluid Ounce", 0.000033814},
        {"Tablespoon", 0.000000067628},
        {"Teaspoon", 0.000000202884},
        {"Cubic Yard", 0.000000000495113},
        {"Cubic Foot", 0.000000353147},
        {"Cubic Inch", 0.000163871}
    }},
    {"Gallon", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 3.78541},
        {"Cubic Kilometer", 0.00000000000378541},
        {"Cubic Centimeter", 378541.0},
        {"Cubic Millimeter", 378541000.0},
        {"Liter", 3.78541},
        {"Milliliter", 3785.41},
        {"Quart", 4},
        {"Pint", 8},
        {"Cup", 16},
        {"Fluid Ounce", 128},
        {"Tablespoon", 256},
        {"Teaspoon", 768},
        {"Cubic Yard", 0.00209},
        {"Cubic Foot", 0.134},
        {"Cubic Inch", 231}
    }},
    {"Quart", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.000946353},
        {"Cubic Kilometer", 0.000000000000946353},
        {"Cubic Centimeter", 946.353},
        {"Cubic Millimeter", 946353.0},
        {"Liter", 0.946353},
        {"Milliliter", 946.353},
        {"Gallon", 0.25},
        {"Pint", 2},
        {"Cup", 4},
        {"Fluid Ounce", 32},
        {"Tablespoon", 64},
        {"Teaspoon", 192},
        {"Cubic Yard", 0.000522},
        {"Cubic Foot", 0.0338},
        {"Cubic Inch", 57.75}
    }},
    {"Pint", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.000473176},
        {"Cubic Kilometer", 0.000000000000473176},
        {"Cubic Centimeter", 473.176},
        {"Cubic Millimeter", 473176.0},
        {"Liter", 0.473176},
        {"Milliliter", 473.176},
        {"Gallon", 0.125},
        {"Quart", 0.5},
        {"Cup", 2},
        {"Fluid Ounce", 16},
        {"Tablespoon", 32},
        {"Teaspoon", 96},
        {"Cubic Yard", 0.000261},
        {"Cubic Foot", 0.0169},
        {"Cubic Inch", 28.875}
    }},
    {"Cup", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.000236588},
        {"Cubic Kilometer", 0.000000000000236588},
        {"Cubic Centimeter", 236.588},
        {"Cubic Millimeter", 236588.0},
        {"Liter", 0.236588},
        {"Milliliter", 236.588},
        {"Gallon", 0.0625},
        {"Quart", 0.25},
        {"Pint", 0.5},
        {"Fluid Ounce", 8},
        {"Tablespoon", 16},
        {"Teaspoon", 48},
        {"Cubic Yard", 0.00013},
        {"Cubic Foot", 0.00833},
        {"Cubic Inch", 14.4375}
    }},
    {"Fluid Ounce", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.0000295735},
        {"Cubic Kilometer", 0.0000000000000295735},
        {"Cubic Centimeter", 29.5735},
        {"Cubic Millimeter", 29573.5},
        {"Liter", 0.0295735},
        {"Milliliter", 29.5735},
        {"Gallon", 0.0078125},
        {"Quart", 0.03125},
        {"Pint", 0.0625},
        {"Cup", 0.125},
        {"Tablespoon", 2},
        {"Teaspoon", 6},
        {"Cubic Yard", 0.0000165371},
        {"Cubic Foot", 0.000208},
        {"Cubic Inch", 1.80469}
    }},
    {"Tablespoon", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.0000147884},
        {"Cubic Kilometer", 0.0000000000000147884},
        {"Cubic Centimeter", 14.7884},
        {"Cubic Millimeter", 14788.4},
        {"Liter", 0.0147884},
        {"Milliliter", 14.7884},
        {"Gallon", 0.00390625},
        {"Quart", 0.015625},
        {"Pint", 0.03125},
        {"Cup", 0.0625},
        {"Fluid Ounce", 0.5},
        {"Teaspoon", 3},
        {"Cubic Yard", 0.00000826871},
        {"Cubic Foot", 0.000104},
        {"Cubic Inch", 0.87906}
    }},
    {"Teaspoon", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.00000492892},
        {"Cubic Kilometer", 0.00000000000000492892},
        {"Cubic Centimeter", 4.92892},
        {"Cubic Millimeter", 4928.92},
        {"Liter", 0.00492892},
        {"Milliliter", 4.92892},
        {"Gallon", 0.00130208},
        {"Quart", 0.00520833},
        {"Pint", 0.0104167},
        {"Cup", 0.0208333},
        {"Fluid Ounce", 0.166667},
        {"Tablespoon", 0.333333},
        {"Cubic Yard", 0.00000275623},
        {"Cubic Foot", 0.000031},
        {"Cubic Inch", 0.293254}
    }},
    {"Cubic Yard", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.764555},
        {"Cubic Kilometer", 0.000000000764555},
        {"Cubic Centimeter", 764555},
        {"Cubic Millimeter", 764555000.0},
        {"Liter", 764.555},
        {"Milliliter", 764555.0},
        {"Gallon", 201.974},
        {"Quart", 807.897},
        {"Pint", 1615.79},
        {"Cup", 3231.58},
        {"Fluid Ounce", 25853.85},
        {"Tablespoon", 50907.7},
        {"Teaspoon", 152723.2},
        {"Cubic Foot", 27},
        {"Cubic Inch", 46656}
    }},
    {"Cubic Foot", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.0283168},
        {"Cubic Kilometer", 0.0000000000283168},
        {"Cubic Centimeter", 28316.8},
        {"Cubic Millimeter", 28316800.0},
        {"Liter", 28.3168},
        {"Milliliter", 28316.8},
        {"Gallon", 7.48052},
        {"Quart", 29.9221},
        {"Pint", 59.8442},
        {"Cup", 119.688},
        {"Fluid Ounce", 957.506},
        {"Tablespoon", 1915.01},
        {"Teaspoon", 5745.04},
        {"Cubic Yard", 0.037037},
        {"Cubic Inch", 1728}
    }},
    {"Cubic Inch", New Dictionary(Of String, Double) From {
        {"Cubic Meter", 0.0000163871},
        {"Cubic Kilometer", 0.0000000000000163871},
        {"Cubic Centimeter", 16.3871},
        {"Cubic Millimeter", 16387.1},
        {"Liter", 0.0163871},
        {"Milliliter", 16.3871},
        {"Gallon", 0.004329},
        {"Quart", 0.017316},
        {"Pint", 0.034632},
        {"Cup", 0.069264},
        {"Fluid Ounce", 0.554112},
        {"Tablespoon", 1.10822},
        {"Teaspoon", 3.32465},
        {"Cubic Yard", 0.0005787},
        {"Cubic Foot", 0.0005787}
    }}
}

    Private ReadOnly TimeConversionFactors As New Dictionary(Of String, Dictionary(Of String, Double)) From {
    {"Second", New Dictionary(Of String, Double) From {
        {"Millisecond", 1000},
        {"Microsecond", 1000000.0},
        {"Nanosecond", 1000000000.0},
        {"Minute", 1 / 60},
        {"Hour", 1 / 3600},
        {"Day", 1 / 86400},
        {"Week", 1 / 604800},
        {"Month", 1 / 2592000},
        {"Year", 1 / 31536000}
    }},
    {"Millisecond", New Dictionary(Of String, Double) From {
        {"Second", 0.001},
        {"Microsecond", 1000},
        {"Nanosecond", 1000000.0},
        {"Minute", 1 / 60000},
        {"Hour", 1 / 3600000},
        {"Day", 1 / 86400000},
        {"Week", 1 / 604800000},
        {"Month", 1 / 2592000000},
        {"Year", 1 / 31536000000}
    }},
    {"Microsecond", New Dictionary(Of String, Double) From {
        {"Second", 0.000001},
        {"Millisecond", 0.001},
        {"Nanosecond", 1000},
        {"Minute", 1 / 3600000},
        {"Hour", 1 / 3600000000},
        {"Day", 1 / 86400000000},
        {"Week", 1 / 604800000000},
        {"Month", 1 / 2592000000000},
        {"Year", 1 / 31536000000000}
    }},
    {"Nanosecond", New Dictionary(Of String, Double) From {
        {"Second", 0.000000001},
        {"Millisecond", 0.000001},
        {"Microsecond", 0.001},
        {"Minute", 1 / 60000000000},
        {"Hour", 1 / 3600000000000},
        {"Day", 1 / 86400000000000},
        {"Week", 1 / 604800000000000},
        {"Month", 1 / 2592000000000000},
        {"Year", 1 / 31536000000000000}
    }},
    {"Minute", New Dictionary(Of String, Double) From {
        {"Second", 60},
        {"Millisecond", 60000},
        {"Microsecond", 60000000.0},
        {"Nanosecond", 60000000000.0},
        {"Hour", 1 / 60},
        {"Day", 1 / 1440},
        {"Week", 1 / 10080},
        {"Month", 1 / 43800},
        {"Year", 1 / 525600}
    }},
    {"Hour", New Dictionary(Of String, Double) From {
        {"Second", 3600},
        {"Millisecond", 3600000.0},
        {"Microsecond", 3600000000.0},
        {"Nanosecond", 3600000000000.0},
        {"Minute", 60},
        {"Day", 1 / 24},
        {"Week", 1 / 168},
        {"Month", 1 / 730},
        {"Year", 1 / 8760}
    }},
    {"Day", New Dictionary(Of String, Double) From {
        {"Second", 86400},
        {"Millisecond", 86400000.0},
        {"Microsecond", 86400000000.0},
        {"Nanosecond", 86400000000000.0},
        {"Minute", 1440},
        {"Hour", 24},
        {"Week", 1 / 7},
        {"Month", 1 / 30},
        {"Year", 1 / 365}
    }},
    {"Week", New Dictionary(Of String, Double) From {
        {"Second", 604800},
        {"Millisecond", 604800000.0},
        {"Microsecond", 604800000000.0},
        {"Nanosecond", 604800000000000.0},
        {"Minute", 10080},
        {"Hour", 168},
        {"Day", 7},
        {"Month", 1 / 4.345},
        {"Year", 1 / 52.143}
    }},
    {"Month", New Dictionary(Of String, Double) From {
        {"Second", 2592000},
        {"Millisecond", 2592000000.0},
        {"Microsecond", 2592000000000.0},
        {"Nanosecond", 2.592E+15},
        {"Minute", 43200},
        {"Hour", 720},
        {"Day", 30},
        {"Week", 4.345},
        {"Year", 1 / 12}
    }},
    {"Year", New Dictionary(Of String, Double) From {
        {"Second", 31536000},
        {"Millisecond", 31536000000.0},
        {"Microsecond", 31536000000000.0},
        {"Nanosecond", 3.1536E+16},
        {"Minute", 525600},
        {"Hour", 8760},
        {"Day", 365},
        {"Week", 52.143},
        {"Month", 12}
    }}
}

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(Quantities)

    End Sub

    Private Sub ToggleSideButton_Click_1(sender As Object, e As EventArgs) Handles ToggleSideButton.Click
        Toggle()
        Convert()
    End Sub

    Private Sub Toggle()
        Dim l As Integer = LeftUnitComboBox.SelectedIndex
        Dim r As Integer = RightUnitComboBox.SelectedIndex

        LeftUnitComboBox.SelectedIndex = r
        RightUnitComboBox.SelectedIndex = l
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        LeftUnitComboBox.Items.Clear()
        RightUnitComboBox.Items.Clear()

        LeftUnitComboBox.Text = Nothing
        RightUnitComboBox.Text = Nothing

        Select Case ComboBox1.SelectedItem
            Case "Length"
                Quantity = "Length"
                LoadItems(Length_units)
            Case "Mass"
                Quantity = "Mass"
                LoadItems(Mass_units)
            Case "Speed"
                Quantity = "Speed"
                LoadItems(Speed_units)
            Case "Temperature"
                Quantity = "Temperature"
                LoadItems(Temperature_units)
            Case "Area"
                Quantity = "Area"
                LoadItems(Area_units)
            Case "Volume"
                Quantity = "Volume"
                LoadItems(Volume_units)
            Case "Time"
                Quantity = "Time"
                LoadItems(Time_units)
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub LoadItems(Q As String())
        LeftUnitComboBox.Items.AddRange(Q)
        RightUnitComboBox.Items.AddRange(Q)

        LeftUnitComboBox.SelectedIndex = 0
        RightUnitComboBox.SelectedIndex = 1

        PreviouslySelectedLeftUnit = LeftUnitComboBox.SelectedIndex
        PreviouslySelectedRightUnit = RightUnitComboBox.SelectedIndex
    End Sub

    Private Sub LeftUnitComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LeftUnitComboBox.SelectedIndexChanged
        If SameUnitSelected Then
            SameUnitSelected = False
            Exit Sub
        Else
            If LeftUnitComboBox.SelectedIndex = RightUnitComboBox.SelectedIndex Then
                SameUnitSelected = True

                RightUnitComboBox.SelectedIndex = PreviouslySelectedLeftUnit
                LeftUnitComboBox.SelectedIndex = PreviouslySelectedRightUnit

                PreviouslySelectedLeftUnit = LeftUnitComboBox.SelectedIndex
                PreviouslySelectedRightUnit = RightUnitComboBox.SelectedIndex

            Else
                PreviouslySelectedLeftUnit = LeftUnitComboBox.SelectedIndex
                PreviouslySelectedRightUnit = RightUnitComboBox.SelectedIndex
            End If
        End If
        Convert()
    End Sub

    Private Sub RightUnitComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RightUnitComboBox.SelectedIndexChanged
        If SameUnitSelected Then
            SameUnitSelected = False
            Exit Sub
        Else
            If RightUnitComboBox.SelectedIndex = LeftUnitComboBox.SelectedIndex Then
                SameUnitSelected = True

                RightUnitComboBox.SelectedIndex = PreviouslySelectedLeftUnit
                LeftUnitComboBox.SelectedIndex = PreviouslySelectedRightUnit

                PreviouslySelectedLeftUnit = LeftUnitComboBox.SelectedIndex
                PreviouslySelectedRightUnit = RightUnitComboBox.SelectedIndex

            Else
                PreviouslySelectedLeftUnit = LeftUnitComboBox.SelectedIndex
                PreviouslySelectedRightUnit = RightUnitComboBox.SelectedIndex
            End If
        End If
        Convert()
    End Sub

    Private Sub LeftTextBox_TextChanged(sender As Object, e As EventArgs) Handles LeftTextBox.TextChanged
        Convert()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        LeftTextBox.Clear()
        RightTextbox.Clear()
    End Sub

    Private Sub UnitConversion(InputValue As Double)
        Select Case Quantity
            Case "Length"
                RightTextbox.Text = ConvertLength(InputValue)
            Case "Mass"
                RightTextbox.Text = ConvertMass(InputValue)
            Case "Temperature"
                RightTextbox.Text = ConvertTemperature(InputValue)
            Case "Speed"
                RightTextbox.Text = ConvertSpeed(InputValue)
            Case "Area"
                RightTextbox.Text = ConvertArea(InputValue)
            Case "Volume"
                RightTextbox.Text = ConvertVolume(InputValue)
            Case "Time"
                RightTextbox.Text = ConvertTime(InputValue)
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub Convert()
        If LeftTextBox.Text = Nothing Then
            LeftTextBox.Clear()
            RightTextbox.Clear()
            Exit Sub
        End If

        fromUnit = LeftUnitComboBox.Text
        toUnit = RightUnitComboBox.Text

        InputValue = LeftTextBox.Text

        UnitConversion(InputValue)
    End Sub

    ' Length conversion
    Private Function ConvertLength(InputValue As Double) As Double
        If LengthConversionFactors.ContainsKey(fromUnit) AndAlso LengthConversionFactors(fromUnit).ContainsKey(toUnit) Then
            Dim conversionFactor As Double = LengthConversionFactors(fromUnit)(toUnit)
            Return Math.Round(InputValue * conversionFactor, 5)
        Else
            Return Double.NaN
        End If
    End Function

    ' Mass Conversion
    Private Function ConvertMass(InputValue As Double) As Double
        If MassConversionFactors.ContainsKey(fromUnit) AndAlso MassConversionFactors(fromUnit).ContainsKey(toUnit) Then
            Dim conversionFactor As Double = MassConversionFactors(fromUnit)(toUnit)
            Return Math.Round(InputValue * conversionFactor, 5)
        Else
            Return Double.NaN
        End If
    End Function

    'Speed Conversion
    Private Function ConvertSpeed(InputValue As Double) As Double
        If SpeedConversionFactors.ContainsKey(fromUnit) AndAlso SpeedConversionFactors(fromUnit).ContainsKey(toUnit) Then
            Dim conversionFactor As Double = SpeedConversionFactors(fromUnit)(toUnit)
            Return Math.Round(InputValue * conversionFactor, 5)
        Else
            Return Double.NaN
        End If
    End Function

    'Temperature Conversion
    Private Function ConvertTemperature(InputValue As Double) As Double
        If TemperatureConversionFactors.ContainsKey(fromUnit) AndAlso TemperatureConversionFactors(fromUnit).ContainsKey(toUnit) Then
            Dim conversionFactor As Double = TemperatureConversionFactors(fromUnit)(toUnit)
            Dim intermediateValue As Double

            Select Case fromUnit
                Case "Celsius"
                    intermediateValue = InputValue
                Case "Fahrenheit"
                    intermediateValue = (InputValue - 32) / TemperatureConversionFactors("Fahrenheit")("Celsius")
                Case "Kelvin"
                    intermediateValue = InputValue - 273.15
                Case "Rankine"
                    intermediateValue = (InputValue - 491.67) / TemperatureConversionFactors("Rankine")("Celsius")
                Case Else
                    Return Double.NaN
            End Select

            Select Case toUnit
                Case "Celsius"
                    Return Math.Round(intermediateValue, 5)
                Case "Fahrenheit"
                    Return Math.Round(intermediateValue * TemperatureConversionFactors("Celsius")("Fahrenheit") + 32, 5)
                Case "Kelvin"
                    Return Math.Round(intermediateValue + 273.15, 5)
                Case "Rankine"
                    Return Math.Round((intermediateValue + 273.15) * TemperatureConversionFactors("Celsius")("Rankine"), 5)
                Case Else
                    Return Double.NaN
            End Select
        Else
            Return Double.NaN
        End If
    End Function

    ' Area Conversion
    Private Function ConvertArea(InputValue As Double) As Double
        If AreaConversionFactors.ContainsKey(fromUnit) AndAlso AreaConversionFactors(fromUnit).ContainsKey(toUnit) Then
            Dim conversionFactor As Double = AreaConversionFactors(fromUnit)(toUnit)
            Return Math.Round(InputValue * conversionFactor, 5)
        Else
            Return Double.NaN
        End If
    End Function

    ' Volume Conversion
    Private Function ConvertVolume(InputValue As Double) As Double
        If VolumeConversionFactors.ContainsKey(fromUnit) AndAlso VolumeConversionFactors(fromUnit).ContainsKey(toUnit) Then
            Dim conversionFactor As Double = VolumeConversionFactors(fromUnit)(toUnit)
            Return Math.Round(InputValue * conversionFactor, 5)
        Else
            Return Double.NaN
        End If
    End Function

    ' Time Conversion
    Private Function ConvertTime(InputValue As Double) As Double
        If TimeConversionFactors.ContainsKey(fromUnit) AndAlso TimeConversionFactors(fromUnit).ContainsKey(toUnit) Then
            Dim conversionFactor As Double = TimeConversionFactors(fromUnit)(toUnit)
            Return Math.Round(InputValue * conversionFactor, 5)
        Else
            Return Double.NaN
        End If
    End Function
End Class
