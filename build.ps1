$ErrorActionPreference = "Stop"

$ProjectRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$OutputRoot = Join-Path $ProjectRoot "artifacts"
$PublishRoot = Join-Path $OutputRoot "LayoutFallback-0.1.4"
$ZipPath = Join-Path $OutputRoot "LayoutFallback-0.1.4.zip"

if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    throw ".NET SDK was not found. Install it: winget install Microsoft.DotNet.SDK.9"
}

Remove-Item $OutputRoot -Recurse -Force -ErrorAction SilentlyContinue
New-Item $PublishRoot -ItemType Directory -Force | Out-Null

dotnet publish (Join-Path $ProjectRoot "LayoutFallback.csproj") `
    --configuration Release `
    --output $PublishRoot

# Flow Launcher provides its own SDK assembly.
Remove-Item (Join-Path $PublishRoot "Flow.Launcher.Plugin.dll") -Force -ErrorAction SilentlyContinue
Remove-Item (Join-Path $PublishRoot "Flow.Launcher.Plugin.xml") -Force -ErrorAction SilentlyContinue
Remove-Item (Join-Path $PublishRoot "*.pdb") -Force -ErrorAction SilentlyContinue

Compress-Archive -Path (Join-Path $PublishRoot "*") -DestinationPath $ZipPath -Force

Write-Host ""
Write-Host "Done: $ZipPath"
Write-Host "Install this ZIP from Flow Launcher plugin settings, then restart Flow Launcher."
