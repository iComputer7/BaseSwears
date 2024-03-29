@{
    RootModule = 'BaseSwears-Powershell5.dll'
    ModuleVersion = '1.0'
    GUID = '8a12c707-f7a4-427a-a426-86cfa8a3011d'
    Author = 'iComputer7'
    CompanyName = 'N/A'
    Copyright = 'MIT License'
    Description = 'Encodes binary files with swear words'
    PowerShellVersion = '5.0'
    PowerShellHostVersion = '5.0'
    DotNetFrameworkVersion = '4.6.1'
    FunctionsToExport = @()
    CmdletsToExport = @(
        "ConvertFrom-BaseSwears",
        "ConvertTo-BaseSwears"
    )
    VariablesToExport = '*'
    AliasesToExport = @()
    FileList = @(
        ".\BaseSwears.dll",
        ".\BaseSwears-Powershell5.dll"
    )
    PrivateData = @{
        PSData = @{}
    }
}