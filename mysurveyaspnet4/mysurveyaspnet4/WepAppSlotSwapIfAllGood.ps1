$r = Invoke-WebRequest -Uri http://hackasurvey-staging.azurewebsites.net -Method GET -UseBasicParsing

if ($r.StatusCode –eq 200)
{
    Write-Host "Life is good!"

    Switch-AzureWebsiteSlot –Name hackasurvey -Slot1 staging
}