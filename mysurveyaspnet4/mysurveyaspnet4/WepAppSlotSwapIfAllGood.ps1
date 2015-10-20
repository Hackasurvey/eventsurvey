$r = Invoke-WebRequest -Uri http://hackasurvey-staging.azurewebsites.net -Method POST

if ($r.StatusCode –eq 200)
{
    Write-Host "Life is good!"

    Switch-AzureWebsiteSlot –Name hackasurvey -Slot1 staging
}