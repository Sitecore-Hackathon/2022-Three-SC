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
 - Unlocking a **single** Sitecore item is very easy to perform, however when we want to unlock all the Sitecore items in the tree at once it becomes a challenging task.
 it will take a long time to go through each item for unlocking. Some prepare different scripts to loop the content tree to unlock the items.

 - Getting a list of all locked items in the Sitecore content tree can be challenging and require us to write a script.

 **The solution:**
  You can unlock all Sitecore items in the content tree using the one-line command with the Three.SC.CLI plugin that we built in Hackathon 2022. 

     dotnet sitecore items unlock

 You can list all the locked items in Sitecore tree with a single command as well. 

     dotnet sitecore items listlocked


## Video link
⟹ The demo video is posted on the link below

⟹ [Replace this Video link](#video-link)



## Pre-requisites and Dependencies

- Sitecore 10.2 
- Sitecore CLI (Latest version)

## Installation instructions

 1. Install Sitecore CLI using Sitecore documentation https://doc.sitecore.com/xp/en/developers/101/developer-tools/install-sitecore-command-line-interface.html
 2. Install Three.SC.CLI using the following command

   
    **dotnet sitecore plugin add -n Three.SC.CLI**
or
    **dotnet sitecore plugin add -n Three.SC.CLI --version 1.0.3**
   
 3. Install the the CLI endpoints Sitecore package in this repository under the folder package


## Usage instructions

  Unlock all Sitecore items in the content tree.  

     dotnet sitecore items unlock

  List all the locked items in Sitecore tree. 

     dotnet sitecore items listlocked

  Unlock all Sitecore items based on IDs  

     dotnet sitecore items unlock -i {ids}

  List all locked Sitecore items based on IDs  

     dotnet sitecore items listlocked -i {ids}

Get help with all available paramters for listlocked command 

     dotnet sitecore items listlocked -h

Get help with all available paramters for unlock command 

     dotnet sitecore items unlock -h

    

## Comments
If you'd like to make additional comments that is important for your module entry.