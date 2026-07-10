$ErrorActionPreference = "Stop"

$ProjectRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$PluginJsonPath = Join-Path $ProjectRoot "plugin.json"

if (-not (Test-Path $PluginJsonPath)) {
    throw "plugin.json was not found."
}

$PluginJson = Get-Content $PluginJsonPath -Raw | ConvertFrom-Json
$PluginVersion = $PluginJson.Version

if ([string]::IsNullOrWhiteSpace($PluginVersion)) {
    throw "plugin.json does not contain Version."
}

$OutputRoot = Join-Path $ProjectRoot "artifacts"
$PublishRoot = Join-Path $OutputRoot "LayoutFallback"
$ZipPath = Join-Path $OutputRoot "LayoutFallback.zip"

if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    throw ".NET SDK was not found. Install it: winget install Microsoft.DotNet.SDK.9"
}

Remove-Item $OutputRoot -Recurse -Force -ErrorAction SilentlyContinue
New-Item $PublishRoot -ItemType Directory -Force | Out-Null

dotnet publish (Join-Path $ProjectRoot "LayoutFallback.csproj") `
    --configuration Release `
    --output $PublishRoot

Remove-Item (Join-Path $PublishRoot "Flow.Launcher.Plugin.dll") -Force -ErrorAction SilentlyContinue
Remove-Item (Join-Path $PublishRoot "Flow.Launcher.Plugin.xml") -Force -ErrorAction SilentlyContinue
Remove-Item (Join-Path $PublishRoot "*.pdb") -Force -ErrorAction SilentlyContinue

Compress-Archive -Path (Join-Path $PublishRoot "*") -DestinationPath $ZipPath -Force

Write-Host ""
Write-Host "Version: $PluginVersion"
Write-Host "Publish directory: $PublishRoot"
Write-Host "Installable ZIP: $ZipPath"
Write-Host "Install this ZIP from Flow Launcher plugin settings, then restart Flow Launcher."