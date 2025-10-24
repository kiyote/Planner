
# Note
This project uses TailwindCSS.  When editing CSS styles, edit the file `wwwroot/css/app.css`.  It is compiled in to `wwwroot/css/dist.css` which is what is referenced by `wwwroot/index.html`.

# Launching
A launch settings file would be:

`launchSettings.json`
```json
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}",
      "applicationUrl": "http://localhost:5278",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}",
      "applicationUrl": "https://localhost:7047;http://localhost:5278",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

# Publishing

When creating a publishing profile, it can be useful to ensure all files are removed by default. An example profile would be:

`PublishProfiles/FolderProfile.pubxml`
```xml
<?xml version="1.0" encoding="utf-8"?>
<!-- https://go.microsoft.com/fwlink/?LinkID=208121. -->
<Project>
  <PropertyGroup>
    <DeleteExistingFiles>true</DeleteExistingFiles>
    <ExcludeApp_Data>false</ExcludeApp_Data>
    <LaunchSiteAfterPublish>true</LaunchSiteAfterPublish>
    <LastUsedBuildConfiguration>Release</LastUsedBuildConfiguration>
    <LastUsedPlatform>Any CPU</LastUsedPlatform>
    <PublishProvider>FileSystem</PublishProvider>
    <PublishUrl>bin\Release\net9.0\browser-wasm\publish\</PublishUrl>
    <WebPublishMethod>FileSystem</WebPublishMethod>
    <_TargetId>Folder</_TargetId>
    <SiteUrlToLaunchAfterPublish />
    <TargetFramework>net9.0</TargetFramework>
    <RuntimeIdentifier>browser-wasm</RuntimeIdentifier>
    <RunAOTCompilation>true</RunAOTCompilation>
    <ProjectGuid>d57a950f-8251-4e2b-b8f4-86bffc12a857</ProjectGuid>
    <SelfContained>true</SelfContained>
  </PropertyGroup>
</Project>
```
