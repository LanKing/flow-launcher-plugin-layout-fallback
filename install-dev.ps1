param(
    [string]$FlowPluginsDirectory = "$env:APPDATA\FlowLauncher\Plugins"
)

$ErrorActionPreference = "Stop"

$ProjectRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$ArtifactsDirectory = Join-Path $ProjectRoot "artifacts\LayoutFallback"
$TargetDirectory = Join-Path $FlowPluginsDirectory "LayoutFallback"

& (Join-Path $ProjectRoot "build.ps1")

if (-not (Test-Path $ArtifactsDirectory)) {
    throw "Build output was not found: $ArtifactsDirectory"
}

Remove-Item $TargetDirectory -Recurse -Force -ErrorAction SilentlyContinue
New-Item $TargetDirectory -ItemType Directory -Force | Out-Null
Copy-Item (Join-Path $ArtifactsDirectory "*") $TargetDirectory -Recurse -Force

Write-Host ""
Write-Host "Installed to: $TargetDirectory"
Write-Host "Restart Flow Launcher."