param(
    [string]$FlowPluginsDirectory = "$env:APPDATA\FlowLauncher\Plugins"
)

$ErrorActionPreference = "Stop"
$ProjectRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$ArtifactsDirectory = Join-Path $ProjectRoot "artifacts\LayoutFallback-0.1.4"
$TargetDirectory = Join-Path $FlowPluginsDirectory "LayoutFallback-0.1.4"

& (Join-Path $ProjectRoot "build.ps1")

Remove-Item $TargetDirectory -Recurse -Force -ErrorAction SilentlyContinue
New-Item $TargetDirectory -ItemType Directory -Force | Out-Null
Copy-Item (Join-Path $ArtifactsDirectory "*") $TargetDirectory -Recurse -Force

Write-Host ""
Write-Host "Installed to: $TargetDirectory"
Write-Host "Restart Flow Launcher."
