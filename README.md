![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")
# Sitecore Hackathon 2022  

## Team name
⟹ Three.SC

## Category
⟹ Extend the Sitecore Command Line interface (CLI) plugin

## Description
⟹ This module extends the Sitecore CLI plugin, adding a new plugin named Three.SC.CLI

 **This plugin comes with two commands**
 1. Listing all locked Sitecore items in Sitcore tree.
 2. Unlocking all Sitecore items at once or by passing thier item IDs in the CLI.

**The problem we solve:**
 - Unlocking a single Sitecore item is very easy to perform, however when developers want to unlock all the Sitecore items at once, it will take time to go through each item or prepare different scripts to loop the content tree and unlock all items.

 - Getting a list of all locked item in Sitecore content tree can be challenging and require us to write a script.

 **The solution:**
 You can unlock all Sitecore items in the content tree using one line command with the Three.SC.CLI plugin that we built in the Hackathon 2022.  

     dotnet sitecore items unlock

 You can list all the locked items in Sitecore tree with a single command as well. 

     dotnet sitecore items listlocked


## Video link
⟹ The demo video is posted on the link below

⟹ [Replace this Video link](#video-link)



## Pre-requisites and Dependencies
⟹ Sitecore 10.2 with Identity Server fully functional

⟹ The Sitecore CLI gohorse plugin has the following dependencies below:

- Dotnet SDK - 3.1.416 -x64
https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-3.1.416-windows-x64-installer

- Dotnet Hosting - 3.1.22
https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-3.1.22-windows-hosting-bundle-installer

- Sitecore CLI 4.1.1 (should be installed in the Sitecore instance)
https://sitecoredev.azureedge.net/~/media/2B968036924A4EEB98C2E68641B63A43.ashx?date=20220127T085224

* GoHorse.GraphQL (should be installed in the Sitecore instance)   
[GoHorse-GraphQL-Ext-1.0.zip](/sc-packages/GoHorse-GraphQL-Ext-1.0.zip)

⟹ Sitecore CLI installation
- Follow the Sitecore documentation to install the Sitecore CLI plugin:
https://doc.sitecore.com/xp/en/developers/102/developer-tools/install-sitecore-command-line-interface.html


## Installation instructions
⟹ Open the project directory in the Powershell command window and run the command below:

```powershell
dotnet tool restore
```

You must see the message below before continuing:

* Restore was successful.

⟹ Sitecore CLI GoHorse Plugin

To Install the GoHorse plugin use command below:

```powershell
dotnet sitecore plugin add -n GoHorse.CLI.Command
```

You must see the message below before continuing:

* Successfully installed version X.X.X of plugin GoHorse.CLI.Command

### Configuration
⟹ If there are any custom configuration that has to be set manually then remember to add all details here.

_Remove this subsection if your entry does not require any configuration that is not fully covered in the installation instructions already_

## Usage instructions
⟹ Before running the new plugin, you must execute the Sitecore CLI login to authenticate in the Sitecore IdentityServer instance:

```powershell
dotnet sitecore login --authority https://<Sitecore identity server> --cm http://<Sitecore instance> --allow-write true
```

![Sitecore CLI login](docs/images/sitecore-cli-login.png?raw=true "Sitecore CLI login")

Use the command below to execute the command available:

```powershell
dotnet gohorse run-command --command-id "{Sitecore PowerShell script ID}"
```

If the execution was successful, users will see a message "true" returned in the window.

![Sitecore gohorse execution](docs/images/sitecore-gohorse-execution.png?raw=true "Sitecore gohorse execution")

NOTE:
If you do not have a Powershell script to test the plugin, open your Sitecore instance, and create a new one adding the code below (this script changes the Title field of the Home item, adding its text + "1"):

```powershell
$item = Get-Item -Path "master:\content\home"

$item.Editing.BeginEdit()

$item.Fields["Title"].Value = $item.Fields["Title"].Value + "1"

$item.Editing.EndEdit()
```

#GoHorse

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")

## Comments
If you'd like to make additional comments that is important for your module entry.